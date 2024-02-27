using Chat.Domain.Entities;

using MediatR;

namespace Chat.Domain.Querys.Contatos;
public class GetAllContatosQuery : IRequest<IEnumerable<Contato>>
{
}
