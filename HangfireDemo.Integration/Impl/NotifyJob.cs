using System.Threading;
using System.Threading.Tasks;

using Hangfire.Console;
using Hangfire.Server;
using HangfireDemo.Model;
using HangfireDemo.Services;

namespace HangfireDemo.Integration
{
    public class NotifyJob : INotifyJob
    {
        private readonly IJobManager jobManager;
        private readonly IDateService dateService;

        public NotifyJob(IJobManager jobManager, IDateService dateService)
        {
            this.jobManager = jobManager;
            this.dateService = dateService;
        }

        public Task<bool> NotifyAsync(TaskInpuModel inputModel, PerformContext context)
        {
            context.WriteLine("**** -------------------- Notifying Task -------------------- ****");

            if (inputModel == null || inputModel?.Id == 0)
            {
                var jobId = context.BackgroundJob.Id;
                var result = jobManager.CancelJob(jobId);

                context.WriteLine(ConsoleTextColor.Red, $"Job {jobId} has been canceled.");
                context.WriteLine("**** ----------------------------------------------------- ****");

                return Task.FromResult(result);
            }

            // Fake work
            Thread.Sleep(500);

            var now = dateService.GetNow();
            context.WriteLine("Notifying of successful execution...");
            context.WriteLine($"Date: {now}");
            context.WriteLine($"Task ID: {inputModel.Id}");

            if (inputModel.Tags != null)
            {
                var tags = string.Join(",", inputModel.Tags);
                context.WriteLine($"Tags: {tags}");
            }

            context.WriteLine();
            context.WriteLine("**** ----------------------------------------------------- ****");
            return Task.FromResult(true);
        }

        public bool Notify(TaskInpuModel inputModel, PerformContext context)
        {
            return NotifyAsync(inputModel, context).Result;
        }
    }
}
