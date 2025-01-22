using DailyTaskManagement.Application.DTOs.TodoItem;

namespace DailyTaskManagement.Application.Repositories.TodoItem
{
    public interface ITodoItemRepository
    {
        public Task<List<TodoItemDto>> GetAllItemAsync();
        public Task<TodoItemDto> GetItemByIdAsync(string id);

        public Task<int> UpdateTodoItemStatusByIdAsync(string id, int newStatus);
        public Task<int> CreateNewItemTodoAsync(CreateTodoItemDto item);
    }
}
