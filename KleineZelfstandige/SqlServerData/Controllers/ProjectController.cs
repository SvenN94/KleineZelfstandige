using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SqlServerData.Business;
using SqlServerData.Models;

namespace SqlServerData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : Controller
    {

        [HttpGet]// localhost:/Project
        public ActionResult GetProjectInfo()
        {
            string jsonResult;
            var dt = Projecten.GetProjectenDataTable(); // GET producten
            jsonResult = JsonConvert.SerializeObject(dt);
            return Ok(jsonResult);
        }

        [HttpPost]
        public ActionResult<Project> AddProject(Project project)
        {
            var s = Projecten.AddProject(project);
            return Ok(s);
        }

        [HttpPut] // api/Persoon/update
        public ActionResult<Project> alterProject(Project project) // login object meegeven
        {
            var s = Projecten.AlterProject(project);
            return Ok(s);
        }
        [HttpDelete]
        public ActionResult DeleteProject(Project project)
        {
            var s = Projecten.DeleteProject(project);
            return Ok(s);
        }
    }
}
