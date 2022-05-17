using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoTracker.Api.Models
{
    public class Trades
    {
        public List<Trade> results { get; set; }
        public string status { get; set; }
        public string request_id { get; set; }
        public int count { get; set; }
        public string next_url { get; set; }
    }

    public class Trade 
    {
        public List<int> conditions { get; set; }
        public int exchange { get; set; }
        public string id { get; set; }
        public object participant_timestamp { get; set; }
        public double price { get; set; }
        public double size { get; set; }
    }
}
