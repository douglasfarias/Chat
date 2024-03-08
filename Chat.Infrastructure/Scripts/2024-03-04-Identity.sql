IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Papeis] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_Papeis] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Usuarios] (
    [Id] nvarchar(450) NOT NULL,
    [UserName] nvarchar(256) NULL,
    [NormalizedUserName] nvarchar(256) NULL,
    [Email] nvarchar(256) NULL,
    [NormalizedEmail] nvarchar(256) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [ReivindicacoesDePapeis] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_ReivindicacoesDePapeis] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ReivindicacoesDePapeis_Papeis_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Papeis] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [LoginsDoUsuario] (
    [LoginProvider] nvarchar(450) NOT NULL,
    [ProviderKey] nvarchar(450) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_LoginsDoUsuario] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_LoginsDoUsuario_Usuarios_UserId] FOREIGN KEY ([UserId]) REFERENCES [Usuarios] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [PapeisDoUsuario] (
    [UserId] nvarchar(450) NOT NULL,
    [RoleId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_PapeisDoUsuario] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_PapeisDoUsuario_Papeis_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Papeis] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PapeisDoUsuario_Usuarios_UserId] FOREIGN KEY ([UserId]) REFERENCES [Usuarios] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [ReivindicacoesDoUsuario] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_ReivindicacoesDoUsuario] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ReivindicacoesDoUsuario_Usuarios_UserId] FOREIGN KEY ([UserId]) REFERENCES [Usuarios] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [TokensDoUsuario] (
    [UserId] nvarchar(450) NOT NULL,
    [LoginProvider] nvarchar(450) NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_TokensDoUsuario] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_TokensDoUsuario_Usuarios_UserId] FOREIGN KEY ([UserId]) REFERENCES [Usuarios] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_LoginsDoUsuario_UserId] ON [LoginsDoUsuario] ([UserId]);
GO

CREATE UNIQUE INDEX [RoleNameIndex] ON [Papeis] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
GO

CREATE INDEX [IX_PapeisDoUsuario_RoleId] ON [PapeisDoUsuario] ([RoleId]);
GO

CREATE INDEX [IX_ReivindicacoesDePapeis_RoleId] ON [ReivindicacoesDePapeis] ([RoleId]);
GO

CREATE INDEX [IX_ReivindicacoesDoUsuario_UserId] ON [ReivindicacoesDoUsuario] ([UserId]);
GO

CREATE INDEX [EmailIndex] ON [Usuarios] ([NormalizedEmail]);
GO

CREATE UNIQUE INDEX [UserNameIndex] ON [Usuarios] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240308015502_Authorization', N'8.0.2');
GO

COMMIT;
GO