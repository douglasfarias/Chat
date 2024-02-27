using Chat.Domain.Entities;

namespace Chat.Domain.Repositories;
public interface IContatosRepository
{
    Task<IEnumerable<Contato>> GetAllAsync();
    Task<Contato?> GetByIdAsync(Guid id);
    Task AddAsync(Contato user);
    Task UpdateAsync(Contato user);
    Task RemoveAsync(Guid id);
}
