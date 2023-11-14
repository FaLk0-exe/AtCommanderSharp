using AtCommanderSharp.Data.Models.Tasks;
using AtCommanderSharp.Patterns.Scheduling.Builders;

namespace AtCommanderSharp.Interfaces;

public interface ITaskSchedulerClient
{
    Task CreateTaskAsync(ISchedulerTaskBuilder schedulerTaskBuilder);

    Task CreateTaskAsync(IEnumerable<ScheduledTaskData> scheduledTasks);

    Task CreateTaskAsync(ScheduledTaskData scheduledTaskData);
    Task CreateTaskAsync(params ScheduledTaskData[] scheduledTaskDatas);
}