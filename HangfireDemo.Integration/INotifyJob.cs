using System.ComponentModel;
using System.Threading.Tasks;

using Hangfire.Server;

using HangfireDemo.Model;

namespace HangfireDemo.Integration
{
    public interface INotifyJob
    {
        [DisplayName("Task {0} - Notifying")]
        Task<bool> NotifyAsync(TaskInpuModel inputModel, PerformContext context);

        [DisplayName("Task {0} - Notifying")]
        bool Notify(TaskInpuModel inputModel, PerformContext context);
    }
}
