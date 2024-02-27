using System.Data;

using Chat.Domain.Entities;

using Dapper;

namespace Chat.Domain.Repositories
{
    public class MensagensRepository : IMensagensRepository
    {
        private readonly IDbConnection _connection;

        public MensagensRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Mensagem>> GetAllAsync()
        {
            return await _connection.QueryAsync<Mensagem>("GetAllMensagens", commandType: CommandType.StoredProcedure);
        }

        public async Task<Mensagem?> GetByIdAsync(Guid id)
        {
            return await _connection.QueryFirstOrDefaultAsync<Mensagem>("GetMensagemById", new { Id = id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Mensagem>> GetByConversaIdAsync(Guid id)
        {
            return await _connection.QueryAsync<Mensagem>("GetMensagensByConversaId", new { Id = id }, commandType: CommandType.StoredProcedure);
        }

        public async Task AddAsync(Mensagem mensagem)
        {
            var query = "AddMensagem";
            var param = new
            {
                Id = mensagem.Id,
                Texto = mensagem.Texto,
                Conversa = mensagem.ConversaId,
                Remetente = mensagem.RemetenteId,
            };
            await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateAsync(Mensagem mensagem)
        {
            var query = "UpdateMensagem";
            var param = new
            {
                mensagem.Id,
                mensagem.Texto,
            };
            await _connection.ExecuteAsync(query, param, commandType: CommandType.StoredProcedure);
        }

        public async Task RemoveAsync(Guid id)
        {
            var query = "RemoveMensagem";
            await _connection.ExecuteAsync(query, new { Id = id }, commandType: CommandType.StoredProcedure);
        }
    }
}
