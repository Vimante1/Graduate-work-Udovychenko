namespace GraduateWorkUdovychenko.Domain.Models.Quiz
{
    public class Quiz
    {
        public string _id { get; set; }
        public string Name { get; set; }
        public string Description{ get; set; }
        public List<QuizTask> Tasks { get; set; }
        public int MaxRatingForQuiz { get; set; }

    }
}
