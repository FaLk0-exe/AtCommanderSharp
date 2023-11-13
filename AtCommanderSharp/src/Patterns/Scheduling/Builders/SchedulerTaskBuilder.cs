using System.Text;
using AtCommanderSharp.Interfaces;

namespace AtCommanderSharp.Patterns.Scheduling.Builders;

public class SchedulerTaskBuilder:ISchedulerTaskBuilder
{
    private StringBuilder _commandStringBuilder;
    private Random _delayRandom;
    private int _maxValueOfDelay;
    private static readonly string _commandPattern = "{0} | at $(date -d '{1}' '+%H:%M %m/%d/%Y');";
    public SchedulerTaskBuilder(int maxValueOfDelay=0)
    {
        if (maxValueOfDelay < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maxValueOfDelay), "Max value of delay should be greater than 0");
        }
        _commandStringBuilder = new StringBuilder();
        _delayRandom = new Random();
        _maxValueOfDelay = maxValueOfDelay;
    }

    public SchedulerTaskBuilder AddCommand(string command, DateTime taskExecutionDateTime)
    {
        int delay = _delayRandom.Next(0, _maxValueOfDelay);
        
        var delayedTaskExecutionDateTime = taskExecutionDateTime
            .AddSeconds(delay)
            .ToString("yyyy-MM-dd HH:mm");

        var singleCommand = string.Format(_commandPattern, command, delayedTaskExecutionDateTime);
        
        _commandStringBuilder.Append(singleCommand);
        return this;
    }

    public string Build()
    {   
        return _commandStringBuilder.ToString();
    }
}