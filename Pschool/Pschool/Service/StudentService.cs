using System.Linq.Dynamic.Core;
using System.Net.Http.Json;
using Pschool.Model;

namespace Pschool.Service
{
    public class StudentService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7069/api/students";

        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<StudentModel>> GetStudents(int parentIdFilter = 0)
        {
            if(parentIdFilter== 0)
                return await _httpClient.GetFromJsonAsync<List<StudentModel>>($"{BaseUrl}");
            return await _httpClient.GetFromJsonAsync<List<StudentModel>>($"{BaseUrl}/{parentIdFilter}/GetStudentByParentId");
        }

        public async Task<StudentModel> GetStudentById(int studentId)
        {
            return await _httpClient.GetFromJsonAsync<StudentModel>($"{BaseUrl}/{studentId}");
        }

        public async Task<int> AddStudent(StudentModel student)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, student);
            response.EnsureSuccessStatusCode();
            var newStudentModel = await response.Content.ReadFromJsonAsync<StudentModel>();
            return newStudentModel.Id;
        }

        public async Task UpdateStudent(int studentId, StudentModel student)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{studentId}", student);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteStudent(int studentId)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{studentId}");
            response.EnsureSuccessStatusCode();
        }
    }
}
