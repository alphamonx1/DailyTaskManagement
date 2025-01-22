using DailyTaskManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DailyTaskManagement.Application.DbContext
{
    public interface IDailyTaskManagementDbContext
    {
        DbSet<TodoItem> TodoItem {  get; set; }
        DbSet<ItemStatus> ItemStatus { get; set; }

        Task<int> SaveChangeAsync();

    }
}
