using Microsoft.Extensions.DependencyInjection;
using ToDoApp.Domain.Interfaces.Repositories;
using ToDoApp.Infrastructure.Persistence.DbContext;
using ToDoApp.Infrastructure.Persistence.Repository;

namespace ToDoApp.Infrastructure.Persistence.Extensions;

public static class PersistenceExtension
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        // Connection
        services.AddDbContext<AppDbContext>();

        // Repositories
        services.AddScoped<IToDoTaskRepository, ToDoTaskRepository>();

        return services;
    }

    public static IServiceProvider EnsureDatabaseCreated(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        dbContext.Database.EnsureCreated();

        return serviceProvider;
    }
}
