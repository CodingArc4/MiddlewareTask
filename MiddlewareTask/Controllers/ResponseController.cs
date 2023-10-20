using Microsoft.AspNetCore.Mvc;
using MiddlewareTask.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MiddlewareTask.Controllers
{
    public class ResponseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Response/GetPerson")]
        public JsonResult GetPerson()
        {
            Person person = new Person()
            {
                Name = "Munib Khan",
                Designation = ".net developer",
                Company = "JMM Technologies"
            };

            return Json(person);
        }
    }
}
