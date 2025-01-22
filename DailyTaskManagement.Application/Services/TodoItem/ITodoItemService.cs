using DailyTaskManagement.Application.DTOs.TodoItem;

namespace DailyTaskManagement.Application.Services.TodoItem
{
    public interface ITodoItemService
    {
        Task<List<TodoItemDto>> GetAllTodoItemAsync();

        Task<int> CreateNewTodoItemAsync(CreateTodoItemDto item);
        Task<int> UpdateTodoItemStatusByIdAsync(string id, int status);
    }
}
