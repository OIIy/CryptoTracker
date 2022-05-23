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

        public async Task<string> GetOHLC(string BNC2Code)
        {
            // Write function to build string for API usage

            // Format today's date for date code

            // GWA - Global weighted average for price always USD
            // MWA - Daily market weighted average for a currency pair

            string date = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");

            UriBuilder uriBuilder = new UriBuilder(_httpClient.BaseAddress);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["code"] = BNC2Code;
            query["date"] = date;
            uriBuilder.Query = query.ToString();
            
            _httpClient.BaseAddress = uriBuilder.Uri;

            HttpResponseMessage response = await _httpClient.GetAsync("");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
        }
    }
}
