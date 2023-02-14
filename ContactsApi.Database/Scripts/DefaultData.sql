USE [Contacts]
GO
SET IDENTITY_INSERT [dbo].[Countries] ON 
GO
INSERT [dbo].[Countries] ([Id], [Name]) VALUES (1, N'US')
GO
INSERT [dbo].[Countries] ([Id], [Name]) VALUES (2, N'France')
GO
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO
SET IDENTITY_INSERT [dbo].[States] ON 
GO
INSERT [dbo].[States] ([Id], [CountryId], [Name]) VALUES (1, 1, N'NY')
GO
INSERT [dbo].[States] ([Id], [CountryId], [Name]) VALUES (2, 1, N'Utah')
GO
SET IDENTITY_INSERT [dbo].[States] OFF
GO
SET IDENTITY_INSERT [dbo].[Companies] ON 
GO
INSERT [dbo].[Companies] ([Id], [Name], [CountryId], [StateId], [ZipCode], [CompanyType], [City], [CompanyMainLine]) VALUES (1, N'Blackstone', 1, 2, N'221B', 0, N'NewYork', N'+999999')
GO
INSERT [dbo].[Companies] ([Id], [Name], [CountryId], [StateId], [ZipCode], [CompanyType], [City], [CompanyMainLine]) VALUES (2, N'New Company 2', 1, 2, N'221B', 1, N'NewYork', N'+999999')
GO
INSERT [dbo].[Companies] ([Id], [Name], [CountryId], [StateId], [ZipCode], [CompanyType], [City], [CompanyMainLine]) VALUES (3, N'Solar', 2, NULL, N'221B', 1, N'Paris', N'+999999')
GO
INSERT [dbo].[Companies] ([Id], [Name], [CountryId], [StateId], [ZipCode], [CompanyType], [City], [CompanyMainLine]) VALUES (4, N'Comp', 1, 1, N'DFDFD', 0, N'City', N'65465465475')
GO
SET IDENTITY_INSERT [dbo].[Companies] OFF
GO
SET IDENTITY_INSERT [dbo].[Contacts] ON 
GO
INSERT [dbo].[Contacts] ([Id], [FirstName], [LastName], [MiddleName], [TitleType], [Notes], [CountryId], [ZipCode], [Address], [StateId], [City], [PersonalMobile1], [PersonalMobile2], [HomePhone], [LinkedIn], [PersonalEmail], [DateOfBirth], [CreateDate], [LastContactedDate]) VALUES (1, N'David', N'Mrejen', null, 0, N'Lorem upsum dolor sit amet', 1, N'12HB', N'Downing Street 221B', 2, N'NewYork', N'+221', N'+5439578439758475843789', N'567890', N'https://linkedin.com', N'sam@yahha.com', CAST(N'1990-02-13T00:00:00.000' AS DateTime), CAST(N'2023-02-14T03:01:02.277' AS DateTime), CAST(N'2023-02-14T03:01:02.277' AS DateTime))
GO
INSERT [dbo].[Contacts] ([Id], [FirstName], [LastName], [MiddleName], [TitleType], [Notes], [CountryId], [ZipCode], [Address], [StateId], [City], [PersonalMobile1], [PersonalMobile2], [HomePhone], [LinkedIn], [PersonalEmail], [DateOfBirth], [CreateDate], [LastContactedDate]) VALUES (2, N'Ben', N'Jones', null, 0, null, 1, N'12HB', N'Downing Street 221B', 2, N'NewYork', N'+221', null, N'567890', null, N'sam@yahha3.com', CAST(N'1990-02-13T00:00:00.000' AS DateTime), CAST(N'2023-02-14T03:02:44.717' AS DateTime), CAST(N'2023-02-14T03:02:44.717' AS DateTime))
GO
INSERT [dbo].[Contacts] ([Id], [FirstName], [LastName], [MiddleName], [TitleType], [Notes], [CountryId], [ZipCode], [Address], [StateId], [City], [PersonalMobile1], [PersonalMobile2], [HomePhone], [LinkedIn], [PersonalEmail], [DateOfBirth], [CreateDate], [LastContactedDate]) VALUES (3, N'Mickael', N'Buffett', null, 0, N'Lorem upsum', 1, N'12HB', N'Downing Street 221B', 2, N'NewYork', N'+221', N'+5439578439758475843789', N'567890', N'https://linkedin2.com', N'sam@yahha3.com', CAST(N'1990-02-13T00:00:00.000' AS DateTime), CAST(N'2023-02-14T03:04:16.437' AS DateTime), CAST(N'2023-02-14T03:04:16.437' AS DateTime))
GO
INSERT [dbo].[Contacts] ([Id], [FirstName], [LastName], [MiddleName], [TitleType], [Notes], [CountryId], [ZipCode], [Address], [StateId], [City], [PersonalMobile1], [PersonalMobile2], [HomePhone], [LinkedIn], [PersonalEmail], [DateOfBirth], [CreateDate], [LastContactedDate]) VALUES (4, N'John', N'Noy', N'Jack', 0, N'summary', 1, N'NNNM', N'street', 1, N'Town', N'+100000000000', N'65465465465465', N'654765765', N'https://test', N'my@mail.uu', CAST(N'1980-02-13T22:39:02.760' AS DateTime), CAST(N'2023-02-14T04:43:23.320' AS DateTime), CAST(N'2023-02-14T04:43:23.320' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Contacts] OFF
GO
SET IDENTITY_INSERT [dbo].[CompanyContacts] ON 
GO
INSERT [dbo].[CompanyContacts] ([Id], [CompanyId], [ContactId], [Position], [Department], [Email], [DirectLine], [Mobile], [SecondLine]) VALUES (1, 1, 1, N'CEO', N'Main', N'comp@yahha.com', N'9999', N'8888', N'77777')
GO
INSERT [dbo].[CompanyContacts] ([Id], [CompanyId], [ContactId], [Position], [Department], [Email], [DirectLine], [Mobile], [SecondLine]) VALUES (2, 2, 2, N'CEO', N'Main', N'comp@yahha3.com', N'9999', N'8888', N'77777')
GO
INSERT [dbo].[CompanyContacts] ([Id], [CompanyId], [ContactId], [Position], [Department], [Email], [DirectLine], [Mobile], [SecondLine]) VALUES (3, 3, 3, N'Engineer', N'Dev', N'comp@yahha3.com', N'9999', N'8888', N'77777')
GO
INSERT [dbo].[CompanyContacts] ([Id], [CompanyId], [ContactId], [Position], [Department], [Email], [DirectLine], [Mobile], [SecondLine]) VALUES (4, 4, 4, N'Director', N'Dev', N'dev@mail.uu', N'123', N'23', N'3333')
GO
INSERT [dbo].[CompanyContacts] ([Id], [CompanyId], [ContactId], [Position], [Department], [Email], [DirectLine], [Mobile], [SecondLine]) VALUES (5, 1, 2, N'Manager', N'Finacial', N'manager@mail.uu', N'+999', null, null)
GO
INSERT [dbo].[CompanyContacts] ([Id], [CompanyId], [ContactId], [Position], [Department], [Email], [DirectLine], [Mobile], [SecondLine]) VALUES (6, 1, 3, N'Delivery Manager', N'Support', N'support@mail.uu', N'+9991', null, null)
GO
SET IDENTITY_INSERT [dbo].[CompanyContacts] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [Email], [Password]) VALUES (1, N'support@yahha.com', N'UQmG63ZkcPpcztxQrMiP/297hzZVLj97WP6bDNn7Y3w=')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
