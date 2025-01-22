using DailyTaskManagement.Application.DTOs.Status;
using DailyTaskManagement.Application.Repositories.Status;
using Microsoft.AspNetCore.Mvc;

namespace DailyTaskManagement.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemStatusController(IItemStatusRepository itemStatusRepository) : ControllerBase
    {
        private readonly IItemStatusRepository _itemStatusRepository = itemStatusRepository;

        [HttpGet]
        public async Task<List<ItemStatusDto>> GetItemStatusesAsync()
        {
            return await _itemStatusRepository.GetAllItemStatusAsync();
        }
    }
}
