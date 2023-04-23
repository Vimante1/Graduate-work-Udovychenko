using GraduateWorkUdovychenko.Domain.Models.Quiz;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GraduateWorkUdovychenko.Services.QuizService
{
    public class QuizRepository : IQuizRepository
    {
        private readonly IMongoCollection<Quiz> _collection;

        public QuizRepository()
        {
            var client = new MongoClient("mongodb://root:example@132.226.192.36:27017");
            var database = client.GetDatabase("GraduateQuiz");
            _collection = database.GetCollection<Quiz>("Quiz");
        }

        public bool Create(Quiz entity)
        {
            _collection.InsertOne(entity);
            return true;
        }

        public bool Delete(Quiz Entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Quiz> GetAll()
        {
            return _collection.Find(new BsonDocument()).ToEnumerable();
        }

        public Quiz GetById(string id)
        {
            var filter = Builders<Quiz>.Filter.Eq("_id", new ObjectId(id));
            var request = _collection.Find(filter).FirstOrDefault();
            return request;
        }

        public void TestCreate()
        {
            List<QuizTask> b = new List<QuizTask>() { new QuizTask { Question = "2+2", Options = new List<string> { "5", "6", "4", "12" }, Answer = { } , Type = Domain.Enums.QuizType.Question }, new QuizTask { Question = "3+3", Options = new List<string> { "5", "6", "4", "12" }, Answer = { }, Type = Domain.Enums.QuizType.ChechBox }, new QuizTask { Question = "123+321", Answer = { }, Type = Domain.Enums.QuizType.FullAnswer } };
            Quiz a = new Quiz() { Name = "Математика", Description = "25 Простих запитань з математики", Tasks = b, _id = "64394043125af0f8d1f11111" };
            _collection.InsertOne(a);
        }
    }
}
