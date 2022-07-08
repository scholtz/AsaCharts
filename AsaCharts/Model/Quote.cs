using Newtonsoft.Json;

namespace AsaCharts.Model
{
    public class Quote
    {
        /// <summary>
        /// Change
        /// </summary>
        [JsonProperty("ch")]
        public decimal Change { get; set; }
        /// <summary>
        /// ChangePercent
        /// </summary>
        [JsonProperty("chp")]
        public decimal ChangePercent { get; set; }
        /// <summary>
        /// ShortName
        /// </summary>
        [JsonProperty("short_name")]
        public string ShortName { get; set; }
        /// <summary>
        /// Exchange
        /// </summary>
        [JsonProperty("exchange")]
        public string Exchange { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        /// <summary>
        /// LastPrice
        /// </summary>
        [JsonProperty("lp")]
        public decimal LastPrice { get; set; }
        /// <summary>
        /// Offer
        /// </summary>
        [JsonProperty("ask")]
        public decimal Offer { get; set; }
        /// <summary>
        /// Bid
        /// </summary>
        [JsonProperty("bid")]
        public decimal Bid { get; set; }
        /// <summary>
        /// Spread
        /// </summary>
        [JsonProperty("spread")]
        public decimal Spread { get; set; }
        /// <summary>
        /// OpenPrice
        /// </summary>
        [JsonProperty("open_price")]
        public decimal OpenPrice { get; set; }
        /// <summary>
        /// HighPrice
        /// </summary>
        [JsonProperty("high_price")]
        public decimal HighPrice { get; set; }
        /// <summary>
        /// LowPrice
        /// </summary>
        [JsonProperty("low_price")]
        public decimal LowPrice { get; set; }
        /// <summary>
        /// PreviousClosePrice
        /// </summary>
        [JsonProperty("prev_close_price")]
        public decimal PreviousClosePrice { get; set; }
        /// <summary>
        /// Volume
        /// </summary>
        [JsonProperty("volume")]
        public decimal Volume { get; set; }
    }
}
