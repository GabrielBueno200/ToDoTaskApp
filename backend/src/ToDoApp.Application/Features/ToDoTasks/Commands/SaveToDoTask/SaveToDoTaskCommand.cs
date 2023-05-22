using MediatR;
using ToDoApp.Application.ViewModels;

namespace ToDoApp.Application.Features.ToDoTasks.Commands.SaveToDoTask;

public record SaveToDoTaskCommand(string Description) : IRequest<ToDoTaskViewModel>;

