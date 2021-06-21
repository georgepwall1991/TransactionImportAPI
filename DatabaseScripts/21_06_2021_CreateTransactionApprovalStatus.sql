USE TransactionDB;
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'ApprovalStatus')
BEGIN
	CREATE TABLE [Transactions].[ApprovalStatus] ([Id] UniqueIdentifier DEFAULT NEWID() PRIMARY KEY CLUSTERED, -- Not best practice to use GUID as a clustered primary key could do INT IDENTITY(1,1) 
												  [Status] NVARCHAR(20))
END
