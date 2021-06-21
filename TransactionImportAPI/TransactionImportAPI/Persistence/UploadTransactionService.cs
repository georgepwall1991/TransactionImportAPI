using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionImportAPI.Data.DTO;
using TransactionImportAPI.Domain;

namespace TransactionImportAPI.Persistence
{
    public class UploadTransactionService : IUploadTransactionService
    {
        private readonly IUploadTransactionService _transactionService;

        public UploadTransactionService(IUploadTransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public Task<bool> UploadTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
