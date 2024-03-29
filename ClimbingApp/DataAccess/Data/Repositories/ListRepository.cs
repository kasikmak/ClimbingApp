﻿using ClimbingApp.DataAccess.Data.Entity;
using static ClimbingApp.ApplicationServices.Services.UserCommunication;

namespace ClimbingApp.DataAccess.Data.Repositories;

public class ListRepository<T> : IRepository<T>
    where T : class, IEntity, new()
{
    protected readonly List<T> _items = new();

    public event EventHandler<T>? ItemAdded;
    public event EventHandler<T>? ItemRemoved;
    public event EventHandler<T>? HighRating;

    public IEnumerable<T> GetAll()
    {
        return _items.ToList();
    }
    public void Add(T item)
    {
        item.Id = _items.Count + 1;
        _items.Add(item);
        ItemAdded?.Invoke(this, item);
        HighRating?.Invoke(this, item);
    }

    public T GetById(int id)
    {
        return _items.Single(item => item.Id == id);
    }

    public void Remove(T item)
    {
        _items.Remove(item);
        ItemRemoved?.Invoke(this, item);

    }

    public void Save()
    {
    }
}
