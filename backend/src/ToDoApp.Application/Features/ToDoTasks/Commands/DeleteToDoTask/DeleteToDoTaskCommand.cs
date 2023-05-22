using MediatR;

namespace ToDoApp.Application.Features.ToDoTasks.Commands.DeleteToDoTask;

public record DeleteToDoTaskCommand(int Id) : IRequest<Unit>;