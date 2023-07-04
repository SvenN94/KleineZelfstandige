using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SqlServerData.Business;
using SqlServerData.Models;

namespace SqlServerData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoodleController : Controller
    {
        [HttpGet]// localhost:/doodle
        public ActionResult GetDoodleInfo()
        {
            string jsonResult;
            var dt = Doodles.GetDoodleDataTable(); // GET doodles
            jsonResult = JsonConvert.SerializeObject(dt);
            return Ok(jsonResult);
        }

        [HttpPost]
        public ActionResult<Doodle> AddDoodle(Doodle doodle)
        {
            var s =Doodles.AddDoodle(doodle);
            return Ok(s);
        }

        [HttpPut] // api/Persoon/update
        public ActionResult<Doodle> AlterDoodle(Doodle doodle) // login object meegeven
        {
            var s = Doodles.AlterDoodle(doodle);
            return Ok(s);
        }
        [HttpDelete]
        public ActionResult<Doodle> DeleteDoodle(Doodle doodle)
        {
            var s = Doodles.DeleteDoodle(doodle);
            return Ok(s);
        }
    }
}
