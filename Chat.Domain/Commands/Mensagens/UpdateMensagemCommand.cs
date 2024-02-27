using MediatR;

namespace Chat.Domain.Commands.Mensagens
{
    public class UpdateMensagemCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Texto { get; set; }
    }
}