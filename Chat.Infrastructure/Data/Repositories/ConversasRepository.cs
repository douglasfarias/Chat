using System.Data;
using Chat.Domain.Entities;
using Chat.Domain.Repositories;
using Dapper;

namespace Chat.Infrastructure.Data.Repositories;
public class ConversasRepository : IConversasRepository, IDisposable
{
    private readonly IDbConnection _connection;

    public ConversasRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<Conversa>> GetAllAsync()
    {
        return await _connection.QueryAsync<Conversa>("GetAllConversas", commandType: CommandType.StoredProcedure);
    }

    public async Task<Conversa?> GetByIdAsync(Guid id)
    {
        return await _connection.QueryFirstOrDefaultAsync<Conversa>("GetConversaById", param: new { Id = id }, commandType: CommandType.StoredProcedure);
    }

    public async Task AddAsync(Conversa conversa)
    {
        var query = "AddConversa";
        var param = new
        {
            conversa.Id,
            Contato = conversa.ContatoId,
            conversa.Titulo,
        };
        await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
    }

    public async Task UpdateAsync(Conversa conversa)
    {
        var query = "UpdateConversa";
        var param = new
        {
            conversa.Id,
            conversa.Titulo,
        };
        await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
    }

    public async Task RemoveAsync(Guid id)
    {
        var query = "RemoveConversa";
        await _connection.ExecuteAsync(query, new { Id = id }, commandType: CommandType.StoredProcedure);
    }

    public void Dispose()
    {
        _connection?.Close();
        _connection?.Dispose();
    }
}
