using CryptoTracker.Api.Interfaces;
using CryptoTracker.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
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
        public async Task<String> Get(string coin = "BTC", string pair = "ETH")
        {
            //TODO: Default get should fetch top movers by default
            string BNC2Code = "MWA";

            if (string.IsNullOrEmpty(pair))
            {
                BNC2Code = "GWA";
            }

            BNC2Code = string.Format("{0}_{1}_{2}", BNC2Code, coin, pair);

            var response = await _CryptoClient.GetOHLC(BNC2Code);

            //TODO: Do some server side processing to format the column names and values

            return response;
        }
    }
}
