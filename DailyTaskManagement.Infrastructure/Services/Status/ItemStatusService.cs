using DailyTaskManagement.Application.DTOs.Status;
using DailyTaskManagement.Application.Services.Status;
using System.Net.Http.Json;

namespace DailyTaskManagement.Infrastructure.Services.Status
{
    public class ItemStatusService : IItemStatusService
    {
        private readonly HttpClient _httpClient;
        public ItemStatusService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.Timeout = TimeSpan.FromMinutes(5);
        }
        public async Task<List<ItemStatusDto>> GetAllItemStatusAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<ItemStatusDto>>("api/ItemStatus"); // Replace with your endpoint
            return response ?? [];
        }
    }
}
