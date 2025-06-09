using ConsoleApp.Models;
using ConsoleApp.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp.Repositories;

public class ProdutoRepository : IRepository<Produto>
{
    private readonly GenericJsonRepository<Produto> _repository;

    public ProdutoRepository(IConfiguration config)
    {
        var filePath = config.GetSection("DataPaths")["Produtos"] ?? "Data/produtos.json";
        _repository = new GenericJsonRepository<Produto>(filePath);
    }

    public void Add(Produto entity) => _repository.Add(entity);
    public Produto? GetById(Guid id) => _repository.GetById(id);
    public List<Produto> GetAll() => _repository.GetAll();
    public void Update(Produto entity) => _repository.Update(entity);
    public bool Remove(Guid id) => _repository.Remove(id);
    public void SaveChanges() => _repository.SaveChanges();
}