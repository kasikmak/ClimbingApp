using ClimbingApp.DataAccess.Data.Entity;
using static ClimbingApp.ApplicationServices.Services.UserCommunication;

namespace ClimbingApp.DataAccess.Data.Repositories;

public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>
    where T : class, IEntity, new()
{
    public const string auditFileName = "audit.txt";
    public event EventHandler<T>? ItemAdded;
    public event EventHandler<T>? ItemRemoved;
    public event EventHandler<T>? HighRating;
}
