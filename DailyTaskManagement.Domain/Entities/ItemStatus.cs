using DailyTaskManagement.Domain.Common;

namespace DailyTaskManagement.Domain.Entities
{
    public class ItemStatus : BaseEntity<int>
    {
        public string? ItemStatusName { get; set; }
        public required ICollection<TodoItem> TodoItems { get; set; }
    }
}
