using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionImportAPI.Data.DTO;
using TransactionImportAPI.Domain;
using TransactionImportAPI.Model;

namespace TransactionImportAPI.Persistence
{
    public class GetTransactionService : IGetTransactionService
    {
        private readonly TransactionDbContext _transactionDbContext;

        public GetTransactionService(TransactionDbContext transactionDbContext)
        {
            _transactionDbContext = transactionDbContext;
        }

        public List<Transaction> GetAllTransactions()
        {
            throw new NotImplementedException();
        }

        public List<Transaction> GetAllTransactionsByCurrency()
        {
            throw new NotImplementedException();
        }

        public List<Transaction> GetAllTransactionsByDateRange(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public List<Transaction> GetAllTransactionsByTransactionStatus(string transactionStatus)
        {
            throw new NotImplementedException();
        }
    }
}
