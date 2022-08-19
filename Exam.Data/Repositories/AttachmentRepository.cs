
using Exam.Data.IRepositories;
using Exam.Domain.Entities.Students;
using Exam.Domain.Entities.Users;

namespace Exam.Data.Repositories
{
    public class AttachmentRepository : GenericRepository<Attachment>, IAttachmentRepository
    {
    }
}
