using GraduateWorkUdovychenko.Domain.Models.Quiz;
using GraduateWorkUdovychenko.Domain.ViewModels;
using GraduateWorkUdovychenko.Services.QuizService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraduateWorkUdovychenko.Controllers
{
    public class LessonsController : Controller
    {
        IQuizRepository _quizRepository { get; set; }
        ICompletedQuizRepository _completedQuizRepository { get; set; }
        public LessonsController(IQuizRepository quizRepository, ICompletedQuizRepository completedQuizRepository)
        {
            _completedQuizRepository = completedQuizRepository;
            _quizRepository = quizRepository;
        }

        [Route("/Lessons")]
        [Authorize]
        public IActionResult Lessons()
        {
            var getFromDb = _quizRepository.GetAll();
            IEnumerable<Quiz> response = getFromDb;
            return View(response);
        }

        [Route("/Lessons/task")]
        [Authorize]
        public IActionResult Task(string id)
        {
            Quiz task = _quizRepository.GetById(id);
            return View("Task", task);
        }

        [Route("/Lessons/submit")]
        [Authorize]
        [HttpPost]
        public IActionResult Submit(CreateQuizViewModel response)
        {
            CreateQuizViewModel correct = _quizRepository.GetById(response._id);
            correct.CreateNewId();
            correct.UserMail = User.Claims.FirstOrDefault().Value;

            for (int i = 0; i < response.Tasks.Count; i++)
            {
                correct.Tasks[i].Answer = response.Tasks[i].Answer;
            }

            correct = CalculateRatingForTask(correct);

            if (QuizWithoutFullAnswer(correct))
            {
                correct.SummaryRating(correct);
            }
            _completedQuizRepository.Create(correct);
            return RedirectToAction("Lessons");
        }

        private CreateQuizViewModel CalculateRatingForTask(CreateQuizViewModel correct)
        {
            float ratingForOneTask = correct.MaxRatingForQuiz / correct.Tasks.Count;

            for (int taskCounter = 0; taskCounter < correct.Tasks.Count; taskCounter++)
            {
                float ratingForCurrentTask = 0;
                float ratingForOneCorrectAnswerOption = ratingForOneTask / (correct.CorrectAnswer[taskCounter].Length);
                for (int userAnserCounter = 0; userAnserCounter < correct.Tasks[taskCounter].Answer.Length; userAnserCounter++)
                {
                    bool answerCorrect = false;
                    for (int correctAnswerCounter = 0; correctAnswerCounter < correct.CorrectAnswer[taskCounter].Length; correctAnswerCounter++)
                    {
                        if (correct.CorrectAnswer[taskCounter][correctAnswerCounter] == correct.Tasks[taskCounter].Answer[userAnserCounter])
                        {
                            ratingForCurrentTask += ratingForOneCorrectAnswerOption;
                            answerCorrect = true;
                            break;
                        }
                    }
                    if (!answerCorrect) ratingForCurrentTask -= ratingForOneCorrectAnswerOption;
                }


                correct.Tasks[taskCounter].TaskRating = ratingForCurrentTask < 0 ? 0 : ratingForCurrentTask;
            }

            return correct;
        }

        private bool QuizWithoutFullAnswer(CreateQuizViewModel correct)
        {
            foreach(var tasks in correct.Tasks)
            {
                if(tasks.Type == Domain.Enums.QuizType.FullAnswer)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
