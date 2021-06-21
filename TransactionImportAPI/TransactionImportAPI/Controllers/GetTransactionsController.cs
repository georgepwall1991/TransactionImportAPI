using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TransactionImportAPI.Data.DTO.Requests;
using TransactionImportAPI.Domain;

namespace TransactionImportAPI.Controllers
{
    [ApiController]
    public class GetTransactionsController : ControllerBase
    {
        private readonly ILogger<GetTransactionsController> _logger;
        private readonly IGetTransactionService _getTransactionService;

        public GetTransactionsController(
            ILogger<GetTransactionsController> _logger,
            IGetTransactionService _getTransactionService)
        {
            this._logger = _logger;
            this._getTransactionService = _getTransactionService;
        }

        [HttpGet]
        [Route("Api/GetAllTransactions")]
        public async Task<IActionResult> Get()
        {
            var allTransactions = await _getTransactionService.GetAllTransactions();
            if (!allTransactions.Any()) _logger.LogInformation("No transactions - Please check database");

            _logger.LogInformation($"{allTransactions.Count} Transaction Values returned to user");
            return Ok(allTransactions);
        }

        [HttpGet]
        [Route("Api/GetAllTransactionsByDate")]
        public async Task<IActionResult> Get([FromBody] GetTransactionsRequestDate request)
        {
            if (!DateTime.TryParseExact(
                request.TransactionStartDate,
                "dd/MM/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var startDate))
                return BadRequest();

            if (!DateTime.TryParseExact(
                request.TransactionEndDate,
                "dd/MM/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var endDate))
                return BadRequest();

            var allTransactions = await _getTransactionService.GetAllTransactionsByDateRange(startDate, endDate);
            if (!allTransactions.Any()) _logger.LogInformation($"No transactions - Please check database for transactions between {request.TransactionStartDate} and {request.TransactionEndDate}");

            _logger.LogInformation($"{allTransactions.Count} Transaction Values returned to user between {request.TransactionStartDate} and {request.TransactionEndDate}");
            return Ok(allTransactions);
        }
        
    }
}