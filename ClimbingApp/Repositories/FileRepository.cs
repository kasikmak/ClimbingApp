using ClimbingApp.Entity;
using System.Text.Json;

namespace ClimbingApp.Repositories;

public class FileRepository<T> : IRepository<T>
    where T : class, IEntity, new()
{
    protected  List<T> _items = new();

    public event EventHandler<T>? ItemAdded, ItemRemoved;

    public void ReadRepository()
    {
        _items = ReadFromFile<T>();
    }
        
    public IEnumerable<T> GetAll()
    {
        return _items.ToList();
    }
    public void Add(T item)
    {
        item.Id = _items.Count + 1;
        _items.Add(item);
        ItemAdded?.Invoke(this, item);
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
        SaveToFile<T>(_items);
    }

    private void SaveToFile<T>(List<T> items)
        where T : class, IEntity, new()
    {
        T Object = new();
        var fileName = Object.GetType().Name + ".txt";

        using (var writer =File.AppendText(fileName))
        {
            int count = this._items.Count;
            for(int i = 0; i < count; i++)
            {
                T item = items[i];
                string json = JsonSerializer.Serialize<T>(item);
                writer.WriteLine(json);
            }
        }
    }

    private List<T> ReadFromFile<T>()
        where T : class, IEntity, new()
    {
        T Object = new();
        var fileName = Object.GetType().Name + ".txt";
        List<T> list = new List<T>();

        if (File.Exists(fileName))
        {
            using (var reader = File.OpenText(fileName))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    Object = JsonSerializer.Deserialize<T>(line);
                    if(Object != null)
                        list.Add(Object);
                    line = reader.ReadLine();
                }
            }
        }
        return list.ToList();
    }

}
