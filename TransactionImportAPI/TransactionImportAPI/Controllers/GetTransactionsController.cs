using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TransactionImportAPI.Data.DTO.Requests;
using TransactionImportAPI.Domain;

namespace TransactionImportAPI.Controllers
{
    [ApiController]
    [Route("Api/GetTransactions")]
    public class GetTransactionsController : ControllerBase
    {
        private readonly ITransactionService _getTransactionService;
        private readonly ILogger<GetTransactionsController> _logger;

        public GetTransactionsController(
            ILogger<GetTransactionsController> logger,
            ITransactionService getTransactionService)
        {
            _logger = logger;
            _getTransactionService = getTransactionService;
        }

        [HttpGet]
        [Route("GetAllTransactions")]
        public async Task<IActionResult> Get()
        {
            var allTransactions = await _getTransactionService.GetAllAsync();
            if (!allTransactions.Any()) _logger.LogInformation("No transactions - Please check database");

            _logger.LogInformation($"{allTransactions.Count} Transaction Values returned to user");
            return Ok(allTransactions);
        }

        [HttpGet]
        [Route("GetAllTransactionsByDate")]
        public async Task<IActionResult>
            Get([FromQuery] GetTransactionsRequestDate request) // doesn't always handle casting string gracefully - created request object
        {
            var allTransactions =
                await _getTransactionService.GetAllTransactionsByDateRange(request.TransactionStartDate,
                    request.TransactionEndDate);
            if (!allTransactions.Any())
                _logger.LogInformation(
                    $"No transactions - Please check database for transactions between {request.TransactionStartDate} and {request.TransactionEndDate}");

            _logger.LogInformation(
                $"{allTransactions.Count} Transaction Values returned to user between {request.TransactionStartDate} and {request.TransactionEndDate}");
            return Ok(allTransactions);
        }

        [HttpGet]
        [Route("GetAllTransactionsByCurrency")]
        public async Task<IActionResult> Get(string isoCode)
        {
            try
            {

                var allTransactions = await _getTransactionService.GetAllTransactionsByCurrency(isoCode);
                if (!allTransactions.Any())
                {
                    _logger.LogInformation(
                        $"No transactions - Please check database for transactions with the ISO Code - {isoCode}");
                    return BadRequest("No values saved.");
                }

                _logger.LogInformation(
                    $"{allTransactions.Count} Transaction Values returned to user with ISO Code - {isoCode}");
                return Ok(allTransactions);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }
    }
}