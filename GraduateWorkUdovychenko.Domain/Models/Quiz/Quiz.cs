using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkUdovychenko.Domain.Models.Quiz
{
    public class Quiz
    {

        public string _id { get; set; }
        public string Name { get; set; }
        public string Description{ get; set; }
        public List<QuizTask> Tasks { get; set; }


        public Quiz()
        {
            Random rand = new Random();
            _id = rand.Next(1000000).ToString();
        }
    }
}
