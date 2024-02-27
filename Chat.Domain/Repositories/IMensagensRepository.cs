using Chat.Domain.Entities;

namespace Chat.Domain.Repositories;
public interface IMensagensRepository
{
    Task AddAsync(Mensagem mensagem);
    Task<IEnumerable<Mensagem>> GetAllAsync();
    Task<Mensagem?> GetByIdAsync(Guid id);
    Task<IEnumerable<Mensagem>> GetByConversaIdAsync(Guid id);
    Task RemoveAsync(Guid id);
    Task UpdateAsync(Mensagem mensagem);
}