using Chat.Domain.Commands.Conversas;
using Chat.Domain.Entities;
using Chat.Domain.Querys.Conversas;

using MediatR;

namespace Chat.Domain.Services;
public interface IConversasService : IRequestHandler<CreateConversaCommand, Guid>,
    IRequestHandler<RemoveConversaCommand>,
    IRequestHandler<GetConversaByIdQuery, Conversa?>,
    IRequestHandler<GetAllConversasQuery, IEnumerable<Conversa>>
{

}