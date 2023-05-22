using FluentValidation;

namespace ToDoApp.Application.Features.ToDoTasks.Commands.UpdateToDoTask;

public class UpdateToDoTaskValidator : AbstractValidator<UpdateToDoTaskCommand>
{
    public UpdateToDoTaskValidator()
    {
        RuleFor(p => p.Description)
            .NotNull()
            .NotEmpty().WithMessage("Task description is required");

        RuleFor(p => p.IsFinished)
            .NotNull().WithMessage("Task status is required");
    }
}
