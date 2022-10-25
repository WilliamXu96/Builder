using Microsoft.AspNetCore.Mvc;

namespace Business.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}
