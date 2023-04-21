using GraduateWorkUdovychenko.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkUdovychenko.Domain.Models.Quiz
{
    public class QuizTask
    {
        public QuizType Type { get; set; }
        public string Question { get; set; }
        public List<string> Options { get; set; }
        public string Answer { get; set; }
    }
}
