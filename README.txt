-- SOLUTION DESCRIPTION --

The solution is logically organised into these layers:

UI - User interface (MVC application)
BLL - Business Logic Layer
DAL - Data Access Layer
API - Application Programming Interface

Physically it is organised into these layers:

UI - User interface (MVC application)
API - Application Programming Interface
Data Storage - SQL Server Express

The solution showcases a distinct separation between logical layers (the BBL does not reference the DAL, and the DAL does not reference the BLL). Automapper is used map data between objects in the different layers.
The solution uses a factory pattern to create typed search engine objects from data stored within SQL Server and demonstrates inheritance and polymorphism.

The API does store the search results in a format that is suitable for analysis but this is not shown in the UI. Please use the following queries to see the stored data:

SELECT * FROM [SEOProject_PSterry].[dbo].[SearchEngines]
SELECT * FROM [dbo].[SeoSearchHistory]
SELECT * FROM [dbo].[SeoSearchHistoryResults]

Unit tests are included to ensure object property mapping is correct and the search and extraction functionality is as expected.
Please note that error and exception handling is not robust. Some elements are also hard-coded due to time.

-- SETTING UP THE ENVIRONMENT --

The solution uses SQL Server Express. The connection string is specified in the appsettings.json file of SEOProject.API and is given below for reference:

Server=localhost\\SQLEXPRESS;Database=SEOProject_PSterry;Trusted_Connection=True;Encrypt=False

To create and set up the database, please connect to SQL Server Express via SSMS and run the SQL contained in this file:

SEOProject_PSterry.sql

The file is located in the SqlServer folder of SEOProject.DAL
In file explorer, it is located in <DownloadPath>\SEOProject\SEOProject.DAL\SqlServer

Adequate permissions will be required in SQL Server to create the DB, schema, and data.

-- RUNNING THE APPLICATION --

The solution has 2 runnable projects. The solution is currently coded to use the URLs of the IIS Express runner:

SEOProject.API - https://localhost:44372/
SEOProject.MVC - https://localhost:44361/

Please set both of these as startup projects ensuring that the API has the startup precedence and that both projects are set to execute using IIS Express.













