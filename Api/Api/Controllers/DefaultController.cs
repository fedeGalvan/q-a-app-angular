using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class DefaultController : Controller
    {

        [HttpGet("api/[controller]")]
        public string Get()
        {
            return "App running";
        }

    }
}
