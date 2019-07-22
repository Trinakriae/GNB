using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GNB.Business.Enums;
using GNB.Business.Interfaces;
using GNB.Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GNB.Business.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly ITransactionsService _transactionsService;
        private readonly ICalculatorService _calculatorService;
        private readonly IRatesService _ratesService;
        private readonly IPersistenceService _persistenceService;

        public ProductsController(ILogger<ProductsController> logger, ITransactionsService transactionsService, IRatesService ratesService, ICalculatorService calculatorService, IPersistenceService persistenceService)
        {
            _logger = logger;
            _transactionsService = transactionsService;
            _calculatorService = calculatorService;
            _ratesService = ratesService;
            _persistenceService = persistenceService;
        }

        // GET: api/products/transactions
        [HttpGet("transactions")]
        public async Task<IActionResult> GetTransactions()
        {
            try
            {
                IEnumerable<BusinessTransaction> transactions = await _transactionsService.GetTransactions();
                _persistenceService.SaveTransactions(transactions);
                return Ok(transactions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Peticion erronea");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET: api/products/rates
        [HttpGet("rates")]
        public async Task<IActionResult> GetRates()
        {
            try
            {
                IEnumerable<ConversionRate> rates = await _ratesService.GetConversionRates();
                _persistenceService.SaveRates(rates);
                return Ok(rates);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Peticion erronea");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET: api/products/total/T2006
        [HttpGet("total/{SKU}")]
        public async Task<IActionResult> GetTotalTransactionValueBySKU(string SKU)
        {
            try
            {
                IEnumerable<BusinessTransaction> transactions = await _transactionsService.GetTransactionsBySKU(SKU);
                if(transactions == null || transactions.Count() == 0)
                {
                    return NotFound();
                }
                IEnumerable<ConversionRate> rates = await _ratesService.GetConversionRates();

                IEnumerable<Amount> amounts = transactions.Select(t => new Amount { Value = t.Amount, Currency = t.Currency }); 

                return Ok(_calculatorService.ComputeTotalTransactionValueByCurrency(amounts, rates, CurrencyCode.EUR));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Peticion erronea");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}