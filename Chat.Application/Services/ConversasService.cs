using Chat.Domain.Commands.Conversas;
using Chat.Domain.Entities;
using Chat.Domain.Querys.Conversas;
using Chat.Domain.Repositories;
using Chat.Domain.Services;

namespace Chat.Application.Services;
public class ConversasService : IConversasService
{
    private readonly IConversasRepository _conversasRepository;

    public ConversasService(IConversasRepository conversasRepository)
    {
        _conversasRepository = conversasRepository;
    }

    public async Task<IEnumerable<Conversa>> Handle(GetAllConversasQuery request, CancellationToken cancellationToken)
    {
        return await _conversasRepository.GetAllAsync();
    }

    public async Task<Conversa?> Handle(GetConversaByIdQuery request, CancellationToken cancellationToken)
    {
        return await _conversasRepository.GetByIdAsync(request.Id);
    }

    public async Task<Guid> Handle(CreateConversaCommand request, CancellationToken cancellationToken)
    {
        var conversa = new Conversa
        {
            Id = Guid.NewGuid(),
            Titulo = request.Titulo,
            ContatoId = request.ContatoId
        };
        await _conversasRepository.AddAsync(conversa);
        return conversa.Id;
    }

    public async Task Handle(UpdateConversaCommand request, CancellationToken cancellationToken)
    {
        var conversa = new Conversa
        {
            Id = request.Id,
            Titulo = request.Titulo
        };
        await _conversasRepository.UpdateAsync(conversa);
    }

    public async Task Handle(RemoveConversaCommand request, CancellationToken cancellationToken)
    {
        await _conversasRepository.RemoveAsync(request.Id);
    }
}
