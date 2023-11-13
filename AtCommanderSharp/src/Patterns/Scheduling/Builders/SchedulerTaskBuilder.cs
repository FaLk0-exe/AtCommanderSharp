using System.Text;

namespace AtCommanderSharp.Patterns.Scheduling.Builders;

public class SchedulerTaskBuilder
{
    private StringBuilder _commandStringBuilder;
    private Random _delayRandom;
    private int _maxValueOfDelay;
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
        var singleCommand = $"{command} | at $(date -d '{taskExecutionDateTime.AddSeconds(delay):yyyy-MM-dd HH:mm}' '+%H:%M %m/%d/%Y');";
        _commandStringBuilder.Append(singleCommand);
        return this;
    }

    public string Build()
    {   
        return _commandStringBuilder.ToString();
    }
}