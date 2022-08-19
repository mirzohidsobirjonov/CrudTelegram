
using Exam.Data.Contexts;
using Exam.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Exam.Data.Repositories
{
    #pragma warning disable
    public class GenericRepository<TSource> : IGenericRepository<TSource> where TSource :class
    {
        private readonly ExamDbContext dbContext;
        private readonly DbSet<TSource> dbSet;

        public GenericRepository()
        {
            dbContext = new ExamDbContext();
            dbSet = dbContext.Set<TSource>();
        }

        public async Task<TSource> CreateAsync(TSource source)
            => (await dbSet.AddAsync(source)).Entity;

        public async Task<bool> DeleteAsync(Expression<Func<TSource, bool>> predicate)
        {
            var entity = await GetAsync(predicate);

            if (entity is null)
                return false;

            dbSet.Remove(entity);

            return true;
        }

        public IQueryable<TSource> GetAll(Expression<Func<TSource, bool>> predicate = null)
            => predicate is null ? dbSet : dbSet.Where(predicate);

        public virtual async Task<TSource> GetAsync(Expression<Func<TSource, bool>> predicate)
            => await dbSet.FirstOrDefaultAsync(predicate);

        public async Task<TSource> UpdateAsync(TSource source)
            => dbSet.Update(source).Entity;

        public async Task SaveAsync()
            => await dbContext.SaveChangesAsync();
    }
}
