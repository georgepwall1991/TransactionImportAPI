using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using TransactionImportAPI.Data.DTO;
using TransactionImportAPI.Domain;
using TransactionImportAPI.Model;

namespace TransactionImportAPI.Persistence
{
    public class UploadTransactionService : IUploadTransactionService
    {
        private readonly TransactionDbContext _transactionDBContext;

        public UploadTransactionService(TransactionDbContext transactionDBContext)
        {
            _transactionDBContext = transactionDBContext;
        }

        public Task<bool> UploadTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
