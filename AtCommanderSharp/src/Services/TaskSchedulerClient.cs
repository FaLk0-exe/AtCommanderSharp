using AtCommanderSharp.Data.Models.Tasks;
using AtCommanderSharp.Interfaces;
using AtCommanderSharp.Patterns.Scheduling.Builders;
using Renci.SshNet;

namespace AtCommanderSharp.Services;

public class TaskSchedulerClient : ITaskSchedulerClient
{
    private SshClient _sshClient;

    public TaskSchedulerClient(SshClient sshClient)
    {
        _sshClient = sshClient;
    }

    public async Task CreateTaskAsync(ISchedulerTaskBuilder schedulerTaskBuilder)
    {
        throw new NotImplementedException();
    }
    
    public async Task CreateTaskAsync(IEnumerable<ScheduledTaskData> scheduledTasks)
    {
        var schedulerTaskBuilder = new SchedulerTaskBuilder();
        
        foreach (var scheduledTaskData in scheduledTasks)
            schedulerTaskBuilder.AddCommand(scheduledTaskData);

        await CreateTaskAsync(schedulerTaskBuilder);
    }

    public async Task CreateTaskAsync(ScheduledTaskData scheduledTaskData)
    {
        await CreateTaskAsync(Enumerable.Repeat(scheduledTaskData, 1));
    }

    public async Task CreateTaskAsync(params ScheduledTaskData[] scheduledTaskDatas)
    {
        await CreateTaskAsync(scheduledTaskDatas);
    }
}