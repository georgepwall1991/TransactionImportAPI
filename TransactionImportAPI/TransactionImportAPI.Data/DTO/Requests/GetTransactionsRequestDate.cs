using System;

namespace TransactionImportAPI.Data.DTO.Requests;

public record GetTransactionsRequestDate(DateTime TransactionStartDate, DateTime TransactionEndDate);