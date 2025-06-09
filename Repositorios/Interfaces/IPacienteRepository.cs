using ConsoleApp.Models;

namespace ConsoleApp.Repositories.Interfaces;

public interface IPacienteRepository : IRepository<Paciente>
{
    IEnumerable<Paciente> ObterPorFaixaEtaria(int idadeMinima, int idadeMaxima);
}