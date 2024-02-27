using MediatR;

namespace Chat.Domain.Commands.Conversas
{
    public class RemoveConversaCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}