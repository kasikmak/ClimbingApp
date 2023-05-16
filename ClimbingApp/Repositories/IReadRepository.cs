using ClimbingApp.Entity;

namespace ClimbingApp.Repositories;

public interface IReadRepository<out T>
    where T : class, IEntity, new()
{
    T GetById(int id);
    IEnumerable<T> GetAll();
}
