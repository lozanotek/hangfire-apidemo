using Hangfire;
using Hangfire.Console;
using Hangfire.MemoryStorage;

using HangfireDemo.Integration;

using Ninject;
using Owin;

namespace HangfireDemo
{
    public static class HangfireConfig
    {
        public static void ConfigureHangfire(this IAppBuilder app, IKernel kernel = null)
        {
            var configuration = GlobalConfiguration.Configuration;

            configuration.UseMemoryStorage();
            configuration
                .UseConsole()
                .UseNinjectActivator(kernel);

            var jobServerOptions = new BackgroundJobServerOptions
            {
                ServerName = "HangfireDemo",
                Queues = JobQueues.All
            };

            app.UseHangfireServer(jobServerOptions);

            var dashboardOptions = new DashboardOptions
            {
                Authorization = new[] { new AllowAllAuthorizationFilter() }
            };

            app.UseHangfireDashboard("/integration", dashboardOptions);

            // Recurring Jobs
            RecurringJob.AddOrUpdate<IIntervalJob>(job => job.CheckPing(null), Cron.Minutely, queue: JobQueues.Recurring);
        }
    }
}
