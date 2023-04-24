using GraduateWorkUdovychenko.Services.QuizService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraduateWorkUdovychenko.Controllers
{
    public class UserPanelController : Controller
    {
        ICompletedQuizRepository _completedQuizRepository;

        public UserPanelController(ICompletedQuizRepository completedQuizRepository)
        {
            _completedQuizRepository = completedQuizRepository;
        }

        [Route("userpanel")]
        [Authorize]
        public IActionResult UserPanel()
        {
            var UserMail = User.Claims.First().Value;
            var UserCompleted = _completedQuizRepository.GetAllForUser(UserMail);
            return View(UserCompleted);
        }
    }
}
