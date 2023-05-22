using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Application.Features.ToDoTasks.Queries.GetAllToDoTasks;
using ToDoApp.Application.Features.ToDoTasks.Commands.SaveToDoTask;
using ToDoApp.Application.Features.ToDoTasks.Commands.DeleteToDoTask;
using ToDoApp.Application.Features.ToDoTasks.Commands.UpdateToDoTask;

namespace ToDoApp.Api.Routes;

public static class Routes
{
    private static string BaseRoute = "api/task";

    public static void AddRoutes(this WebApplication app)
    {
        app.MapGet(BaseRoute, async ([FromServices] IMediator mediator) =>
        {
            var tasks = await mediator.Send(new GetAllToDoTasksQuery());
            return Results.Ok(tasks);
        });

        app.MapPost(BaseRoute, async (
            [FromBody] SaveToDoTaskCommand taskToSave,
            [FromServices] IMediator mediator
        ) =>
        {
            var savedTask = await mediator.Send(taskToSave);
            return Results.Ok(savedTask);
        });

        app.MapDelete($"{BaseRoute}/{{taskId}}", async (
            [FromRoute] int taskId,
            [FromServices] IMediator mediator
        ) =>
        {
            await mediator.Send(new DeleteToDoTaskCommand(taskId));
            return Results.Ok();
        });

        app.MapPut(BaseRoute, async (
            [FromBody] UpdateToDoTaskCommand taskToUpdate,
            [FromServices] IMediator mediator
        ) =>
        {
            var updatedTask = await mediator.Send(taskToUpdate);
            return Results.Ok(updatedTask);
        });
    }
}
