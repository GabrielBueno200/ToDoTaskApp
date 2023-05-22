using MediatR;
using ToDoApp.Application.ViewModels;

namespace ToDoApp.Application.Features.ToDoTasks.Queries.GetAllToDoTasks;

public record GetAllToDoTasksQuery : IRequest<IList<ToDoTaskViewModel>>;
