using DailyTaskManagement.Application.DTOs.TodoItem;
using DailyTaskManagement.Application.Services.TodoItem;
using System.Net.Http;
using System.Net.Http.Json;

namespace DailyTaskManagement.Infrastructure.Services.TodoItem
{
    public class TodoItemService : ITodoItemService
    {
        private readonly HttpClient _httpClient;
        public TodoItemService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TodoItemDto>> GetAllTodoItemAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<TodoItemDto>>("api/TodoItem"); // Replace with your endpoint
            return response ?? [];
        }

        public async Task<int> UpdateTodoItemStatusByIdAsync(string id, int status)
        {
            var url = $"api/TodoItem/id?id={id}&status={status}";
            var response = await _httpClient.PutAsync(url, null);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<int>();
                return result;
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
                return -1;
            }
        }
    }
}
