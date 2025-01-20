using DailyTaskManagement.Application.DTOs;

namespace DailyTaskManagement.Application.Repositories.TodoItem
{
    public interface ITodoItemRepository
    {
        public Task<List<TodoItemDto>> GetAllItemAsync();
        public Task<TodoItemDto> GetItemByIdAsync(string id);
        public Task<int> CreateNewItemTodoAsync(TodoItemDto item);
    }
}
