using System.Data;

using Chat.Domain.Entities;
using Chat.Domain.Repositories;

using Dapper;

namespace Chat.Infrastructure.Repositories;
public class ContatosRepository : IContatosRepository, IDisposable
{
    private readonly IDbConnection _connection;

    public ContatosRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<Contato>> GetAllAsync()
    {
        return await _connection.QueryAsync<Contato>("GetAllContatos", commandType: CommandType.StoredProcedure);
    }

    public async Task<Contato?> GetByIdAsync(Guid id)
    {
        return await _connection.QueryFirstOrDefaultAsync<Contato>("GetContatoById", new { Id = id }, commandType: CommandType.StoredProcedure);
    }

    public async Task AddAsync(Contato contato)
    {
        var query = "AddContato";
        var parameters = new
        {
            contato.Id,
            contato.Nome,
            contato.Email
        };
        await _connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task UpdateAsync(Contato contato)
    {
        var query = "UpdateContato";
        var parameters = new
        {
            contato.Id,
            contato.Nome,
            contato.Email
        };
        await _connection.ExecuteAsync(query, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task RemoveAsync(Guid id)
    {
        var query = "RemoveContato";
        await _connection.ExecuteAsync(query, new { Id = id }, commandType: CommandType.StoredProcedure);
    }

    public void Dispose()
    {
        _connection?.Close();
        _connection?.Dispose();
    }
}
