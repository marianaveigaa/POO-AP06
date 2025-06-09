namespace ConsoleApp.Models;

public class Departamento : IEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string NomeDepartamento { get; set; }
    public string Sigla { get; set; }
}