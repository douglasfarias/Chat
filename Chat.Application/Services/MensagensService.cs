using Chat.Domain.Commands.Mensagens;
using Chat.Domain.Entities;
using Chat.Domain.Querys.Mensagens;
using Chat.Domain.Repositories;
using Chat.Domain.Services;

namespace Chat.Application.Services;
public class MensagensService : IMensagensService
{
    private readonly IMensagensRepository _mensagensRepository;

    public MensagensService(IMensagensRepository mensagensRepository)
    {
        _mensagensRepository = mensagensRepository;
    }

    public async Task<Guid> Handle(CreateMensagemCommand request, CancellationToken cancellationToken)
    {
        var mensagem = new Mensagem
        {
            Id = Guid.NewGuid(),
            Texto = request.Texto,
            RemetenteId = request.RemetenteId,
            ConversaId = request.ConversaId
        };
        await _mensagensRepository.AddAsync(mensagem);
        return mensagem.Id;
    }

    public async Task Handle(UpdateMensagemCommand request, CancellationToken cancellationToken)
    {
        var mensagem = new Mensagem
        {
            Id = request.Id,
            Texto = request.Texto
        };
        await _mensagensRepository.UpdateAsync(mensagem);
    }

    public async Task Handle(RemoveMensagemCommand request, CancellationToken cancellationToken)
    {
        await _mensagensRepository.RemoveAsync(request.Id);
    }

    public async Task<Mensagem?> Handle(GetMensagemByIdQuery request, CancellationToken cancellationToken)
    {
        return await _mensagensRepository.GetByIdAsync(request.Id);
    }

    public async Task<IEnumerable<Mensagem>> Handle(GetMensagensByConversaIdQuery request, CancellationToken cancellationToken)
    {
        return await _mensagensRepository.GetByConversaIdAsync(request.ConversaId);
    }
}
