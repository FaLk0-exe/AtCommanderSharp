using System.Runtime.InteropServices.JavaScript;
using AtCommanderSharp.Data.Models.Tasks;
using FluentValidation;

namespace AtCommanderSharp.Validators;

public class AtScheduledTaskDataValidator : AbstractValidator<AtScheduledTaskData>
{
    public AtScheduledTaskDataValidator()
    {
        RuleFor(task => task.Command)
            .NotEmpty()
            .WithMessage("Command should be not empty")
            .NotNull()
            .WithMessage("Command should be not null");
    }
}