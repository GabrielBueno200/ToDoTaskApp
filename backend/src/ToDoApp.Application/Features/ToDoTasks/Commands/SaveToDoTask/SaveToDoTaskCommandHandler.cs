using AutoMapper;
using MediatR;
using ToDoApp.Application.ViewModels;
using ToDoApp.Domain.Interfaces.Repositories;
using ToDoApp.Domain.Models;
using ToDoTaskApp.Application.Extensions;

namespace ToDoApp.Application.Features.ToDoTasks.Commands.SaveToDoTask;

public class SaveToDoTaskCommandHandler : IRequestHandler<SaveToDoTaskCommand,
    ToDoTaskViewModel>
{
    private readonly IMapper _mapper;
    private readonly IToDoTaskRepository _repository;

    public SaveToDoTaskCommandHandler(IMapper mapper, IToDoTaskRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<ToDoTaskViewModel> Handle(SaveToDoTaskCommand request, CancellationToken cancellationToken)
    {
        // Validation
        var validation = await new SaveToDoTaskCommandValidator().ValidateAsync(request);
        validation.VerifyErrorsAndThrow();

        // Mapping
        var taskToCreate = _mapper.Map<ToDoTask>(request);

        // Result
        var createdTask = await _repository.SaveToDoTaskAsync(taskToCreate);

        var mappedClass = _mapper.Map<ToDoTaskViewModel>(createdTask);

        return mappedClass;
    }
}
