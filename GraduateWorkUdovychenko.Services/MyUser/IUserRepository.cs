using GraduateWorkUdovychenko.Domain.Models;
using GraduateWorkUdovychenko.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkUdovychenko.Services.MyUser
{
    public interface IUserRepository : IBaseDB<User>
    {
        User GetByEmail(string mail);

        User Correct(AuthViewModel user);
    }
}
