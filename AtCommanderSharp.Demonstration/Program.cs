// See https://aka.ms/new-console-template for more information

using System.Threading.Channels;
using AtCommanderSharp.Data.Models.Tasks;
using AtCommanderSharp.Patterns.Scheduling.Builders;
using AtCommanderSharp.Validators;
using FluentValidation;

var task = new ScheduledTaskData("echo \"Hello World\"",DateTime.Now);
var task1 = new ScheduledTaskData("echo \"Hello World1\"",DateTime.Now);

var builder = new SchedulerTaskBuilder();
builder.AddCommand(task)
    .AddCommand(task1);
Console.WriteLine(builder.Build());