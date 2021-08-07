using System;

namespace TransactionImportAPI.Data.DTO.Requests
{
    public class GetTransactionsRequestDate
    {
        public DateTime TransactionStartDate { get; set; }
        public DateTime TransactionEndDate { get; set; }
    }
}