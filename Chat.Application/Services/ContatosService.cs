using Chat.Domain.Commands.Contatos;
using Chat.Domain.Entities;
using Chat.Domain.Querys.Contatos;
using Chat.Domain.Repositories;
using Chat.Domain.Services;

namespace Chat.Application.Services;
public class ContatosService : IContatosService
{
    private readonly IContatosRepository _contatosRepository;

    public ContatosService(IContatosRepository contatosRepository)
    {
        _contatosRepository = contatosRepository;
    }

    public async Task<IEnumerable<Contato>> Handle(GetAllContatosQuery request, CancellationToken cancellationToken)
    {
        return await _contatosRepository.GetAllAsync();
    }

    public async Task<Contato?> Handle(GetContatoByIdQuery request, CancellationToken cancellationToken)
    {
        return await _contatosRepository.GetByIdAsync(request.Id);
    }

    public async Task<Guid> Handle(CreateContatoCommand request, CancellationToken cancellationToken)
    {
        var contato = new Contato
        {
            Id = Guid.NewGuid(),
            Nome = request.Nome,
            Email = request.Email
        };
        await _contatosRepository.AddAsync(contato);
        return contato.Id;
    }

    public async Task Handle(UpdateContatoCommand request, CancellationToken cancellationToken)
    {
        var contato = new Contato
        {
            Id = request.Id,
            Nome = request.Nome,
            Email = request.Email
        };
        await _contatosRepository.UpdateAsync(contato);
    }

    public async Task Handle(RemoveContatoCommand request, CancellationToken cancellationToken)
    {
        await _contatosRepository.RemoveAsync(request.Id);
    }
}
