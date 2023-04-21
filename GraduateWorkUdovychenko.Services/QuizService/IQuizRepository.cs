using GraduateWorkUdovychenko.Domain.Models.Quiz;
using MongoDB.Driver.Core.Operations;

namespace GraduateWorkUdovychenko.Services.QuizService
{
    public interface IQuizRepository : IBaseRepository<Quiz>
    {
        void TestCreate();
        Quiz GetById(string id);
    }
}
