using GraduateWorkUdovychenko.Domain.ViewModels;

namespace GraduateWorkUdovychenko.Services.QuizService
{
    public interface IQuizRepository : IBaseRepository<CreateQuizViewModel>
    {
        CreateQuizViewModel GetById(string id);
    }
}
