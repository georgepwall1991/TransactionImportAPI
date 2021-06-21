using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionImportAPI.Domain
{
    public interface IGetTransactionService
    {
        public List<Data.DTO.Transaction> GetAllTransactions();
        public List<Data.DTO.Transaction> GetAllTransactionsByCurrency();
        public List<Data.DTO.Transaction> GetAllTransactionsByDateRange(DateTime startDate, DateTime endDate);
        public List<Data.DTO.Transaction> GetAllTransactionsByTransactionStatus(string transactionStatus);

    }
}
