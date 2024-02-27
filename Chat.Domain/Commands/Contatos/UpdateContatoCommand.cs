using MediatR;

namespace Chat.Domain.Commands.Contatos;
public class UpdateContatoCommand : IRequest
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
}
