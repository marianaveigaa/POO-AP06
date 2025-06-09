namespace ConsoleApp.Models;

public class Funcionario : IEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string NomeCompleto { get; set; }
    public string Cargo { get; set; }
    public Guid DepartamentoId { get; set; }
}