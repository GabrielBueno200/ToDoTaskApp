using MediatR;

namespace ToDoApp.Application.Features.ToDoTasks.Commands.UpdateToDoTask;

public record UpdateToDoTaskCommand(int Id, string Description, bool IsFinished)
    : IRequest<Unit>;
