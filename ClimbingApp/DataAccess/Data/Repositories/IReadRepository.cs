using ClimbingApp.DataAccess.Data.Entity;

namespace ClimbingApp.DataAccess.Data.Repositories;

public interface IReadRepository<out T>
    where T : class, IEntity, new()
{
    T GetById(int id);
    IEnumerable<T> GetAll();
}
