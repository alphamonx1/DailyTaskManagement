﻿using DailyTaskManagement.Application.DbContext;
using DailyTaskManagement.Application.DTOs;
using DailyTaskManagement.Application.Repositories.TodoItem;
using Microsoft.EntityFrameworkCore;

namespace DailyTaskManagement.Infrastructure.Persistence.Repositories.TodoItem
{
    public class TodoItemRepository(IDailyTaskManagementDbContext dbContext) : ITodoItemRepository
    {
        private readonly IDailyTaskManagementDbContext _dbContext = dbContext;

        public Task<int> CreateNewItemTodoAsync(TodoItemDto item)
        {
            throw new NotImplementedException();
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
    }
}
