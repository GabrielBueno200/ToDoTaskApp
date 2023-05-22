using Microsoft.Extensions.DependencyInjection;
using ToDoApp.Application.Extensions;
using ToDoApp.Infrastructure.Persistence.Extensions;

namespace ToDoApp.CrossCutting.IoC;

public static class Bootstrap
{
    public static void AddApi(this IServiceCollection service)
    {
        service.AddApplicationService();
        service.AddPersistence();
    }
}
