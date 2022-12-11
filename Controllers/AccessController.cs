using Microsoft.AspNetCore.Mvc;

namespace MVC_Roles.Controllers
{
    public class AccessController : Controller
    {
        [Route("/Start")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
