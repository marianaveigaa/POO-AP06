namespace ConsoleApp.Models;

public class Produto : IEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
}