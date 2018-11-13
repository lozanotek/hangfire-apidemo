using HangfireDemo.Model;

namespace HangfireDemo.Integration
{
    public interface ITaskJobManager
    {
        string ProcessTask(TaskInpuModel inputModel);
        string NotifyTask(TaskInpuModel inputModel);
        string RunTask(TaskInpuModel inputModel);
    }
}
