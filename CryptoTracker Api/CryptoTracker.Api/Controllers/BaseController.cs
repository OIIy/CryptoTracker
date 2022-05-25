using CryptoTracker.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoTracker.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly IMemoryCache cache;

        public BaseController(IMemoryCache cache)
        {
            this.cache = cache;
        }

        [HttpGet]
        [Route("cache/dispose")]
        public async Task<ActionResult> Get()
        {
            cache.Dispose();

            return Ok("Disposed");
        }
    }
}
