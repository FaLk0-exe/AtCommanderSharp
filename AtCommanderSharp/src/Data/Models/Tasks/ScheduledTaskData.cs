namespace AtCommanderSharp.Data.Models.Tasks;

public class ScheduledTaskData
{
    public string Command { get; private set; }
    public DateTime ExecutionDate { get; private set; }

    public ScheduledTaskData(string command, DateTime executionDate)
    {
        Command = command;
        ExecutionDate = executionDate;
    }
    
}