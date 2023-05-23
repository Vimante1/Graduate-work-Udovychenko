using GraduateWorkUdovychenko.Domain.Models.Quiz;
using GraduateWorkUdovychenko.Domain.ViewModels;
using GraduateWorkUdovychenko.Services.QuizService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraduateWorkUdovychenko.Controllers
{
    public class AdminPanelController : Controller
    {
        IQuizRepository _quizRepository { get; set; }
        public AdminPanelController(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        [Authorize("admin")]
        [Route("adminpanel")]
        public IActionResult AdminPanel()
        {
            return View();
        }

        public IActionResult CreateNewTest()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Submit(CreateQuizViewModel completedQuiz)
        {
            _quizRepository.Create(completedQuiz);
            return View();
        }
        

    }
}
