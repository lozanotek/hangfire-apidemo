using System.Threading;
using System.Threading.Tasks;

using Hangfire.Console;
using Hangfire.Server;

using HangfireDemo.Model;
using HangfireDemo.Services;

namespace HangfireDemo.Integration
{
    public class TaskJob : ITaskJob
    {
        private readonly IDateService dateService;
        private readonly IJobManager jobManager;

        public TaskJob(IDateService dateService, IJobManager jobManager)
        {
            this.dateService = dateService;
            this.jobManager = jobManager;
        }

        public Task<bool> RunAsync(TaskInpuModel inputModel, PerformContext context)
        {
            context.WriteLine("**** -------------------- Running Task -------------------- ****");

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

        public bool Run(TaskInpuModel inputModel, PerformContext context)
        {
            return RunAsync(inputModel, context).Result;
        }
    }
}
