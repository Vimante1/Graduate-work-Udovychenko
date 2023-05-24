using GraduateWorkUdovychenko.Domain.ViewModels;

namespace GraduateWorkUdovychenko.Services.QuizService
{
    public interface ICompletedQuizRepository : IBaseRepository<CreateQuizViewModel>
    {
        IEnumerable<CreateQuizViewModel> GetAllForUser(string mail);
        CreateQuizViewModel GetById (string id);

        bool UpdateById(CreateQuizViewModel viewModel);

    }
}
