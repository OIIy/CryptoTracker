using CryptoTracker.Api;
using CryptoTracker.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoTracker.Api.Interfaces
{
    public interface ICryptoClient
    {
        public Task<string> GetOHLC(string coin, string pair);
    }
}
