using MediatR;

namespace Chat.Domain.Commands.Mensagens
{
    public class CreateMensagemCommand : IRequest<Guid>
    {
        public string Texto { get; set; }
        public Guid ConversaId { get; set; }
        public Guid RemetenteId { get; set; }
    }
}