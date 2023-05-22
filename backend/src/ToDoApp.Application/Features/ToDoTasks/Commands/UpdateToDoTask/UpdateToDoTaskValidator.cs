using FluentValidation;

namespace ToDoApp.Application.Features.ToDoTasks.Commands.UpdateToDoTask;

public class UpdateToDoTaskValidator : AbstractValidator<UpdateToDoTaskCommand>
{
    public UpdateToDoTaskValidator()
    {
        RuleFor(p => p.Description)
            .NotNull()
            .NotEmpty().WithMessage("A descrição da tarefa é obrigatória");

        RuleFor(p => p.IsFinished)
            .NotNull().WithMessage("O status da tarefa é obrigatório");
    }
}
