using System.Text.Json;
using ConsoleApp.Models;
using ConsoleApp.Repositories.Interfaces;

namespace ConsoleApp.Repositories;

public class GenericJsonRepository<T> : IRepository<T> where T : class, IEntity
{
    private readonly string _filePath;
    private List<T> _items = new();

    public GenericJsonRepository(string filePath)
    {
        _filePath = filePath;
        LoadData();
    }

    private void LoadData()
    {
        if (File.Exists(_filePath))
        {
            var json = File.ReadAllText(_filePath);
            _items = JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }
    }

    public void Add(T entity)
    {
        if (entity.Id == Guid.Empty)
            entity.Id = Guid.NewGuid();
        _items.Add(entity);
        SaveChanges();
    }

    public T? GetById(Guid id) => _items.FirstOrDefault(e => e.Id == id);

    public List<T> GetAll() => _items;

    public void Update(T entity)
    {
        var index = _items.FindIndex(e => e.Id == entity.Id);
        if (index >= 0)
        {
            _items[index] = entity;
            SaveChanges();
        }
    }

    public bool Remove(Guid id)
    {
        var entity = GetById(id);
        if (entity == null) return false;
        
        _items.Remove(entity);
        SaveChanges();
        return true;
    }

    public void SaveChanges()
    {
        var json = JsonSerializer.Serialize(_items, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }
}