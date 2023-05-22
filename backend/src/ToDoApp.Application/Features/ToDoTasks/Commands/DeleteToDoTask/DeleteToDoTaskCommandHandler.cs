using AutoMapper;
using MediatR;
using ToDoApp.Application.Exceptions;
using ToDoApp.Domain.Interfaces.Repositories;

namespace ToDoApp.Application.Features.ToDoTasks.Commands.DeleteToDoTask;

public class DeleteToDoTaskCommandHandler : IRequestHandler<DeleteToDoTaskCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IToDoTaskRepository _repository;

    public DeleteToDoTaskCommandHandler(IMapper mapper, IToDoTaskRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteToDoTaskCommand request, CancellationToken cancellationToken)
    {
        // Validation
        var taskExists = (await _repository.GetTaskById(request.Id)) != null;
        if (!taskExists)
            throw new NotFoundException($"Tarefa com id {request.Id} não foi encontrada");

        // Result
        await _repository.DeleteToDoTaskAsync(request.Id);

        return Unit.Value;
    }
}