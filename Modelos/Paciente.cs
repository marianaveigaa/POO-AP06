namespace ConsoleApp.Models;

public class Paciente : IEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string NomeCompleto { get; set; }
    public DateTime DataNascimento { get; set; }
    public string ContatoEmergencia { get; set; }
}