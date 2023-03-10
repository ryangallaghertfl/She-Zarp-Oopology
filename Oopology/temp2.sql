
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

CREATE TABLE [Course] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [Price] float NOT NULL,
    CONSTRAINT [PK_Course] PRIMARY KEY ([Id])
);
GO



CREATE TABLE [User] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [XpLevel] int NULL,
    [Email] nvarchar(max) NULL,
    [Password] nvarchar(max) NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Post] (
    [Id] int NOT NULL IDENTITY,
    [Content] nvarchar(max) NULL,
    [UserId] int NULL,
    [Likes] int NULL,
    CONSTRAINT [PK_Post] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Post_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id])
);
GO

CREATE TABLE [Comment] (
    [Id] int NOT NULL IDENTITY,
    [Content] nvarchar(max) NULL,
    [UserId] int NULL,
    [PostId] int NULL,
    CONSTRAINT [PK_Comment] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Comment_Post_PostId] FOREIGN KEY ([PostId]) REFERENCES [Post] ([Id]),
    CONSTRAINT [FK_Comment_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id])
);
GO

CREATE INDEX [IX_Comment_PostId] ON [Comment] ([PostId]);
GO

CREATE INDEX [IX_Comment_UserId] ON [Comment] ([UserId]);
GO

CREATE INDEX [IX_Post_UserId] ON [Post] ([UserId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230119102540_NewMigration', N'7.0.2');
GO

COMMIT;
GO


