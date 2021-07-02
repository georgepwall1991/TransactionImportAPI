using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionImportAPI.Domain
{
    public interface IGetTransactionService
    {
        public Task<List<Data.DTO.Transaction>> GetAllTransactions();
        public Task<List<Data.DTO.Transaction>> GetAllTransactionsByCurrency(string isoCode);
        public Task<List<Data.DTO.Transaction>> GetAllTransactionsByDateRange(DateTime startDate, DateTime endDate);

    }
}
