USE [master]
GO

CREATE DATABASE [SEOProject_PSterry]
GO

USE [SEOProject_PSterry]
GO

/* DROP TABLE [dbo].[SearchEngines] */
CREATE TABLE [dbo].[SearchEngines](
	[SearchEngineId] [uniqueidentifier] NOT NULL DEFAULT NEWID(),
	[SearchEngineClusteredId] [int] IDENTITY(1,1) NOT NULL,
	[SearchEngineName] [varchar](200) NOT NULL,
	[BaseUrl] [varchar](200) NOT NULL,
	[SearchQueryStringTemplate] [varchar](200) NOT NULL,
	[ResultUrlExtractionRegEx] [varchar](200) NOT NULL,
	CONSTRAINT PK_SearchEngines_SearchEngineId PRIMARY KEY NONCLUSTERED (SearchEngineId)
) ON [PRIMARY]
GO

CREATE CLUSTERED INDEX CIX_SearchEngines_SearchEngineClusteredId ON [dbo].[SearchEngines] (SearchEngineClusteredId)
GO

INSERT INTO [dbo].[SearchEngines]
           ([SearchEngineName]
           ,[BaseUrl]
           ,[SearchQueryStringTemplate]
           ,[ResultUrlExtractionRegEx])
     VALUES
           ('Google'
           ,'https://www.google.co.uk/'
           ,'search?num=[maxresults]&q=[searchtext]'
           ,'YT"><a href="\/url\?q=(.+?)&sa=U')

INSERT INTO [dbo].[SearchEngines]
           ([SearchEngineName]
           ,[BaseUrl]
           ,[SearchQueryStringTemplate]
           ,[ResultUrlExtractionRegEx])
     VALUES
           ('Bing'
           ,'https://www.bing.com/'
           ,'search?q=[searchtext]'
           ,'<cite>(.+?)</cite>')
GO

/* DROP TABLE [dbo].[SeoSearchHistory] */
CREATE TABLE [dbo].[SeoSearchHistory](
	[SeoSearchHistoryId] [uniqueidentifier] NOT NULL DEFAULT NEWID(),
	[SeoSearchHistoryClusteredId] [int] IDENTITY(1,1) NOT NULL,
	[SearchEngineId] [uniqueidentifier] NOT NULL,
	[SeoSearchText] [varchar](200) NOT NULL,
	[TargetUrl] [varchar](200) NOT NULL,
	[SeoSearchDate] datetime NOT NULL,
	CONSTRAINT PK_SeoSearchHistory_SeoSearchHistoryId PRIMARY KEY NONCLUSTERED (SeoSearchHistoryId)
) ON [PRIMARY]

CREATE CLUSTERED INDEX CIX_SeoSearchHistory_SeoSearchHistoryClusteredId ON [dbo].[SeoSearchHistory] (SeoSearchHistoryClusteredId)
GO

/* DROP TABLE [dbo].[SeoSearchHistoryResults] */
CREATE TABLE [dbo].[SeoSearchHistoryResults](
	[SeoSearchHistoryResultId] [uniqueidentifier] NOT NULL DEFAULT NEWID(),
	[SeoSearchHistoryResultClusteredId] [int] IDENTITY(1,1) NOT NULL,
	[SeoSearchHistoryId] [uniqueidentifier] NOT NULL,
	[SeoSearchResultRank] [int] NOT NULL,
	CONSTRAINT PK_SeoSearchHistoryResults_SeoSearchHistoryResultId PRIMARY KEY NONCLUSTERED (SeoSearchHistoryResultId)
) ON [PRIMARY]

CREATE CLUSTERED INDEX CIX_SeoSearchHistoryResults_SeoSearchHistoryResultClusteredId ON [dbo].[SeoSearchHistoryResults] (SeoSearchHistoryResultClusteredId)
GO

/*
SELECT * FROM [SEOProject_PSterry].[dbo].[SearchEngines]
SELECT * FROM [dbo].[SeoSearchHistory]
SELECT * FROM [dbo].[SeoSearchHistoryResults]
*/
