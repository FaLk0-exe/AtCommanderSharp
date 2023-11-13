// See https://aka.ms/new-console-template for more information

using AtCommanderSharp.Data.Models.Tasks;
using AtCommanderSharp.Validators;
using FluentValidation;

var task = new ScheduledTaskData(null,DateTime.Now);
new ScheduledTaskDataValidator().ValidateAndThrow(task);