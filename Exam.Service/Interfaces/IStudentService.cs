
using Exam.Domain.Entities.Users;
using Exam.Service.DTOs.Users;
using System.Linq.Expressions;

namespace Exam.Service.Interfaces
{
    public interface IStudentService
    {
        Task<Student> CreateAsync(StudentForCreationDTO student);
        Task<bool> DeleteAsync(long id);
        Task<Student> GetAsync(long Id);
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> UpdateAsync(long id, Student student);
    }
}