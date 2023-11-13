using System.Runtime.InteropServices.JavaScript;
using AtCommanderSharp.Data.Models.Tasks;
using FluentValidation;

namespace AtCommanderSharp.Validators;

public class ScheduledTaskDataValidator : AbstractValidator<ScheduledTaskData>
{
    public ScheduledTaskDataValidator()
    {
        RuleFor(task => task.Command)
            .NotEmpty()
            .WithMessage("Command should be not empty")
            .NotNull()
            .WithMessage("Command should be not null");
    }
}