using Chat.Domain.Entities;

using MediatR;

namespace Chat.Domain.Queries.Mensagens
{
    public class GetMensagemByIdQuery : IRequest<Mensagem>
    {
        public Guid Id { get; set; }
    }
}