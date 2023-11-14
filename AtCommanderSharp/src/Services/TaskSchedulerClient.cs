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

    public async Task CreateTaskAsync(SchedulerTaskBuilder schedulerTaskBuilder, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    
    public async Task CreateTaskAsync(IEnumerable<ScheduledTaskData> scheduledTasks,
        CancellationToken cancellationToken)
    {
        var schedulerTaskBuilder = new SchedulerTaskBuilder();
        
        foreach (var scheduledTaskData in scheduledTasks)
            schedulerTaskBuilder.AddCommand(scheduledTaskData);

        await CreateTaskAsync(schedulerTaskBuilder, cancellationToken);
    }

    public async Task CreateTaskAsync(ScheduledTaskData scheduledTaskData, CancellationToken cancellationToken)
    {
        await CreateTaskAsync(Enumerable.Repeat(scheduledTaskData, 1), cancellationToken);
    }

    public async Task CreateTaskAsync(CancellationToken cancellationToken, params ScheduledTaskData[] scheduledTaskDatas)
    {
        await CreateTaskAsync(scheduledTaskDatas, cancellationToken);
    }
}