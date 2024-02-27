using MediatR;

namespace Chat.Domain.Commands.Mensagens;
public class RemoveMensagemCommand : IRequest
{
    public Guid Id { get; set; }
}
