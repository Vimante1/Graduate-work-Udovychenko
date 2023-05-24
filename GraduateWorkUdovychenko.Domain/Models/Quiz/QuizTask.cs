using GraduateWorkUdovychenko.Domain.Enums;

namespace GraduateWorkUdovychenko.Domain.Models.Quiz
{
    public class QuizTask
    {
        public QuizType Type { get; set; }
        public string Question { get; set; }
        public List<string> Options { get; set; }
        public string[] Answer { get; set; }
        public float TaskRating { get; set; }
    }
}
