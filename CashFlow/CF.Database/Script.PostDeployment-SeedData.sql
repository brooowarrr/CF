/*
Post-Deployment Script 
*/

/***** SEED DATA FOR Categories TABLE *****/
INSERT [dbo].[Categories] ( [Name]) VALUES (N'Assets')
INSERT [dbo].[Categories] ( [Name]) VALUES (N'Accommodation')
INSERT [dbo].[Categories] ( [Name]) VALUES (N'Bills')
INSERT [dbo].[Categories] ( [Name]) VALUES (N'Food')
INSERT [dbo].[Categories] ( [Name]) VALUES (N'Sport')
INSERT [dbo].[Categories] ( [Name]) VALUES (N'Clothes')
INSERT [dbo].[Categories] ( [Name]) VALUES (N'Health')
INSERT [dbo].[Categories] ( [Name]) VALUES (N'Work')
INSERT [dbo].[Categories] ( [Name]) VALUES (N'Stock Exchange')

/***** SEED DATA FOR [Items] TABLE *****/
INSERT [dbo].[Items] ( [Name]) VALUES (N'Supermarket')
INSERT [dbo].[Items] ( [Name]) VALUES (N'Junk food')

INSERT [dbo].[Items] ( [Name]) VALUES (N'Rent')
INSERT [dbo].[Items] ( [Name]) VALUES (N'Gas')
INSERT [dbo].[Items] ( [Name]) VALUES (N'Energy')
INSERT [dbo].[Items] ( [Name]) VALUES (N'Internet')

INSERT [dbo].[Items] ( [Name]) VALUES (N'Medicines')
INSERT [dbo].[Items] ( [Name]) VALUES (N'Doctor visit')

INSERT [dbo].[Items] ( [Name]) VALUES (N'Tennis')
INSERT [dbo].[Items] ( [Name]) VALUES (N'Multisport')
INSERT [dbo].[Items] ( [Name]) VALUES (N'Skiing')

INSERT [dbo].[Items] ( [Name]) VALUES (N'Cleaning supplies')

INSERT [dbo].[Items] ( [Name]) VALUES (N'Account')
INSERT [dbo].[Items] ( [Name]) VALUES (N'Cash')

INSERT [dbo].[Items] ( [Name]) VALUES (N'Jacket')
INSERT [dbo].[Items] ( [Name]) VALUES (N'T-shirt')
INSERT [dbo].[Items] ( [Name]) VALUES (N'Shoes')

INSERT [dbo].[Items] ( [Name]) VALUES (N'Salary')
INSERT [dbo].[Items] ( [Name]) VALUES (N'Bonus')
INSERT [dbo].[Items] ( [Name]) VALUES (N'Stock account')
INSERT [dbo].[Items] ( [Name]) VALUES (N'Investment')

INSERT [dbo].[Items] ( [Name]) VALUES (N'Account start')


/***** SEED DATA FOR CategoriesDefinitions TABLE *****/
INSERT [dbo].[CategoriesDefinitions] ([CategoryId], [ItemId]) VALUES (1, 13)
INSERT [dbo].[CategoriesDefinitions] ([CategoryId], [ItemId]) VALUES (1, 14)
INSERT [dbo].[CategoriesDefinitions] ([CategoryId], [ItemId]) VALUES (2, 3)
INSERT [dbo].[CategoriesDefinitions] ([CategoryId], [ItemId]) VALUES (2, 4)
INSERT [dbo].[CategoriesDefinitions] ([CategoryId], [ItemId]) VALUES (2, 5)
INSERT [dbo].[CategoriesDefinitions] ([CategoryId], [ItemId]) VALUES (2, 6)
INSERT [dbo].[CategoriesDefinitions] ([CategoryId], [ItemId]) VALUES (2, 12)
INSERT [dbo].[CategoriesDefinitions] ([CategoryId], [ItemId]) VALUES (3, 4)
INSERT [dbo].[CategoriesDefinitions] ([CategoryId], [ItemId]) VALUES (3, 5)
INSERT [dbo].[CategoriesDefinitions] ([CategoryId], [ItemId]) VALUES (3, 6)
INSERT [dbo].[CategoriesDefinitions] ([CategoryId], [ItemId]) VALUES (4, 1)
INSERT [dbo].[CategoriesDefinitions] ([CategoryId], [ItemId]) VALUES (4, 2)
INSERT [dbo].[CategoriesDefinitions] ([CategoryId], [ItemId]) VALUES (5, 9)
INSERT [dbo].[CategoriesDefinitions] ([CategoryId], [ItemId]) VALUES (5, 10)
INSERT [dbo].[CategoriesDefinitions] ([CategoryId], [ItemId]) VALUES (5, 11)
INSERT [dbo].[CategoriesDefinitions] ([CategoryId], [ItemId]) VALUES (6, 15)
INSERT [dbo].[CategoriesDefinitions] ([CategoryId], [ItemId]) VALUES (6, 16)
INSERT [dbo].[CategoriesDefinitions] ([CategoryId], [ItemId]) VALUES (6, 17)
INSERT [dbo].[CategoriesDefinitions] ([CategoryId], [ItemId]) VALUES (7, 7)
INSERT [dbo].[CategoriesDefinitions] ([CategoryId], [ItemId]) VALUES (7, 8)
INSERT [dbo].[CategoriesDefinitions] ([CategoryId], [ItemId]) VALUES (1, 20)
INSERT [dbo].[CategoriesDefinitions] ([CategoryId], [ItemId]) VALUES (8, 18)
INSERT [dbo].[CategoriesDefinitions] ([CategoryId], [ItemId]) VALUES (8, 19)
INSERT [dbo].[CategoriesDefinitions] ([CategoryId], [ItemId]) VALUES (9, 20)
INSERT [dbo].[CategoriesDefinitions] ([CategoryId], [ItemId]) VALUES (9, 21)


/***** SEED DATA FOR Transactions TABLE *****/
INSERT [dbo].[Transactions] ([Value], [SourceItemId], [TargetItemId], [Description], [DateCreated], [DateModified]) VALUES (50000, 22, 13, N'Poczatkowy stan konta', '2018-12-31 12:00:00', '2018-12-31 12:00:00')
INSERT [dbo].[Transactions] ([Value], [SourceItemId], [TargetItemId], [Description], [DateCreated], [DateModified]) VALUES (1000, 13, 14, N'Poczatkowy stan gotówki', '2018-12-31 12:00:00', '2018-12-31 12:00:00')
INSERT [dbo].[Transactions] ([Value], [SourceItemId], [TargetItemId], [Description], [DateCreated], [DateModified]) VALUES (10000, 13, 20, N'Przelew na rachunek giełdowy', '2018-12-31 13:00:00', '2018-12-31 13:00:00')



