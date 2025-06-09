namespace ConsoleApp.Models;

public class Musica : IEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Titulo { get; set; }
    public string Artista { get; set; }
    public string Album { get; set; }
    public TimeSpan Duracao { get; set; }
}