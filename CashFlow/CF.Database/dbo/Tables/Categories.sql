CREATE TABLE [dbo].[Categories] (
    [Id]            INT          IDENTITY (1, 1) NOT NULL,
    [Name]   VARCHAR (256) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([Id] ASC),
);

