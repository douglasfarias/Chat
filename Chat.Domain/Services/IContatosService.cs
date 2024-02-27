using Chat.Domain.Commands.Contatos;
using Chat.Domain.Entities;
using Chat.Domain.Querys.Contatos;

using MediatR;

namespace Chat.Domain.Services;
public interface IContatosService : IRequestHandler<CreateContatoCommand, Guid>,
    IRequestHandler<UpdateContatoCommand>,
    IRequestHandler<RemoveContatoCommand>,
    IRequestHandler<GetContatoByIdQuery, Contato?>,
    IRequestHandler<GetAllContatosQuery, IEnumerable<Contato>>
{

}