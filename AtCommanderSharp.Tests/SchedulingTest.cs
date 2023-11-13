using AtCommanderSharp.Patterns.Scheduling.Builders;

namespace AtCommanderSharp.Tests;

public class SchedulingTest
{
    private readonly string _schedulerTaskBuilderResult = "echo \"Hello world1\" | at $(date -d '2023-01-01 12:00' " +
                                                         "'+%H:%M %m/%d/%Y');echo \"Hello world2\" | at $(date -d " +
                                                         "'2023-01-02 12:00' '+%H:%M %m/%d/%Y');";
    [Fact]
    public void SchedulerTaskBuilderReturnsRightString()
    {
        var schedulerTaskBuilder = new SchedulerTaskBuilder(0);
        schedulerTaskBuilder
            .AddCommand("echo \"Hello world1\"", new DateTime(2023, 1, 1, 12, 0, 0))
            .AddCommand("echo \"Hello world2\"", new DateTime(2023, 1, 2, 12, 0, 0));
        Assert.Equal(_schedulerTaskBuilderResult,schedulerTaskBuilder.Build());
    }
}