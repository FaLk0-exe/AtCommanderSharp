using System.Text;
using AtCommanderSharp.Data.Models.Tasks;
using AtCommanderSharp.Interfaces;

namespace AtCommanderSharp.Patterns.Scheduling.Builders;

public class SchedulerTaskBuilder:ISchedulerTaskBuilder
{
    private StringBuilder _commandStringBuilder;
    private Random _delayRandom;
    private static readonly string _commandPattern = "{0} | at $(date -d '{1}' '+%H:%M %m/%d/%Y');";
    
    public SchedulerTaskBuilder()
    {
        _commandStringBuilder = new StringBuilder();
        _delayRandom = new Random();
    }

    public SchedulerTaskBuilder AddCommand(ScheduledTaskData scheduledTaskData)
    {
        
        var taskExecutionDateTimeString = scheduledTaskData.ExecutionDate
            .ToString("yyyy-MM-dd HH:mm");

        var singleCommand = string.Format(_commandPattern, scheduledTaskData.Command, taskExecutionDateTimeString);
        
        _commandStringBuilder.Append(singleCommand);
        return this;
    }

    public string Build()
    {   
        return _commandStringBuilder.ToString();
    }
}