USE [CashFlowDB]
GO

CREATE TABLE [dbo].[Categories] (
    [Id]            INT          IDENTITY (1, 1) NOT NULL,
    [Name]   VARCHAR (256) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([Id] ASC),
);

CREATE TABLE [dbo].[Items] (
    [Id]            INT          IDENTITY (1, 1) NOT NULL,
    [Name]   VARCHAR (256) NOT NULL,
    CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED ([Id] ASC),
);

CREATE TABLE [dbo].[CategoriesDefinitions] (
    [Id]            INT          IDENTITY (1, 1) NOT NULL,
    [CategoryId]     INT          NOT NULL,
    [ItemId]     INT          NOT NULL,
    CONSTRAINT [PK_CategoriesDefinitions] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CategoriesDefinitions_Categories] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([Id]),
    CONSTRAINT [FK_CategoriesDefinitions_Items] FOREIGN KEY (ItemId) REFERENCES [dbo].[Items] ([Id])
);

CREATE TABLE [dbo].[Transactions] (
    [Id]            INT          IDENTITY (1, 1) NOT NULL,
    [Value]   DECIMAL(15,2) NOT NULL,	
    [SourceItemId] 	INT 	NOT NULL,
    [TargetItemId] 	INT 	NOT NULL,
    [Description]	NVARCHAR(256)  NOT  NULL,
    [DateCreated]	DATETIME    NOT NULL,
	[DateModified]	DATETIME    NOT NULL,

    CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Transactions_ItemsSource] FOREIGN KEY (SourceItemId) REFERENCES [dbo].[Items] ([Id]),
	CONSTRAINT [FK_Transactions_ItemsTarget] FOREIGN KEY (TargetItemId) REFERENCES [dbo].[Items] ([Id])
);

CREATE TABLE [dbo].[PendingTransactions] (
    [Id]            INT          IDENTITY (1, 1) NOT NULL,
    [Value]   DECIMAL(15,2) NOT NULL,	
    [SourceItemId] 	INT 	NOT NULL,
    [TargetItemId] 	INT 	NOT NULL,
    [Description]	NVARCHAR(256)  NOT  NULL,
    [DateCreated]	DATETIME    NOT NULL,
	[DateModified]	DATETIME    NOT NULL,
	[Finished] 	BIT	NOT NULL,
    CONSTRAINT [PK_PendingTransactions] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_PendingTransactions_ItemsSource] FOREIGN KEY (SourceItemId) REFERENCES [dbo].[Items] ([Id]),
	CONSTRAINT [FK_PendingTransactions_ItemsTarget] FOREIGN KEY (TargetItemId) REFERENCES [dbo].[Items] ([Id])
);

CREATE TABLE [dbo].[AssetsConfig] (
    [Id]            INT          IDENTITY (1, 1) NOT NULL,
    [ItemId] 	INT 	NOT NULL,
    CONSTRAINT [PK_AssetsConfig] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_AssetsConfig_Items] FOREIGN KEY (ItemId) REFERENCES [dbo].[Items] ([Id])
);


GO

