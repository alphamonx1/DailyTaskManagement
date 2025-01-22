using DailyTaskManagement.Application.DbContext;
using DailyTaskManagement.Application.DTOs.TodoItem;
using DailyTaskManagement.Application.Repositories.TodoItem;
using Microsoft.EntityFrameworkCore;

namespace DailyTaskManagement.Infrastructure.Persistence.Repositories.TodoItem
{
    public class TodoItemRepository(IDailyTaskManagementDbContext dbContext) : ITodoItemRepository
    {
        private readonly IDailyTaskManagementDbContext _dbContext = dbContext;

        public async Task<int> CreateNewItemTodoAsync(CreateTodoItemDto item)
        {
            var newtodoItem = new Domain.Entities.TodoItem()
            {
                Id = item.ItemId,
                ItemName = item.ItemName,
                ItemStatusId = 1
            };
            await _dbContext.TodoItem.AddAsync(newtodoItem);
            return await _dbContext.SaveChangeAsync();
        }

        public async Task<List<TodoItemDto>> GetAllItemAsync()
        {
            var results = await _dbContext.TodoItem
                .Select(item => new TodoItemDto
                {
                    Id = item.Id,
                    ItemName = item.ItemName,
                    ItemStatus = item.ItemStatus.ItemStatusName,
                })
                .ToListAsync();
            return results;
        }

        public async Task<TodoItemDto?> GetItemByIdAsync(string id)
        {
            var todoItemDb = await _dbContext.TodoItem
                .Include(item => item.ItemStatus)
                .FirstOrDefaultAsync(item => item.Id == id);
            return todoItemDb == null
                ? null
                : new TodoItemDto()
                {
                    Id = todoItemDb.Id,
                    ItemName= todoItemDb.ItemName,
                    ItemStatus = todoItemDb.ItemStatus.ItemStatusName
                };
        }

        public async Task<int> UpdateTodoItemStatusByIdAsync(string id, int newStatus)
        {
            var updateItem = await _dbContext.TodoItem.FirstOrDefaultAsync(item => item.Id == id);
            if(updateItem != null)
            {
                if(newStatus is not 0)
                {
                    updateItem.ItemStatusId = newStatus;
                    await _dbContext.SaveChangeAsync();
                    return 1;
                }
            }
            return 0;
        }
    }
}
