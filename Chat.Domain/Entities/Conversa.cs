namespace Chat.Domain.Entities;

public class Conversa
{
    public Guid Id { get; set; }
    public Guid ContatoId { get; set; }
    public string Titulo { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataAtualizacao { get; set; }
}
