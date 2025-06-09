using ConsoleApp.Models;
using ConsoleApp.Repositories.Interfaces;
using System.Collections.Concurrent;

namespace ConsoleApp.Repositories;

public class InMemoryEquipamentoTIRepository : IRepository<EquipamentoTI>
{
    private readonly ConcurrentDictionary<Guid, EquipamentoTI> _equipamentos = new();

    public void Add(EquipamentoTI entity)
    {
        if (entity.Id == Guid.Empty)
            entity.Id = Guid.NewGuid();
        _equipamentos.TryAdd(entity.Id, entity);
    }

    public EquipamentoTI? GetById(Guid id)
    {
        _equipamentos.TryGetValue(id, out var equipamento);
        return equipamento;
    }

    public List<EquipamentoTI> GetAll() => _equipamentos.Values.ToList();

    public void Update(EquipamentoTI entity)
    {
        _equipamentos.AddOrUpdate(entity.Id, entity, (id, oldValue) => entity);
    }

    public bool Remove(Guid id) => _equipamentos.TryRemove(id, out _);

    public void SaveChanges() { /* Nada a fazer em memória */ }
}