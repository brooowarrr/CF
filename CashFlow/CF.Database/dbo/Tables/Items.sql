CREATE TABLE [dbo].[Items] (
    [Id]            INT          IDENTITY (1, 1) NOT NULL,
    [Name]   VARCHAR (256) NOT NULL,
    CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED ([Id] ASC),
);

