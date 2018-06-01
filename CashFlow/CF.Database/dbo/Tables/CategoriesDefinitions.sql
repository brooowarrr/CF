CREATE TABLE [dbo].[CategoriesDefinitions] (
    [Id]            INT          IDENTITY (1, 1) NOT NULL,
    [CategoryId]     INT          NOT NULL,
    [ItemId]     INT          NOT NULL,
    CONSTRAINT [PK_CategoriesDefinitions] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CategoriesDefinitions_Categories] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([Id]),
    CONSTRAINT [FK_CategoriesDefinitions_Items] FOREIGN KEY (ItemId) REFERENCES [dbo].[Items] ([Id])
);

