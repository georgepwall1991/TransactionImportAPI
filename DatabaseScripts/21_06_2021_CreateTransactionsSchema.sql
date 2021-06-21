IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'Transactions')
BEGIN
	EXEC('CREATE SCHEMA Transactions')
END