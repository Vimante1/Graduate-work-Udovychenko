using GraduateWorkUdovychenko.Domain.Models;
using GraduateWorkUdovychenko.Domain.ViewModels;
using GraduateWorkUdovychenko.Services.MyUser;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GraduateWorkUdovychenko.Controllers.Authorization
{
    public class AuthorizationController : Controller
    {
        IUserRepository _userRepository;
        private readonly JWTSettings _options;


        public AuthorizationController(IUserRepository userRepository, IOptions<JWTSettings> options)
        {
            _options = options.Value;
            _userRepository = userRepository;
        }

        [Route("/authorization")]
        public IActionResult Authorization()
        {
            return View();
        }

        [Route("/authorization")]
        [HttpPost]
        public IActionResult Authorization(AuthViewModel user)
        {
            if (ModelState.IsValid)
            {
                user.Email = user.Email.ToLower();

                var MyUser = _userRepository.Correct(user);
                if (MyUser != null)
                {
                    object a = GetToken(MyUser);
                    return View(a);
                }
            }
            return View();

        }


        public string GetToken(User user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            claims.Add(new Claim(ClaimTypes.Name, user.Name));
            claims.Add(new Claim(ClaimTypes.Role, user.Role.ToString()));
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));

            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(120)),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);

        }
    }
}
