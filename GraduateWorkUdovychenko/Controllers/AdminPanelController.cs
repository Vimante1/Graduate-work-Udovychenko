using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraduateWorkUdovychenko.Controllers
{
    public class AdminPanelController : Controller
    {
        [Authorize("admin")]
        [Route("adminpanel")]
        public IActionResult AdminPanel()
        {
            return View();
        }
    }
}
