using CryptoTracker.Api.Interfaces;
using CryptoTracker.Api.Models;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;

        public CryptoClient(HttpClient httpClient, IConfiguration config)
        {
            _configuration = config;
            _httpClient = httpClient;
        } 

        public async Task<BNC_Datatable> GetOHLC(string BNC2Code)
        {
            UriBuilder uriBuilder = new UriBuilder(_httpClient.BaseAddress);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["api_key"] = _configuration["CryptoClient:ApiKey"];
            query["code"] = BNC2Code;
            var BNCQuery = query.ToString();
            //https://data.nasdaq.com/api/v3/datatables/BNC/PX/metadata?api_key=FrUd771p9fkYnfLr1NfR&code=GWA_BTC
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("metadata?" + BNCQuery);

                response.EnsureSuccessStatusCode();
                
                string responseBody = await response.Content.ReadAsStringAsync();

                BNC_Datatable cryptoDataTable = JsonConvert.DeserializeObject<BNC_Datatable>(responseBody);

                return cryptoDataTable;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
