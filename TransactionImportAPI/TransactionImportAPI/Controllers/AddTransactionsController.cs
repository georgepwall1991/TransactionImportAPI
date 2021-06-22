using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TransactionImportAPI.Data.DTO;
using TransactionImportAPI.Data.DTO.Requests;
using TransactionImportAPI.Domain;

namespace TransactionImportAPI.Controllers
{
    [ApiController]
    public class AddTransactionsController : ControllerBase
    {
        private readonly ILogger<AddTransactionsController> _logger;
        private readonly IUploadTransactionService _addTransactionService;

        public AddTransactionsController(
            ILogger<AddTransactionsController> logger,
            IUploadTransactionService addTransactionService)
        {
            _logger = logger;
            _addTransactionService = addTransactionService;
        }

        [HttpPost]
        [Route("Api/AddTransactions")]
        public async Task<IActionResult> Post(Transaction transaction)
        {
            var allTransactions = await _addTransactionService.UploadTransaction(transaction);
            if (!allTransactions)
            {
                _logger.LogError("Failed to write to the database");
                return BadRequest();
            }

            _logger.LogInformation("Transaction saved to Database");

            return Ok();
        }

    }
}