
using Exam.Domain.Commons;

namespace Exam.Domain.Entities.Students
{
    public class Attachment : Auiditable
    {
        public string Name { get; set; }
        public string Path { get; set; }
    }
}