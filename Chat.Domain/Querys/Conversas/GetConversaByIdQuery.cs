using Chat.Domain.Entities;

using MediatR;

namespace Chat.Domain.Querys.Conversas
{
    public class GetConversaByIdQuery : IRequest<Conversa?>
    {
        public Guid Id { get; set; }
    }
}