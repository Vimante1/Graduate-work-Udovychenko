namespace GraduateWorkUdovychenko.Services
{
    public interface IBaseRepository<T>
    {
        bool Create(T entity);

        IEnumerable<T> GetAll();

        bool Delete(T entity);
    }
}
