using Chat.Domain.Entities;

using MediatR;

namespace Chat.Domain.Querys.Conversas
{
    public class GetAllConversasQuery : IRequest<IEnumerable<Conversa>>
    {
    }
}