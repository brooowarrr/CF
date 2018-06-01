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

