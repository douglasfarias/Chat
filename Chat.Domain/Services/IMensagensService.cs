using Chat.Domain.Commands.Mensagens;
using Chat.Domain.Entities;
using Chat.Domain.Querys.Mensagens;

using MediatR;

namespace Chat.Domain.Services;
public interface IMensagensService : IRequestHandler<CreateMensagemCommand, Guid>,
    IRequestHandler<UpdateMensagemCommand>,
    IRequestHandler<RemoveMensagemCommand>,
    IRequestHandler<GetMensagemByIdQuery, Mensagem?>,
    IRequestHandler<GetMensagensByConversaIdQuery, IEnumerable<Mensagem>>
{
}
