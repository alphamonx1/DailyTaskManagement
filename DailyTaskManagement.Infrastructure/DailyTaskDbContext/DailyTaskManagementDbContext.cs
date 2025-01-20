using DailyTaskManagement.Application.DbContext;
using DailyTaskManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DailyTaskManagement.Infrastructure.DailyTaskDbContext
{
    public class DailyTaskManagementDbContext(DbContextOptions<DailyTaskManagementDbContext> options) : DbContext(options), IDailyTaskManagementDbContext
    {
        public DbSet<TodoItem> TodoItem { get; set; }
        public DbSet<ItemStatus> TtemStatuses { get; set; }

        public Task<int> SaveChangeAsync()
        {
            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TodoItem>()
                .HasOne(t => t.ItemStatus) // Navigation property in TodoItem
                .WithMany(s => s.TodoItems) // Collection navigation property in ItemStatus
                .HasForeignKey(t => t.ItemStatusId) // Foreign key in TodoItem
                .OnDelete(DeleteBehavior.Restrict); // Optional: Configure delete behavior
        }
    }
}
