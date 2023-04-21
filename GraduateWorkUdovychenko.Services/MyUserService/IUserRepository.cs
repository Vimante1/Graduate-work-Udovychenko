using GraduateWorkUdovychenko.Domain.Models;
using GraduateWorkUdovychenko.Domain.ViewModels;

namespace GraduateWorkUdovychenko.Services.MyUser
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetByEmail(string mail);

        User Correct(AuthViewModel user);
    }
}
