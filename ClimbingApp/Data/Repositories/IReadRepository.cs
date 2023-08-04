using ClimbingApp.Data.Entity;

namespace ClimbingApp.Data.Repositories;

public interface IReadRepository<out T>
    where T : class, IEntity, new()
{
    T GetById(int id);
    IEnumerable<T> GetAll();
}
