using DailyTaskManagement.Application.DbContext;
using DailyTaskManagement.Application.Repositories.Status;
using DailyTaskManagement.Application.Repositories.TodoItem;
using DailyTaskManagement.Application.Services.TodoItem;
using DailyTaskManagement.Infrastructure.DailyTaskDbContext;
using DailyTaskManagement.Infrastructure.Persistence.Repositories.Status;
using DailyTaskManagement.Infrastructure.Persistence.Repositories.TodoItem;
using DailyTaskManagement.Infrastructure.Services.TodoItem;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DailyTaskManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DailyTaskManagementDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("HoangDatabase"),
                b => b.MigrationsAssembly(typeof(DailyTaskManagementDbContext).Assembly.FullName)), ServiceLifetime.Transient);

            services.AddScoped<IDailyTaskManagementDbContext>(provider => provider.GetService<DailyTaskManagementDbContext>());
            services.AddScoped<ITodoItemRepository, TodoItemRepository>();
            services.AddScoped<IItemStatusRepository,ItemStatusRepository>();

            services.AddScoped<ITodoItemService, TodoItemService>();

            services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7294/")
            });

            return services;
        }
    }
}
