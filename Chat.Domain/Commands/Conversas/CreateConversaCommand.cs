using MediatR;

namespace Chat.Domain.Commands.Conversas
{
    public class CreateConversaCommand : IRequest<Guid>
    {
        public string Titulo { get; set; }
        public Guid ContatoId { get; set; }
    }
}