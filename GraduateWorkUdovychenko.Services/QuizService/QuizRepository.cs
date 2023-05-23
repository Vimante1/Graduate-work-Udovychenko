using GraduateWorkUdovychenko.Domain.ViewModels;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GraduateWorkUdovychenko.Services.QuizService
{
    public class QuizRepository : IQuizRepository
    {
        private readonly IMongoCollection<CreateQuizViewModel> _collection;

        public QuizRepository()
        {
            var client = new MongoClient("mongodb://root:example@132.226.192.36:27017");
            var database = client.GetDatabase("GraduateQuiz");
            _collection = database.GetCollection<CreateQuizViewModel>("Quiz");
        }

        public bool Create(CreateQuizViewModel entity)
        {
            _collection.InsertOne(entity);
            return true;
        }

        public bool Delete(CreateQuizViewModel entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CreateQuizViewModel> GetAll()
        {
            return _collection.Find(new BsonDocument()).ToEnumerable();
        }

        public CreateQuizViewModel GetById(string id)
        {
            var filter = Builders<CreateQuizViewModel>.Filter.Eq("_id", id);
            var request = _collection.Find(filter).FirstOrDefault();
            return request;
        }
    }
}
