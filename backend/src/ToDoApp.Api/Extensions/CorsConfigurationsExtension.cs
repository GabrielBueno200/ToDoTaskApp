namespace ToDoApp.Api.Extensions;

public static class CorsConfigurationsExtension
{
    public static void AddCorsConfigs(this IServiceCollection service)
    {
        service.AddCors(opt =>
        {
            opt.AddPolicy("CorsPolicy", policy =>
            {
                policy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
        });
    }
}
