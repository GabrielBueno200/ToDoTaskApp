using FluentValidation;

namespace ToDoApp.Application.Features.ToDoTasks.Commands.SaveToDoTask;

public class SaveToDoTaskCommandValidator : AbstractValidator<SaveToDoTaskCommand>
{
    public SaveToDoTaskCommandValidator()
    {
        RuleFor(p => p.Description)
            .NotNull()
            .NotEmpty().WithMessage("A descrição da tarefa é obrigatória");
    }
}
