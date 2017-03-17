--ATENÇÃO EXECUTE PELA ORDEM--
--Star--
CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId]    NVARCHAR (150)  NOT NULL,
    [ContextKey]     NVARCHAR (300)  NOT NULL,
    [Model]          VARBINARY (MAX) NOT NULL,
    [ProductVersion] NVARCHAR (32)   NOT NULL,
    CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED ([MigrationId] ASC, [ContextKey] ASC)
);
--End--



--Star--
CREATE TABLE [dbo].[AspNetUsers] (
    [Id]                   NVARCHAR (128) NOT NULL,
    [Hometown]             NVARCHAR (MAX) NULL,
    [Email]                NVARCHAR (256) NULL,
    [EmailConfirmed]       BIT            NOT NULL,
    [PasswordHash]         NVARCHAR (MAX) NULL,
    [SecurityStamp]        NVARCHAR (MAX) NULL,
    [PhoneNumber]          NVARCHAR (MAX) NULL,
    [PhoneNumberConfirmed] BIT            NOT NULL,
    [TwoFactorEnabled]     BIT            NOT NULL,
    [LockoutEndDateUtc]    DATETIME       NULL,
    [LockoutEnabled]       BIT            NOT NULL,
    [AccessFailedCount]    INT            NOT NULL,
    [UserName]             NVARCHAR (256) NOT NULL,
    [Nome]                 VARCHAR (100)  NULL,
    [CPF]                  NCHAR (14)     NULL,
    [DataNascimento]       DATETIME       NULL,
    [Sexo]                 NCHAR (1)      NULL,
    [Foto]                 NCHAR (50)     NULL,
    CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC)
);
--End--


--Star--
CREATE TABLE [dbo].[AspNetRoles] (
    [Id]   NVARCHAR (128) NOT NULL,
    [Name] NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED ([Id] ASC)
);
--End--


--Star--
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [UserId]     NVARCHAR (128) NOT NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);
--End--


--Star--
CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] NVARCHAR (128) NOT NULL,
    [ProviderKey]   NVARCHAR (128) NOT NULL,
    [UserId]        NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED ([LoginProvider] ASC, [ProviderKey] ASC, [UserId] ASC),
    CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);
--End--


--Star--
CREATE TABLE [dbo].[AspNetUserRoles] (
    [UserId] NVARCHAR (128) NOT NULL,
    [RoleId] NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
    CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);
--End--


--Star--
CREATE TABLE [dbo].[Categoria] (
    [ID]           INT          IDENTITY (1, 1) NOT NULL,
    [Nome]         VARCHAR (30) NOT NULL,
    [ID_Categoria] INT          NULL,
    CONSTRAINT [PK_Id] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [Fk_Categoria] FOREIGN KEY ([ID_Categoria]) REFERENCES [dbo].[Categoria] ([ID])
);
--End--


--Star--
CREATE TABLE [dbo].[Desafio] (
    [IdDesafio]    INT            IDENTITY (1, 1) NOT NULL,
    [Titulo]       NVARCHAR (100) NOT NULL,
    [Rank]         FLOAT (53)     NULL,
    [Conteudo]     TEXT           NOT NULL,
    [IDUsuario]    NVARCHAR (128) NOT NULL,
    [IDCategoria]  INT            NULL,
    [DataPostagem] DATETIME       NULL,
    [Dicas]        TEXT           NULL,
    PRIMARY KEY CLUSTERED ([IdDesafio] ASC),
    CONSTRAINT [FK_Desafio_Categoria] FOREIGN KEY ([IDCategoria]) REFERENCES [dbo].[Categoria] ([ID]),
    CONSTRAINT [FK_Desafio_Usuario] FOREIGN KEY ([IDUsuario]) REFERENCES [dbo].[AspNetUsers] ([Id])
);
--End--


--Star--
CREATE TABLE [dbo].[Comentario] (
    [IdComentario]   INT            IDENTITY (1, 1) NOT NULL,
    [Conteudo]       TEXT           NULL,
    [IDUsuario]      NVARCHAR (128) NOT NULL,
    [DataComentario] DATETIME       NULL,
    [IDDesafio]      INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([IdComentario] ASC),
    CONSTRAINT [FK_Comentario_Desafio] FOREIGN KEY ([IDDesafio]) REFERENCES [dbo].[Desafio] ([IdDesafio]),
    CONSTRAINT [FK_Comentario_Usuario] FOREIGN KEY ([IDUsuario]) REFERENCES [dbo].[AspNetUsers] ([Id])
);
--End--
