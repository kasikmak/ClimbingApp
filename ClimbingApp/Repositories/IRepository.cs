using ClimbingApp.Entity;

namespace ClimbingApp.Repositories;

public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>
    where T : class, IEntity, new()
{
    public const string auditFileName = "audit.txt";
}
