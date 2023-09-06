using ClimbingApp.DataAccess.Data.Entity;
using Microsoft.EntityFrameworkCore;
using static ClimbingApp.ApplicationServices.Services.UserCommunication;

namespace ClimbingApp.DataAccess.Data.Repositories;

public class SqlRepository<T> : IRepository<T>
    where T : class, IEntity, new()
{
    private readonly DbSet<T> _dbSet;

    private readonly ClimbingAppDbContext _dbContext;

    public SqlRepository(ClimbingAppDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public event EventHandler<T>? ItemAdded;
    public event EventHandler<T>? ItemRemoved;
    public event EventHandler<T>? HighRating;


    public void Add(T item)
    {
        _dbSet.Add(item);
        _dbContext.SaveChanges();
        ItemAdded?.Invoke(this, item);
        HighRating?.Invoke(this, item);
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public T GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public void Remove(T item)
    {
        _dbSet.Remove(item);
        _dbContext.SaveChanges();
        ItemRemoved?.Invoke(this, item);

    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }
}
