namespace Chat.Domain.Entities;
public class Mensagem
{
    public Guid Id { get; set; }
    public string Texto { get; set; }
    public Guid ConversaId { get; set; }
    public Guid RemetenteId { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataAtualizacao { get; set; }
}