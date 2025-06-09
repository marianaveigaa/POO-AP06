namespace ConsoleApp.Models;

public abstract class ItemCardapio : IEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string NomeItem { get; set; }
    public decimal Preco { get; set; }
}

public class Prato : ItemCardapio
{
    public string DescricaoDetalhada { get; set; }
    public bool Vegetariano { get; set; }
}

public class Bebida : ItemCardapio
{
    public int VolumeMl { get; set; }
    public bool Alcoolica { get; set; }
}