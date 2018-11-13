using Hangfire;
using Hangfire.States;

using HangfireDemo.Model;

namespace HangfireDemo.Integration
{
    public class TaskJobManager : ITaskJobManager
    {
        private readonly IBackgroundJobClient jobClient;

        public TaskJobManager(IBackgroundJobClient jobClient)
        {
            this.jobClient = jobClient;
        }

        public string ProcessTask(TaskInpuModel inputModel)
        {
            var state = new EnqueuedState(JobQueues.Task);
            var jobId = jobClient.Create<ITaskJob>(job => job.Run(inputModel, null), state);

            state = new EnqueuedState(JobQueues.Notify);
            jobId = jobClient.ContinueWith<INotifyJob>(jobId, job => job.Notify(inputModel, null), state);

            return jobId;
        }

        public string NotifyTask(TaskInpuModel inputModel)
        {
            var state = new EnqueuedState(JobQueues.Notify);
            var jobId = jobClient.Create<INotifyJob>(job => job.Notify(inputModel, null), state);

            return jobId;
        }

        public string RunTask(TaskInpuModel inputModel)
        {
            var state = new EnqueuedState(JobQueues.Task);
            var jobId = jobClient.Create<ITaskJob>(job => job.Run(inputModel, null), state);

            return jobId;
        }
    }
}
