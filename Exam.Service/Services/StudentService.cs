
using Exam.Data.IRepositories;
using Exam.Data.Repositories;
using Exam.Domain.Entities.Users;
using Exam.Service.Constants;
using Exam.Service.DTOs.Users;
using Exam.Service.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Exam.Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;
        private readonly string url = ApiConstants.BASE_URL;
        private readonly HttpClient httpClient;

        public StudentService()
        {
            studentRepository = new StudentRepository();
            httpClient = new HttpClient();
        }

        public async Task<Student> CreateAsync(StudentForCreationDTO student)
        {
            var newStudent = JsonConvert.SerializeObject(student);

            var requestContent = new StringContent
                (newStudent, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(url, requestContent);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var createdStudent = JsonConvert.DeserializeObject<Student>(content);
                
                await studentRepository.CreateAsync(createdStudent);
                await studentRepository.SaveAsync();

                return createdStudent;
            }

            return null;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var response = await httpClient.DeleteAsync(url + id);

            if (response.IsSuccessStatusCode)
            {
                await studentRepository.DeleteAsync(s => s.Id == id);
                await studentRepository.SaveAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue
                ("Basic", Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes("admin:12345")));

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var resultContent = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<IEnumerable<Student>>(resultContent);
            }

            return null;
        }

        public async Task<Student> GetAsync(long id)
        {
            var response = await httpClient.GetAsync(url + id);

            if (response.IsSuccessStatusCode)
            {
                var resultContent = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Student>(resultContent);
            }

            return null;
        }

        public async Task<Student> UpdateAsync(long id, Student student)
        {
            var newstudentAsJson = JsonConvert.SerializeObject(student);

            StringContent responseContent = new StringContent(newstudentAsJson, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync(url + id, responseContent);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var updatedStudent =  JsonConvert.DeserializeObject<Student>(content);
                
                return updatedStudent;
            }

            return null;
        }
    }
}
