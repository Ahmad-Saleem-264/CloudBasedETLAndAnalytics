---- ========================================================================================
---- Create User as DBO template for Azure SQL Database and Azure SQL Data Warehouse Database
---- ========================================================================================
---- For login <login_name, sysname, login_name>, create a user in the database
--CREATE USER Hassaan
--	FOR LOGIN Hassaan
	

---- Add user to the database owner role
--EXEC sp_addrolemember N'db_owner', N'Hassaan'

---- ======================================================================================
---- Create SQL Login template for Azure SQL Database and Azure SQL Data Warehouse Database
---- ======================================================================================

--CREATE LOGIN Hassaan
--	WITH PASSWORD = 'HTS@1234' 

CREATE TABLE [dbo].[RepositoriesDemo]
(
	[RepoId] [bigint],
	[hostType] [nvarchar](50) NULL,
	[OwnerName] [nvarchar](100) NULL,
	[RepoName] [nvarchar](100) NULL,
	[createdTimeStamp] [datetime],
	[lastPushedTime] [datetime],	
	[starsCount] [bigint],
	[language] [nvarchar](50),
	[opneIssueCount] [int],
	[contributorsCount] [int],
	[status] [nvarchar](50),
	[SourceRank] [int],
	[keywords] [nvarchar](150),
	[license] [nvarchar] (100)
	
)