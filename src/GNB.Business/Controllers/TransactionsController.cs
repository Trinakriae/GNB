using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GNB.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GNB.Business.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ILogger<TransactionsController> _logger;
        private readonly ITransactionsService _transactionsService;
        private readonly IRatesService _ratesService;

        public TransactionsController(ILogger<TransactionsController> logger, ITransactionsService transactionsService, IRatesService ratesService)
        {
            _logger = logger;
            _transactionsService = transactionsService;
            _ratesService = ratesService;
        }

        // GET: api/transactions
        [HttpGet()]
        public async Task GetTransactions()
        {
            throw new NotImplementedException();
        }

        // GET: api/transactions/T2006
        [HttpGet("{SKU}")]
        public async Task GetTransactionBySKU(string SKU)
        {
            throw new NotImplementedException();
        }
    }
}