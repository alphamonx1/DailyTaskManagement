using DailyTaskManagement.Application.DTOs;

namespace DailyTaskManagement.Application.Services.TodoItem
{
    public interface ITodoItemService
    {
        Task<List<TodoItemDto>> GetAllTodoItemAsync();
    }
}
