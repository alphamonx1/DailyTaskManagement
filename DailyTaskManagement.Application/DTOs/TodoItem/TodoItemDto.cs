namespace DailyTaskManagement.Application.DTOs.TodoItem
{
    public class TodoItemDto
    {
        public required string Id { get; set; }
        public string? ItemName { get; set; }
        public string? ItemStatus { get; set; }
    }
}
