using ClimbingApp.Data.Entity;

namespace ClimbingApp.Data.Repositories;

public interface IWriteRepository<in T>
    where T : class, IEntity, new()
{

    void Add(T item);
    void Remove(T item);
    void Save();
}
