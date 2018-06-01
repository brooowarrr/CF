CREATE procedure [dbo].[GetItem]
	@Id int
AS
BEGIN
	SELECT [Id]
		  ,[Name]
	  FROM [dbo].[Items]
	WHERE Id = @Id;

END
