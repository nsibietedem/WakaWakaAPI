using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WakaWakaApi.Controllers
{
    //https:localhost:portnumber/api/students/
    [Route("api/[controller]")]
    [ApiController]
    public class Students : ControllerBase
    {
        //GET:https:localhost:portnumber/api/students/
        [HttpGet]
        public IActionResult GetAllStudents() 
        {
            string[] studentName = new string[] { "edem", "abas", "emmana", "akan-imoh" };
            return Ok(studentName);
        }
    }
}
