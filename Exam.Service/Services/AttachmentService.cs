
using Exam.Data.IRepositories;
using Exam.Data.Repositories;
using Exam.Domain.Entities.Students;
using Exam.Domain.Entities.Users;
using Exam.Service.Constants;
using Exam.Service.DTOs.Users;
using Exam.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Service.Services
{
    public class AttachmentService : IAttachmentService
    {
        private readonly string url = ApiConstants.BASE_URL;
        private readonly IAttachmentRepository attachmentRepository;

        public AttachmentService()
        {
            attachmentRepository = new AttachmentRepository();
        }

        public async Task CreateAsync(long id, string imagePath, string passportPath)
        {
            HttpClient client = new HttpClient();

            MultipartFormDataContent formData = new MultipartFormDataContent();
            if (imagePath is not null)
                formData.Add(new StreamContent(File.OpenRead(imagePath)), "image", "image.png");

            if (passportPath is not null)
                formData.Add(new StreamContent(File.OpenRead(passportPath)), "passport", "passport.png");

            HttpResponseMessage response = await client.PostAsync(url + "Attachments/" + id, formData);

            await response.Content.ReadAsStringAsync();
        }

        public async Task CreateAsynDatabase(Attachment attachment)
        {
            await attachmentRepository.CreateAsync(attachment);
            await attachmentRepository.SaveAsync();
        }
    }
}
