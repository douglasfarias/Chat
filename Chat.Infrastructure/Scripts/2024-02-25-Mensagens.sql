CREATE TABLE Mensagens
(
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Texto NVARCHAR(MAX),
    ConversaId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Conversas(Id),
    RemetenteId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Contatos(Id),
    DataCriacao DATETIME,
    DataAtualizacao DATETIME
);
GO

-- Stored Procedure for GetByIdAsync
CREATE PROCEDURE GetMensagemById
    @Id uniqueidentifier
AS
BEGIN
    SELECT 
        Id, 
        Texto, 
        DataCriacao, 
        DataAtualizacao,
        ConversaId, 
        RemetenteId
    FROM Mensagens WHERE Id = @Id
END
GO

-- Stored Procedure for GetByConversaIdAsync
CREATE PROCEDURE GetMensagensByConversaId
    @Id uniqueidentifier
AS
BEGIN
    SELECT
        Id, 
        Texto, 
        DataCriacao, 
        DataAtualizacao,
        ConversaId, 
        RemetenteId
    FROM Mensagens WHERE ConversaId = @Id
END
GO

-- Stored Procedure for AddAsync
CREATE PROCEDURE AddMensagem
    @Id uniqueidentifier,
    @Texto nvarchar(max),
    @Conversa uniqueidentifier,
    @Remetente uniqueidentifier
AS
BEGIN
    INSERT INTO Mensagens(Id, Texto, ConversaId, RemetenteId, DataCriacao)
    VALUES (@Id, @Texto, @Conversa, @Remetente, GETDATE())
END
GO

-- Stored Procedure for UpdateAsync
CREATE PROCEDURE UpdateMensagem
    @Id uniqueidentifier,
    @Texto nvarchar(max)
AS
BEGIN
    UPDATE Mensagens
    SET Texto = @Texto,
    DataAtualizacao = GETDATE()
    WHERE Id = @Id
END
GO

-- Stored Procedure for RemoveAsync
CREATE PROCEDURE RemoveMensagem
    @Id uniqueidentifier
AS
BEGIN
    DELETE FROM Mensagens WHERE Id = @Id
END
GO
