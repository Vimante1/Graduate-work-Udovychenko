using GraduateWorkUdovychenko.Domain.Models.Quiz;
using GraduateWorkUdovychenko.Domain.ViewModels;
using GraduateWorkUdovychenko.Services.QuizService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.RegularExpressions;

namespace GraduateWorkUdovychenko.Controllers
{
    public class LessondsController : Controller
    {
        IQuizRepository _QuizRepository { get; set; }
        ICompletedQuizRepository _completedQuizRepository { get; set; }
        public LessondsController(IQuizRepository quizRepository, ICompletedQuizRepository completedQuizRepository)
        {
            _completedQuizRepository = completedQuizRepository;
            _QuizRepository = quizRepository;
        }

        [Route("/lessonds")]
        [Authorize]
        public IActionResult Lessonds()
        {
            //_QuizRepository.TestCreate();
            return View(_QuizRepository.GetAll());
        }

        [Route("/lessonds/task")]
        [Authorize]
        public IActionResult Task(string id)
        {
            var Task = _QuizRepository.GetById(id);
            return View("Task", Task);
        }

        [Route("/lessonds/submit")]
        [Authorize]
        [HttpPost]
        public IActionResult Submit(Quiz Response)
        {
            string pattern = @"http://schemas\.xmlsoap\.org/ws/2005/05/identity/claims/emailaddress:\s+([\w.-]+@[\w.-]+\.\w+)";
            Match match = Regex.Match(Response.Name, pattern);
            if (match.Success)
            {
                string email = match.Groups[1].Value;
                Response.Name = email;
            }
            else return View();
            var Task = _QuizRepository.GetById(Response._id);


            for(int i = 0; i < Task.Tasks.Count; i++)
            {
                Task.Tasks[i].Answer = Response.Tasks[i].Answer;
            }
            CompletedQuizViewModel Complete = new CompletedQuizViewModel() { Quiz = Task , UserMail = Response.Name};

            _completedQuizRepository.Create(Complete);
            return View();

        }
    }
}
