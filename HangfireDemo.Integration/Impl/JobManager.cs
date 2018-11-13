using Hangfire;

namespace HangfireDemo.Integration
{
    public class JobManager : IJobManager
    {
        private readonly IBackgroundJobClient jobClient;

        public JobManager(IBackgroundJobClient jobClient)
        {
            this.jobClient = jobClient;
        }

        public bool CancelJob(string jobId)
        {
            var result = jobClient.Delete(jobId);
            return result;
        }
    }
}
