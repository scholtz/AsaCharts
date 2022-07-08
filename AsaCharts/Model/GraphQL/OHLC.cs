using Newtonsoft.Json;

namespace AsaCharts.Model.GraphQL
{
    public class OHLC
    {
        /// <summary>
        /// Symbol
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        /// <summary>
        /// Resolution
        /// </summary>
        [JsonProperty("resolution")]
        public string Resolution { get; set; }
        /// <summary>
        /// Time
        /// </summary>
        [JsonProperty("time")]
        public long Time { get; set; }
        /// <summary>
        /// Open
        /// </summary>
        [JsonProperty("open")]
        public decimal Open { get; set; }
        /// <summary>
        /// High
        /// </summary>
        [JsonProperty("high")]
        public decimal High { get; set; }
        /// <summary>
        /// Low
        /// </summary>
        [JsonProperty("low")]
        public decimal Low { get; set; }
        /// <summary>
        /// Close
        /// </summary>
        [JsonProperty("close")]
        public decimal Close { get; set; }
        /// <summary>
        /// Volume
        /// </summary>
        [JsonProperty("volume")]
        public decimal Volume { get; set; }
    }
}
