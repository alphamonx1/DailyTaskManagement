
using DailyTaskManagement.Application.DTOs.Status;

namespace DailyTaskManagement.Application.Repositories.Status

{
    public interface IItemStatusRepository
    {
        public Task<List<ItemStatusDto>> GetAllItemStatusAsync();
    }
}
