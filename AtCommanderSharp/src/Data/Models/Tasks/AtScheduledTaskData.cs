namespace AtCommanderSharp.Data.Models.Tasks;

public class AtScheduledTaskData
{
    public string Command { get; private set; }
    public DateTime ExecutionDate { get; private set; }

    public AtScheduledTaskData(string command, DateTime executionDate)
    {
        Command = command;
        ExecutionDate = executionDate;
    }
    
}