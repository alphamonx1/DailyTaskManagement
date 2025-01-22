using DailyTaskManagement.Application.DTOs.Status;

namespace DailyTaskManagement.Application.Services.Status
{
    public interface IItemStatusService
    {
        public Task<List<ItemStatusDto>> GetAllItemStatusAsync();
    }
}
