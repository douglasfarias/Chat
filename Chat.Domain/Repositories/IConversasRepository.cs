using Chat.Domain.Entities;

namespace Chat.Domain.Repositories;
public interface IConversasRepository
{
    Task<IEnumerable<Conversa>> GetAllAsync();
    Task<Conversa?> GetByIdAsync(Guid id);
    Task AddAsync(Conversa conversation);
    Task UpdateAsync(Conversa conversation);
    Task RemoveAsync(Guid id);
}
