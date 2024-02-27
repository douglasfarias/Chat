using MediatR;

namespace Chat.Domain.Commands.Contatos;
public class RemoveContatoCommand : IRequest

{
    public Guid Id { get; set; }
}
