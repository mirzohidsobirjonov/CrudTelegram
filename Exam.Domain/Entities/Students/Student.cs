

using Exam.Domain.Commons;
using Exam.Domain.Entities.Students;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Domain.Entities.Users
{
    public class Student : Auiditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Faculty { get; set; }

        public long? PassportId { get; set; }
        [ForeignKey(nameof(PassportId))]
        public Attachment Passport { get; set; }

        public long? ImageId { get; set; }
        [ForeignKey(nameof(ImageId))]
        public Attachment Image { get; set; }
    }
}