using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GraduateWorkUdovychenko.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }



        [Route("/route/lessonds")]
        [Authorize]
        public IActionResult Lessonds()
        {
            return View();
        }




        [Route("/route")]
        public IActionResult Index()
        {
            return View();
        }
    }
}