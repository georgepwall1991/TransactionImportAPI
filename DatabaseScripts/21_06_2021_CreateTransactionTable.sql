USE TransactionDB
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Transaction')
BEGIN
	CREATE TABLE Transactions.[Transaction] (TransactionIdentifier NVARCHAR(50) PRIMARY KEY CLUSTERED,
										     Amount Decimal,
										     ISOCodeId UniqueIdentifier, -- ISO4217 is 3 letters max i.e. GBP / USD 
										     TransactionDate DATETIME2,
										     TransactionStatusId UniqueIdentifier,
											 CONSTRAINT FK_ISOCode FOREIGN KEY (ISOCodeId) REFERENCES Transactions.Country(Id),
											 CONSTRAINT FK_TransactionStatus FOREIGN KEY (TransactionStatusId) REFERENCES Transactions.ApprovalStatus(Id))
END