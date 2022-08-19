
using Exam.Domain.Entities.Students;
using Exam.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Exam.Data.Contexts
{
    public class ExamDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Attachment> Attachments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Host=localhost;Port=5432;Database=ExamDdb;Username=postgres;password=123";
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}