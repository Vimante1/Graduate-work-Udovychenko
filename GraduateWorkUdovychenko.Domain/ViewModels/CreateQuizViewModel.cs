using GraduateWorkUdovychenko.Domain.Models.Quiz;

namespace GraduateWorkUdovychenko.Domain.ViewModels
{
    public class CreateQuizViewModel : Quiz
    {
        public string UserMail { get; set; }
        public float Rating { get; set; }
        public string[][] CorrectAnswer { get; set; }

        public void CreateNewId()
        {
            Random rand = new Random();
            _id = rand.Next(123123123).ToString();
        }

        public void SummaryRating(CreateQuizViewModel correct)
        {
            float rating = 0;
            foreach (var task in correct.Tasks)
            {
                rating += task.TaskRating;
            }

            Rating = rating;
        }
    }
}
