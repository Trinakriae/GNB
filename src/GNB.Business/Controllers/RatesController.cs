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
    public class RatesController : ControllerBase
    {
        private readonly ILogger<RatesController> _logger;
        private readonly IRatesService _ratesService;

        public RatesController(ILogger<RatesController> logger, IRatesService ratesService)
        {
            _logger = logger;
            _ratesService = ratesService;
        }

        // GET: api/rates
        [HttpGet()]
        public async Task GetRates()
        {
            _logger.LogInformation("Rates");
            throw new NotImplementedException();
        }
    }
}