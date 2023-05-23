using GraduateWorkUdovychenko.Domain.Models.Quiz;
using GraduateWorkUdovychenko.Domain.ViewModels;
using MongoDB.Driver.Core.Operations;

namespace GraduateWorkUdovychenko.Services.QuizService
{
    public interface IQuizRepository : IBaseRepository<CreateQuizViewModel>
    {
        CreateQuizViewModel GetById(string id);
    }
}
