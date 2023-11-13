using AtCommanderSharp.Data.Models.Tasks;
using AtCommanderSharp.Patterns.Scheduling.Builders;
using AtCommanderSharp.Validators;
using FluentValidation;

namespace AtCommanderSharp.Tests;

public class ValidationTest
{
    [Fact] 
    public void InvalidScheduleTaskDataThrowsException()
    {
        Assert.Throws<ValidationException>(() =>
        {
            var task = new ScheduledTaskData(null, DateTime.Now);
            new ScheduledTaskDataValidator().ValidateAndThrow(task);      
        });
    }

    [Fact]
    public void ValidScheduleTaskDataDontThrowsException()
    {
        var task = new ScheduledTaskData("echo \"Hello world\"", DateTime.Now);
        new ScheduledTaskDataValidator().ValidateAndThrow(task);
        Assert.True(true);
    }

    [Fact]
    public void SchedulerTaskBuilder_ThrowsException_WhereArgumentLessThanZero()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var schedulerTaskBuilder = new SchedulerTaskBuilder(-1);
        });
    }
}
