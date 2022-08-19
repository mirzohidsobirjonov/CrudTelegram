using Exam.Service.Services;

var studentService = new StudentService();

var users = await studentService.CreateAsync(new Exam.Service.DTOs.Users.StudentForCreationDTO()
{
    Firstname = "Mirzohid",
    Lastname = "Sobirjonov",
    Faculty = ".NET"
});

Console.WriteLine(users.Id + " "+ users.FirstName);