using System.ComponentModel;
using System.Threading.Tasks;

using Hangfire.Server;

using HangfireDemo.Model;

namespace HangfireDemo.Integration
{
    public interface ITaskJob
    {
        [DisplayName("Task {0} - Running")]
        Task<bool> RunAsync(TaskInpuModel inputModel, PerformContext context);

        [DisplayName("Task {0} - Running")]
        bool Run(TaskInpuModel inputModel, PerformContext context);
    }
}
