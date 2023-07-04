using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SqlServerData.Business;
using SqlServerData.Models;
using System;

namespace SqlServerData.Controllers

   
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class KlantController : Controller
    {
        [HttpGet]// localhost:/Klant
        public ActionResult GetKlantenInfo()
        {
            string jsonResult;
            var dt = Klanten.GetKlantenDataTable(); // GET producten
            jsonResult = JsonConvert.SerializeObject(dt);
            return Ok(jsonResult);
        }

        [HttpPost]
        public ActionResult<Klant> AddKlant(Klant klant)
        {
            var s = Klanten.AddKlant(klant);
            return Ok(s);
        }

        [HttpPut] // api/Klant
        public ActionResult<Klant> AlterKlant(Klant klant) 
        {
            var s = Klanten.AlterKlant(klant);
            return Ok(s);
        }
        [HttpDelete]
        public ActionResult<Klant>DeleteKlant(Klant klant)
        {
            var s = Klanten.DeleteKlant(klant);
                return Ok(s);
        }
    }
}
