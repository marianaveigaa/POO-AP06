using System.Text.Json;
using System.Text.Json.Serialization;
using ConsoleApp.Models;
using ConsoleApp.Repositories.Interfaces;

namespace ConsoleApp.Repositories;

public class ItemCardapioRepository : IRepository<ItemCardapio>
{
    private readonly string _filePath;
    private List<ItemCardapio> _items = new();

    public ItemCardapioRepository(string filePath)
    {
        _filePath = filePath;
        LoadData();
    }

    private void LoadData()
    {
        if (File.Exists(_filePath))
        {
            var options = new JsonSerializerOptions
            {
                Converters = { new ItemCardapioConverter() }
            };
            
            var json = File.ReadAllText(_filePath);
            _items = JsonSerializer.Deserialize<List<ItemCardapio>>(json, options) ?? new List<ItemCardapio>();
        }
    }

    public void Add(ItemCardapio entity)
    {
        if (entity.Id == Guid.Empty)
            entity.Id = Guid.NewGuid();
        _items.Add(entity);
        SaveChanges();
    }

    // ... outros métodos CRUD ...

    private void SaveChanges()
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters = { new ItemCardapioConverter() }
        };
        
        var json = JsonSerializer.Serialize(_items, options);
        File.WriteAllText(_filePath, json);
    }
}

public class ItemCardapioConverter : JsonConverter<ItemCardapio>
{
    public override ItemCardapio Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;

        if (root.TryGetProperty("VolumeMl", out _))
            return JsonSerializer.Deserialize<Bebida>(root.GetRawText(), options);
        else
            return JsonSerializer.Deserialize<Prato>(root.GetRawText(), options);
    }

    public override void Write(Utf8JsonWriter writer, ItemCardapio value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, (object)value, options);
    }
}