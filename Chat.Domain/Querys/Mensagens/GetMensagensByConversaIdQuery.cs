using Chat.Domain.Entities;

using MediatR;

namespace Chat.Domain.Querys.Mensagens
{
    public class GetMensagensByConversaIdQuery : IRequest<IEnumerable<Mensagem>>
    {
        public Guid ConversaId { get; set; }
    }
}
