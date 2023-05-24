using GraduateWorkUdovychenko.Domain.Models;
using GraduateWorkUdovychenko.Domain.ViewModels;
using GraduateWorkUdovychenko.Services.MyUser;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;

namespace GraduateWorkUdovychenko.Controllers.Authorization
{
    public class RegistrationController : Controller
    {
        private IUserRepository userRepository;

        public RegistrationController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [Route("/registration")]
        [HttpGet]
        public IActionResult Registration()
        {
            return View("~/Views/Authorization/Registration.cshtml");
        }

        [Route("/registration")]
        [HttpPost]
        public IActionResult Registration(RegViewModel user)
        {
            JwtBearerDefaults.AuthenticationScheme.GetEnumerator();
            if (ModelState.IsValid)
            {
                user.Email.ToLower();

                userRepository.Create(new User
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    Email = user.Email,
                    Password = user.Password,
                    Role = 0
                });

                return RedirectToAction("Index", "Home");
            }
            return View("~/Views/Authorization/Registration.cshtml");
        }
    }
}



