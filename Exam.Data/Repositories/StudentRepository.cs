
using Exam.Data.IRepositories;
using Exam.Domain.Entities.Users;

namespace Exam.Data.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
    }
}
