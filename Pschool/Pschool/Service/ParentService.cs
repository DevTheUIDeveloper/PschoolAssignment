using Pschool.Model;
using System.Net.Http.Json;
using System.Linq.Dynamic.Core;

namespace Pschool.Service
{
    public class ParentService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7069/api/parents";

        public ParentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ParentModel>> GetParents()
        {
            var response = await _httpClient.GetFromJsonAsync<List<ParentModel>>($"{BaseUrl}");
            return response;
        }

        public async Task<ParentModel> GetParentById(int parentId)
        {
            return await _httpClient.GetFromJsonAsync<ParentModel>($"{BaseUrl}/{parentId}");
        }

        public async Task AddParent(ParentModel parent)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, parent);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateParent(int parentId, ParentModel parent)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{parentId}", parent);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteParent(int parentId)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{parentId}");
            response.EnsureSuccessStatusCode();
        }
    }
}
