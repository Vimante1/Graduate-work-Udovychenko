using GraduateWorkUdovychenko.Domain.Models;
using GraduateWorkUdovychenko.Domain.ViewModels;
using GraduateWorkUdovychenko.Services.MyUser;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace GraduateWorkUdovychenko.Controllers.Authorization
{
    public class RegistrationController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private IUserRepository userRepository;
        private readonly JWTSettings _options;

        public RegistrationController(IUserRepository userRepository, IOptions<JWTSettings> options) 
        {
            this.userRepository = userRepository;
            _options = options.Value;
        }


        [Route("/route/registration")]
        [HttpGet]
        public IActionResult Registration()
        {
            return View("~/Views/Authorization/Registration.cshtml");
        }

         
        [Route("/route/registration")]
        [HttpPost]
        public IActionResult Registration(RegViewModel user)
        {
            JwtBearerDefaults.AuthenticationScheme.GetEnumerator();
            if (ModelState.IsValid)
            {

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



