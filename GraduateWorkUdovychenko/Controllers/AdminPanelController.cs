using GraduateWorkUdovychenko.Domain.ViewModels;
using GraduateWorkUdovychenko.Services.QuizService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraduateWorkUdovychenko.Controllers
{
    [Authorize("admin")]
    
    public class AdminPanelController : Controller
    {
        ICompletedQuizRepository _completedQuizRepository { get; set; }
        IQuizRepository _quizRepository { get; set; }
        public AdminPanelController(IQuizRepository quizRepository, ICompletedQuizRepository completedQuizRepository)
        {
            _quizRepository = quizRepository;
            _completedQuizRepository = completedQuizRepository;
        }
        [Route("adminpanel")]
        public IActionResult AdminPanel()
        {
            return View(_completedQuizRepository.GetAll());
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

        [Route("/AdminPanel/Evaluation")]
        public IActionResult Evaluation(string id)
        {
            var request = _completedQuizRepository.GetById(id);
            return View(request);
        }
     
        public IActionResult SubmitEvaluation(CreateQuizViewModel completedQuiz)
        {
            var correct = _completedQuizRepository.GetById(completedQuiz._id);
            for (int i = 0; i< correct.Tasks.Count; i++)
            {
                correct.Tasks[i].TaskRating = completedQuiz.Tasks[i].TaskRating;
            }
            correct.SummaryRating(correct);
            _completedQuizRepository.UpdateById(correct);

            return RedirectToAction("AdminPanel");
        }

    }
}
