using GraduateWorkUdovychenko.Domain.Models.Quiz;

namespace GraduateWorkUdovychenko.Domain.ViewModels
{
    public class CompletedQuizViewModel
    {

        public string _id { get; set; }
        public string UserMail { get; set; }
        public Quiz Quiz { get; set; }
        public double Rating { get; set; }

        public CompletedQuizViewModel()
        {
            Random rand = new Random();
            _id = rand.Next(1000000000).ToString();
        }
    }
}
