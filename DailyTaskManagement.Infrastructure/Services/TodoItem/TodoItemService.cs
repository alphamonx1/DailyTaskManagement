using DailyTaskManagement.Application.DTOs;
using DailyTaskManagement.Application.Services.TodoItem;
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
    }
}
