// See https://aka.ms/new-console-template for more information

using AtCommanderSharp.Data.Models.Tasks;
using AtCommanderSharp.Validators;
using FluentValidation;

var task = new AtScheduledTaskData(null,DateTime.Now);
new AtScheduledTaskDataValidator().ValidateAndThrow(task);