using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Crypto_Currency_in_Vying.Models
{
    public class PostQueryResponse
    {
       
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
        [JsonPropertyName("id")]
        public string ID { get; set; }
        [JsonPropertyName("tickers")]
        public List<Ticker> CurrentPrice { get; set; }
        [JsonPropertyName("image")]
        public Image Image { get; set; }


    }
    public class Ticker
    {
        [JsonPropertyName("target")]
        public string Currency { get; set; }
        [JsonPropertyName("last")]
        public double Value { get; set; }
        [JsonPropertyName("volume")]
        public double Volume { get; set; }
         
        public Market market { get; set; }
    }

    public class Market
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class Image
    {
        [JsonPropertyName("thumb")]
        public string Thumb { get; set; }
    }

    
}
