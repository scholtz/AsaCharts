using Newtonsoft.Json;

namespace AsaCharts.Model
{
    public class SearchItem
    {

        /// <summary>
        /// symbol
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        /// <summary>
        /// FullName
        /// </summary>
        [JsonProperty("full_name")]
        public string FullName { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        /// <summary>
        /// Exchange
        /// </summary>
        [JsonProperty("exchange")]
        public string Exchange { get; set; }
        /// <summary>
        /// Ticker
        /// </summary>
        [JsonProperty("ticker")]
        public string Ticker { get; set; }
        /// <summary>
        /// Type stock" // or "futures" or "bitcoin" or "forex" or "index"
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
