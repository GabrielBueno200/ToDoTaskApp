using AutoMapper;
using MediatR;
using ToDoApp.Application.ViewModels;
using ToDoApp.Domain.Interfaces.Repositories;

namespace ToDoApp.Application.Features.ToDoTasks.Queries.GetAllToDoTasks;

public class GetAllToDoTasksQueryHandler : IRequestHandler<GetAllToDoTasksQuery,
    IList<ToDoTaskViewModel>>
{
    private readonly IMapper _mapper;
    private readonly IToDoTaskRepository _repository;

    public GetAllToDoTasksQueryHandler(IMapper mapper, IToDoTaskRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<IList<ToDoTaskViewModel>> Handle(GetAllToDoTasksQuery request, CancellationToken cancellationToken)
    {
        var classes = await _repository.GetAllToDoTasksAsync();

        var mappedTasks = _mapper.Map<IList<ToDoTaskViewModel>>(classes);

        return mappedTasks;
    }
}