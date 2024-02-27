using Chat.Domain.Entities;

using MediatR;

namespace Chat.Domain.Querys.Contatos;
public class GetContatoByIdQuery : IRequest<Contato?>
{
    public Guid Id { get; set; }
}
