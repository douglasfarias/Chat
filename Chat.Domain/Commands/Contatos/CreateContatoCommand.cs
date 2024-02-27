using MediatR;

namespace Chat.Domain.Commands.Contatos;
public class CreateContatoCommand : IRequest<Guid>
{
    public string Nome { get; set; }
    public string Email { get; set; }
}
