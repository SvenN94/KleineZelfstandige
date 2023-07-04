using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SqlServerData.Business;
using SqlServerData.Models;

namespace SqlServerData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActiviteitController : Controller
    {
        [HttpGet]// localhost:/Activiteit
        public ActionResult GetActiviteitInfo()
        {
            string jsonResult;
            var dt = Activiteiten.GetActiviteitenDataTable(); // GET producten
            jsonResult = JsonConvert.SerializeObject(dt);
            return Ok(jsonResult);
        }

        [HttpPost]
        public ActionResult<Activiteit> AddKlant(Activiteit activiteit)
        {
            var s = Activiteiten.AddActiviteit(activiteit);
            return Ok(s);
        }

        [HttpPut] // api/Persoon/update
        public ActionResult<Activiteit> alterKlant(Activiteit activiteit) // login object meegeven
        {
            var s = Activiteiten.AlterActiviteit(activiteit);
            return Ok(s);
        }
        [HttpDelete]
        public ActionResult Delete(Activiteit activiteit)
        {
            var s = Activiteiten.DeleteActiviteit(activiteit);
            return Ok(s);
        }
    }
}
