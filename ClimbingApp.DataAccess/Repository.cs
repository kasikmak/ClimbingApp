using ClimbingApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbingApp.DataAccess;

public class Repository<T> : IRepository<T> where T :EntityBase
{
    protected readonly ClimbingAppStorageContext? context;
    private DbSet<T> entities;

    public Repository(ClimbingAppStorageContext context)
    {
        this.context = context;
        entities = context.Set<T>();
    }
    public IEnumerable<T> GetAll()
    {
        return entities.AsEnumerable();
    }

    public T GetById(int id)
    {
        return entities.SingleOrDefault(s => s.Id == id);
    }

    public void Insert(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        entities.Add(entity);
        context.SaveChangesAsync();
    }

    public void Update(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        context.SaveChangesAsync();
    }

    public void Delete(int id)
    {
        T entity = entities.SingleOrDefault(s => s.Id == id);
        entities.Remove(entity);
        context.SaveChanges();
    }

    /*public Task<List<T>> GetAll()
    {
        return entities.ToListAsync();
    }

    public Task<T> GetById(int id)
    {
        return entities.SingleOrDefaultAsync(s => s.Id == id);
    }

    public Task Insert(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        entities.Add(entity);
        return context.SaveChangesAsync();
    }

    public Task Update(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        return context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        T entity = await entities.SingleOrDefaultAsync(s => s.Id == id);
        entities.Remove(entity);
        await context.SaveChangesAsync();
    }*/
}
