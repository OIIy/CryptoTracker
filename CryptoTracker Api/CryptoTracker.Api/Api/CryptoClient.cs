using CryptoTracker.Api.Interfaces;
using CryptoTracker.Api.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;

namespace CryptoTracker.Api
{
    public class CryptoClient : ICryptoClient
    {
        private readonly HttpClient _httpClient;
        public CryptoClient(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<string> GetOHLC(string coin, string pair)
        {
            UriBuilder uriBuilder = new UriBuilder(_httpClient.BaseAddress);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["date"] = "2022-01-26";
            query["code"] = "MWA_FTM_BTC";
            uriBuilder.Query = query.ToString();
            
            _httpClient.BaseAddress = uriBuilder.Uri;

            HttpResponseMessage response = await _httpClient.GetAsync("");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
        }
    }
}
