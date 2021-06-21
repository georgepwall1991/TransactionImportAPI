IF DB_ID('TransactionDB') IS NULL
BEGIN
	CREATE DATABASE TransactionDB;
END
