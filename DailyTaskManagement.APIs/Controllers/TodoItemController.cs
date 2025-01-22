using DailyTaskManagement.Application.DTOs.TodoItem;
using DailyTaskManagement.Application.Repositories.TodoItem;
using Microsoft.AspNetCore.Mvc;

namespace DailyTaskManagement.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController(ITodoItemRepository todoItemRepository) : ControllerBase
    {
        private readonly ITodoItemRepository _todoItemRepository = todoItemRepository;

        [HttpGet]
        public async Task<ActionResult<List<TodoItemDto>>> GetAllTodoItemAsync()
        {
            return await _todoItemRepository.GetAllItemAsync();
        }

        [HttpGet("id")]
        public async Task<ActionResult<TodoItemDto>> GetItemByIdAsync(string id)
        {
            return await _todoItemRepository.GetItemByIdAsync(id);   
        }

        [HttpPost]
        public async Task<int> CreateNewItemTodoAsync([FromBody] CreateTodoItemDto item)
        {
            return await _todoItemRepository.CreateNewItemTodoAsync(item);
        }

        [HttpPut("id")]
        public async Task<int> UpdateItemStatusByIdAsync(string id, [FromQuery] int status)
        {
            return await _todoItemRepository.UpdateTodoItemStatusByIdAsync($"{id}", status);
        }
    }
}
