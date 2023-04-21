using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkUdovychenko.Services
{
    public interface IBaseRepository<T>
    {
        bool Create(T entity);

        IEnumerable<T> GetAll();

        bool Delete(T Entity);
    }
}
