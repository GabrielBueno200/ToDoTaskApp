using AutoMapper;
using MediatR;
using ToDoApp.Application.Exceptions;
using ToDoApp.Domain.Interfaces.Repositories;
using ToDoApp.Domain.Models;
using ToDoTaskApp.Application.Extensions;

namespace ToDoApp.Application.Features.ToDoTasks.Commands.UpdateToDoTask;

public class UpdateToDoTaskCommandHandler : IRequestHandler<UpdateToDoTaskCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IToDoTaskRepository _repository;

    public UpdateToDoTaskCommandHandler(IMapper mapper, IToDoTaskRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateToDoTaskCommand request, CancellationToken cancellationToken)
    {
        // Validation
        var validation = await new UpdateToDoTaskValidator().ValidateAsync(request);
        validation.VerifyErrorsAndThrow();

        var taskExists = (await _repository.GetTaskById(request.Id)) != null;
        if (!taskExists)
            throw new NotFoundException($"Tarefa com id {request.Id} não foi encontrada");

        // Mapping
        var taskToUpdate = _mapper.Map<ToDoTask>(request);

        // Result
        await _repository.UpdateToDoTask(taskToUpdate);

        return Unit.Value;
    }
}