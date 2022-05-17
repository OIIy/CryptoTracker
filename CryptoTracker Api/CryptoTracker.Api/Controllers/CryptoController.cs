using CryptoTracker.Api.Interfaces;
using CryptoTracker.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoTracker.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CryptoController : ControllerBase
    {
        private readonly ILogger<CryptoController> _logger;
        private readonly ICryptoClient _CryptoClient;

        public CryptoController(ILogger<CryptoController> logger, ICryptoClient cryptoClient)
        {
            _logger = logger;
            _CryptoClient = cryptoClient;
        }

        [HttpGet]
        public async Task<String> Get()
        {
            var response = await _CryptoClient.GetOHLC("ETH", "USDT");

            return response;
        }
    }
}
