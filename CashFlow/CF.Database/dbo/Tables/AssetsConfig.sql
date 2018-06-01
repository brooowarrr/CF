CREATE TABLE [dbo].[AssetsConfig] (
    [Id]            INT          IDENTITY (1, 1) NOT NULL,
    [ItemId] 	INT 	NOT NULL,
    CONSTRAINT [PK_AssetsConfig] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_AssetsConfig_Items] FOREIGN KEY (ItemId) REFERENCES [dbo].[Items] ([Id])
);

