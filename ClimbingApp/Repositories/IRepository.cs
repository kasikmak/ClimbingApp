using ClimbingApp.Entity;
using static ClimbingApp.Services.UserCommuniction;

namespace ClimbingApp.Repositories;

public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>
    where T : class, IEntity, new()
{
    public const string auditFileName = "audit.txt";
    public event EventHandler<T>? ItemAdded;
    public event EventHandler<T>? ItemRemoved;    
    public event EventHandler<T>? HighRating;
}
