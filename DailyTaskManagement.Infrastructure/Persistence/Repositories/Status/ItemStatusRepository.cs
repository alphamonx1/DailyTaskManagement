using DailyTaskManagement.Application.DbContext;
using DailyTaskManagement.Application.DTOs.Status;
using DailyTaskManagement.Application.Repositories.Status;
using Microsoft.EntityFrameworkCore;

namespace DailyTaskManagement.Infrastructure.Persistence.Repositories.Status
{
    public class ItemStatusRepository(IDailyTaskManagementDbContext dbContext) : IItemStatusRepository
    {
        private readonly IDailyTaskManagementDbContext _dbContext = dbContext;

        public async Task<List<ItemStatusDto>> GetAllItemStatusAsync()
        {
            if (_dbContext == null)
                throw new ArgumentNullException(nameof(_dbContext), "DbContext is not initialized.");

            var itemStatus = await _dbContext.ItemStatus.ToListAsync();

            var results = itemStatus.Select(i => new ItemStatusDto
            {
                Id = i.Id,
                ItemStatusName = i.ItemStatusName
                // Map other properties
            }).ToList();

            return results;
        }
    }
}
