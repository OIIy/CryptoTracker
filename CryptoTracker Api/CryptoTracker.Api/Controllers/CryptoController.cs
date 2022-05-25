using CryptoTracker.Api.Interfaces;
using CryptoTracker.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CryptoTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class CryptoController : ControllerBase
    {
        private readonly ILogger<CryptoController> logger;
        private readonly ICryptoClient cryptoClient;
        private readonly DataContext dataContext;
        private readonly IMemoryCache cache;

        public CryptoController(
            ILogger<CryptoController> logger, 
            ICryptoClient cryptoClient,
            DataContext dataContext,
            IMemoryCache cache)
        {
            this.cache = cache;
            this.logger = logger;
            this.cryptoClient = cryptoClient;
            this.dataContext = dataContext;
        }

        [HttpGet]
        [Route("list")]
        public async Task<string> Get()
        {
            string cacheKey = "BNC_Code_List";
            List<BNC_Code> cryptoList = new List<BNC_Code>();

            // If object does not exist in cache then perform query
            if (!cache.TryGetValue(cacheKey, out List<BNC_Code> BNC_codeList))
            {
                cryptoList = dataContext.BNC_Codes.ToList();

                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(3));

                string cryptoListJson = JsonSerializer.Serialize(cryptoList);

                // Update cache with object
                cache.Set(cacheKey, cryptoListJson, cacheEntryOptions);
            }

            // Otherwise just get the object from the cache
            var response = (string)cache.Get(cacheKey);
            
            return response;
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

            var response = await cryptoClient.GetOHLC(BNC2Code);

            //TODO: Do some server side processing to format the column names and values

            return response;
        }
    }
}
