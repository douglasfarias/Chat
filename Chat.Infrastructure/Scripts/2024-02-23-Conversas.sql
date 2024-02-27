CREATE TABLE Conversas
(
    Id uniqueidentifier PRIMARY KEY,
    ContatoId uniqueidentifier FOREIGN KEY references Contatos(Id),
    Titulo nvarchar(50),
    DataCriacao datetime,
    DataAtualizacao datetime
)
GO

CREATE PROCEDURE GetAllConversas
AS
BEGIN
    SELECT 
        Id,
        Titulo,
        DataCriacao,
        DataAtualizacao,
        ContatoId
    FROM Conversas
END
GO

CREATE PROCEDURE GetConversaById
    @Id uniqueidentifier
AS
BEGIN
    SELECT
        Id,
        Titulo,
        DataCriacao,
        DataAtualizacao,
        ContatoId
    FROM Conversas WHERE Id = @Id
END
GO

CREATE PROCEDURE AddConversa
    @Id uniqueidentifier,
    @ContatoId uniqueidentifier,
    @Titulo nvarchar(50)
AS
BEGIN
    INSERT INTO Conversas(Id, ContatoId, Titulo, DataCriacao) VALUES(@Id, @ContatoId, @Titulo, GETDATE())
END
GO


CREATE PROCEDURE UpdateConversa
    @Id uniqueidentifier,
    @Titulo nvarchar(50)
AS
BEGIN
    UPDATE Conversas SET Titulo = @Titulo, DataAtualizacao = GETDATE() WHERE Id = @Id
END
GO

CREATE PROCEDURE RemoveConversa
    @Id uniqueidentifier
AS
BEGIN
    DELETE FROM Conversas WHERE Id = @Id
END
GO