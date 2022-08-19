
using Exam.Domain.Entities.Students;
using Exam.Domain.Entities.Users;
using Exam.Service.DTOs.Users;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Service.Interfaces
{
    public interface IAttachmentService
    {
        Task CreateAsync(long id, string imagePath, string passportPath);
        public Task CreateAsynDatabase(Attachment attachment);
    }
}