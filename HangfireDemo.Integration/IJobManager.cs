namespace HangfireDemo.Integration
{
    public interface IJobManager
    {
        bool CancelJob(string jobId);
    }
}
