using GraduateWorkUdovychenko.Services.QuizService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraduateWorkUdovychenko.Controllers
{
    public class LessondsController : Controller
    {
        IQuizRepository _QuizRepository { get; set; }

        public LessondsController(IQuizRepository quizRepository)
        {
            _QuizRepository = quizRepository;
        }

        [Route("/lessonds")]
        [Authorize]
        public IActionResult Lessonds()
        {
            // _QuizRepository.TestCreate();
            return View(_QuizRepository.GetAll());
        }

        [Route("/lessonds/task")]
        [Authorize]
        public IActionResult Task(string id)
        {
            var task = _QuizRepository.GetById(id);
            return View("Task", task);
        }
    }
}
