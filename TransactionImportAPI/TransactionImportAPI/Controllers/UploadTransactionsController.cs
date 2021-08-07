using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TransactionImportAPI.Data.DTO;
using TransactionImportAPI.Domain;

namespace TransactionImportAPI.Controllers
{
    [ApiController]
    [Route("Api/UploadTransactions")]
    public class UploadTransactionsController : ControllerBase
    {
        private readonly ILogger<UploadTransactionsController> _logger;
        private readonly ITransactionService _transactionService;

        public UploadTransactionsController(ILogger<UploadTransactionsController> logger,
            ITransactionService transactionService)
        {
            _logger = logger;
            _transactionService = transactionService;
        }

        [HttpPost]
        [Route("UploadTransaction")]
        public async Task<IActionResult> Upload([FromBody] Transaction transaction)
        {
            var transactionPosted = await _transactionService.CreateAsync(transaction);
            if (transactionPosted != null) _logger.LogInformation("No transactions - Please check database");

            _logger.LogInformation($"{transactionPosted} Transaction Values returned to user");
            return Ok(transactionPosted);
        }
    }
}