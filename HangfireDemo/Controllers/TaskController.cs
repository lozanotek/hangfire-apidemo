using System.Web.Http;

using HangfireDemo.Integration;
using HangfireDemo.Model;

namespace HangfireDemo.Controllers
{
    [RoutePrefix("task")]
    public class TaskController : ApiController
    {
        private readonly ITaskJobManager jobManager;

        public TaskController(ITaskJobManager jobManager)
        {
            this.jobManager = jobManager;
        }

        [HttpPost, Route("process")]
        public IHttpActionResult Process(TaskInpuModel inputModel)
        {
            var jobId = jobManager.ProcessTask(inputModel);
            return Ok(jobId);
        }

        [HttpPost, Route("notify")]
        public IHttpActionResult Notify(TaskInpuModel inputModel)
        {
            var jobId = jobManager.NotifyTask(inputModel);
            return Ok(jobId);
        }

        [HttpPost, Route("run")]
        public IHttpActionResult Run(TaskInpuModel inputModel)
        {
            var jobId = jobManager.RunTask(inputModel);
            return Ok(jobId);
        }
    }
}
