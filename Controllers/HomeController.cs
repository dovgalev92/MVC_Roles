using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Roles.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace MVC_Roles.Controllers
{
    [Route("{controller}")]
    [Authorize(Roles = "Администратор, Пользователь")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        [Route("LoginUser")]
        public IActionResult Index()
        {
            string roles = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            return Content($"Вы вошли как {roles}");

        }
        [Route("Setting")]
        [Authorize(Roles = "Администратор")]
        public IActionResult SettingProgramm()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Route("Info")]
        [Authorize]
        public IActionResult GetInfo()
        {
            return View();
        }
        [Route("Errores")]
        [Authorize(Roles = "Пользователь")]
        public IActionResult GetResultSetting()
        {
            return View();
        }
        [Route("City")]
        [Authorize(Policy = "CityRogachev", Roles = "Пользователь")]
        public IActionResult RogachevCity()
       {
            string city = User.FindFirst(c => c.Type == ClaimTypes.Locality).Value;
            return Content($"Мы рады приветствовать представителей города {city}");
        }
    }
}