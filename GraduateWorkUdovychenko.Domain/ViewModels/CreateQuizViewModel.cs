using GraduateWorkUdovychenko.Domain.Models.Quiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkUdovychenko.Domain.ViewModels
{
    public class CreateQuizViewModel : Quiz
    {
        public string UserMail { get; set; }
        public float Rating { get; set; }
        public string[][] CorrectAnswer { get; set; }

        public CreateQuizViewModel()
        {
            Random rand = new Random();
            _id = rand.Next(123123123).ToString();
        }
    }
}
