using GraduateWorkUdovychenko.Domain.Models.Quiz;
using GraduateWorkUdovychenko.Domain.ViewModels;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkUdovychenko.Services.QuizService
{
    public class CompletedQuizRepository : ICompletedQuizRepository
    {
        private readonly IMongoCollection<CreateQuizViewModel> _collection;

        public CompletedQuizRepository()
        {
            var client = new MongoClient("mongodb://root:example@132.226.192.36:27017");
            var database = client.GetDatabase("GraduateQuiz");
            _collection = database.GetCollection<CreateQuizViewModel>("CompletedQuiz");
        }

        public bool Create(CreateQuizViewModel entity)
        {
            try
            {
                _collection.InsertOneAsync(entity);
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public bool Delete(CreateQuizViewModel entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CreateQuizViewModel> GetAll()
        {
            return _collection.Find(new BsonDocument()).ToEnumerable();
        }

        public IEnumerable<CreateQuizViewModel> GetAllForUser(string mail)
        {
            var filter = Builders<CreateQuizViewModel>.Filter.Eq("UserMail", mail); // Замініть "UserMail" на назву поля в вашому документі та "mail" на значення, яке ви шукаєте
            var result =  _collection.Find(filter).ToList();
            return result;
        }
    }
}
