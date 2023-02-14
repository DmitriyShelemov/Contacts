CREATE TABLE [dbo].[Users](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](512) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Countries](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[States](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CountryId] [bigint] NOT NULL,
	[Name] [nvarchar](100) NOT NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[States] WITH CHECK ADD FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([Id])
GO

CREATE TABLE [dbo].[Companies](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[CountryId] [bigint] NOT NULL,
	[StateId] [bigint] NULL,
	[ZipCode] [nvarchar](50) NOT NULL,
	[CompanyType] [tinyint] NOT NULL,
	[City] [nvarchar](100) NOT NULL,
	[CompanyMainLine] [nvarchar](50) NOT NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Companies] WITH CHECK ADD FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([Id])
GO

ALTER TABLE [dbo].[Companies] WITH CHECK ADD FOREIGN KEY([StateId])
REFERENCES [dbo].[States] ([Id])
GO

CREATE TABLE [dbo].[Contacts](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[MiddleName] [nvarchar](100) NULL,
	[TitleType] [tinyint] NOT NULL,
	[Notes] [nvarchar](100) NULL,
	[CountryId] [bigint] NOT NULL,
	[ZipCode] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](512) NOT NULL,
	[StateId] [bigint] NULL,
	[City] [nvarchar](100) NOT NULL,
	[PersonalMobile1] [nvarchar](50) NULL,
	[PersonalMobile2] [nvarchar](50) NULL,
	[HomePhone] [nvarchar](50) NULL,
	[LinkedIn] [nvarchar](1024) NULL,
	[PersonalEmail] [nvarchar](100) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastContactedDate] [datetime] NOT NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CompanyContacts](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyId] [bigint] NOT NULL,
	[ContactId] [bigint] NOT NULL,
	[Position] [nvarchar](50) NOT NULL,
	[Department] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[DirectLine] [nvarchar](50) NOT NULL,
	[Mobile] [nvarchar](50) NULL,
	[SecondLine] [nvarchar](50) NULL
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CompanyContacts] WITH CHECK ADD FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
GO

ALTER TABLE [dbo].[CompanyContacts] WITH CHECK ADD FOREIGN KEY([ContactId])
REFERENCES [dbo].[Contacts] ([Id])
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_CompanyId_ContractId] ON [dbo].[CompanyContacts]
(
	[CompanyId] ASC,
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO