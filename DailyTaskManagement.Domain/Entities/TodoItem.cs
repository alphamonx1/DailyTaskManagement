using DailyTaskManagement.Domain.Common;

namespace DailyTaskManagement.Domain.Entities
{
    public class TodoItem : BaseEntity<string>
    {
        public string? ItemName { get; set; }
        public int ItemStatusId { get; set; }

        public required ItemStatus ItemStatus { get; set; }
    }
}
