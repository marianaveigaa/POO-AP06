using ConsoleApp.Models;
using ConsoleApp.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp.Repositories;

public class PacienteRepository : IPacienteRepository
{
    private readonly GenericJsonRepository<Paciente> _repository;

    public PacienteRepository(IConfiguration config)
    {
        var filePath = config.GetSection("DataPaths")["Pacientes"] ?? "Data/pacientes.json";
        _repository = new GenericJsonRepository<Paciente>(filePath);
    }

    public void Add(Paciente entity) => _repository.Add(entity);
    public Paciente? GetById(Guid id) => _repository.GetById(id);
    public List<Paciente> GetAll() => _repository.GetAll();
    public void Update(Paciente entity) => _repository.Update(entity);
    public bool Remove(Guid id) => _repository.Remove(id);
    public void SaveChanges() => _repository.SaveChanges();

    public IEnumerable<Paciente> ObterPorFaixaEtaria(int idadeMinima, int idadeMaxima)
    {
        return GetAll().Where(p => 
        {
            int idade = DateTime.Now.Year - p.DataNascimento.Year;
            if (p.DataNascimento.Date > DateTime.Now.AddYears(-idade)) idade--;
            return idade >= idadeMinima && idade <= idadeMaxima;
        });
    }
}