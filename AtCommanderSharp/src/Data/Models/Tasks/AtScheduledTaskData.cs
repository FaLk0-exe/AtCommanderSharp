namespace AtCommanderSharp.Data.Models.Tasks;

public class AtScheduledTaskData
{
    private string _command;
    private DateTime _executionDate;

    public AtScheduledTaskData(string command, DateTime executionDate)
    {
        _command = command;
        _executionDate = executionDate;
    }
}