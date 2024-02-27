using MediatR;

namespace Chat.Domain.Commands.Conversas
{
    public class UpdateConversaCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
    }
}