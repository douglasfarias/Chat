CREATE TABLE Contatos
(
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Nome NVARCHAR(50),
    Email NVARCHAR(50),
    DataCriacao DATETIME,
    DataAtualizacao DATETIME NULL
)

GO

CREATE PROCEDURE GetAllContatos
AS
BEGIN
    SELECT * FROM Contatos
END
GO

CREATE PROCEDURE GetContatoById
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SELECT * FROM Contatos WHERE Id = @Id
END
GO

CREATE PROCEDURE AddContato
    @Id UNIQUEIDENTIFIER,
    @Nome NVARCHAR(50),
    @Email NVARCHAR(50)
AS
BEGIN
    INSERT INTO Contatos (Id, Nome, Email, DataCriacao)
    VALUES (@Id, @Nome, @Email, GETDATE())
END
GO

CREATE PROCEDURE UpdateContato
    @Id UNIQUEIDENTIFIER,
    @Nome NVARCHAR(50),
    @Email NVARCHAR(50)
AS
BEGIN
    UPDATE Contatos
    SET Nome = @Nome, Email = @Email, DataAtualizacao = GETDATE()
    WHERE Id = @Id
END
GO

CREATE PROCEDURE RemoveContato
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    DELETE FROM Contatos WHERE Id = @Id
END
GO
