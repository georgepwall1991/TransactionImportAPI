IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Country')
BEGIN
	CREATE TABLE [Transactions].[Country] (Id UniqueIdentifier DEFAULT NEWID() PRIMARY KEY CLUSTERED, -- Not best practice to use GUID as a clustered primary key could do INT IDENTITY(1,1) 
										   ISOCode NVARCHAR(3),
										   CountryName NVARCHAR(100),
										   CurrencyName NVARCHAR(100))
END
