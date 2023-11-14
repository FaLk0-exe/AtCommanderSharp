using AtCommanderSharp.Data.Models.Tasks;
using AtCommanderSharp.Patterns.Scheduling.Builders;

namespace AtCommanderSharp.Interfaces;

public interface ITaskSchedulerClient
{
    Task CreateTaskAsync(SchedulerTaskBuilder schedulerTaskBuilder, CancellationToken cancellationToken);

    Task CreateTaskAsync(IEnumerable<ScheduledTaskData> scheduledTasks,
        CancellationToken cancellationToken);

    Task CreateTaskAsync(ScheduledTaskData scheduledTaskData, CancellationToken cancellationToken);
    Task CreateTaskAsync(CancellationToken cancellationToken, params ScheduledTaskData[] scheduledTaskDatas);
}