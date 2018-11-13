using System.ComponentModel;
using System.Threading.Tasks;
using Hangfire.Server;

namespace HangfireDemo.Integration
{
    public interface IIntervalJob
    {
        [DisplayName("Check Ping")]
        Task<bool> CheckPingAsync(PerformContext context);

        [DisplayName("Check Ping")]
        bool CheckPing(PerformContext context);
    }
}
