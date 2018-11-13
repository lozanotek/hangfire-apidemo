using System.Threading.Tasks;
using Hangfire.Console;
using Hangfire.Server;
using HangfireDemo.Services;

namespace HangfireDemo.Integration
{
    public class IntervalJob : IIntervalJob
    {
        private readonly IDateService dateService;

        public IntervalJob(IDateService dateService)
        {
            this.dateService = dateService;
        }

        public Task<bool> CheckPingAsync(PerformContext context)
        {
            context.WriteLine("**** -------------------- Check Ping -------------------- ****");

            var now = dateService.GetNow();
            context.WriteLine($"Current Date: {now}");

            context.WriteLine();
            context.WriteLine("**** ---------------------------------------------------- ****");

            // Since we don't have any async code, we fake the return
            return Task.FromResult(true);
        }

        public bool CheckPing(PerformContext context)
        {
            return CheckPingAsync(context).Result;
        }
    }
}
