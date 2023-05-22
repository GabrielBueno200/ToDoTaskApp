using ToDoApp.Api.Routes;
using ToDoApp.CrossCutting.IoC;
using ToDoApp.Api.Extensions;
using ToDoApp.Infrastructure.Persistence.Extensions;
using ToDoApp.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCorsConfigs();

builder.Services.AddApi();

var app = builder.Build();

app.Services.EnsureDatabaseCreated();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddRoutes();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
