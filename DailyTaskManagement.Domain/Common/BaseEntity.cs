namespace DailyTaskManagement.Domain.Common
{
    public abstract class BaseEntity<T>
    {
        public virtual required T Id { get; set; }
    }
}
