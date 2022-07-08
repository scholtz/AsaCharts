using Newtonsoft.Json;

namespace AsaCharts.Model
{
    public class Symbol
    {
        /// <summary>
        /// ShortName
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// ExchangeTraded
        /// </summary>
        [JsonProperty("exchange-traded")]
        public string ExchangeTraded { get; set; } = "ALGO";
        /// <summary>
        /// ExchangeListed
        /// </summary>
        [JsonProperty("exchange-listed")]
        public string ExchangeListed { get; set; } = "ALGO";
        /// <summary>
        /// timezone
        /// </summary>
        [JsonProperty("timezone")]
        public string Timezone { get; set; } = "Europe/Prague";
        /// <summary>
        /// data_status
        /// </summary>
        [JsonProperty("data_status")]
        public string DataStatus { get; set; } = "streaming";
        /// <summary>
        /// CurrencyCode
        /// </summary>
        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }
        /// <summary>
        /// minmov
        /// </summary>
        [JsonProperty("minmov")]
        public decimal MinMov { get; set; } = 1;
        /// <summary>
        /// minmov2
        /// </summary>
        [JsonProperty("minmov2")]
        public decimal MinMov2 { get; set; } = 0;
        /// <summary>
        /// pointvalue
        /// </summary>
        [JsonProperty("pointvalue")]
        public decimal PointValue { get; set; } = 1;
        /// <summary>
        /// session
        /// </summary>
        [JsonProperty("session")]
        public string Session { get; set; } = "0000-2359";
        /// <summary>
        /// HasIntraday
        /// </summary>
        [JsonProperty("has_intraday")]
        public bool HasIntraday { get; set; } = true;
        /// <summary>
        /// HasDaily
        /// </summary>
        [JsonProperty("has_daily")]
        public bool HasDaily { get; set; } = true;
        /// <summary>
        /// HasWeeklyAndMonthly
        /// </summary>
        [JsonProperty("has_weekly_and_monthly")]
        public bool HasWeeklyAndMonthly { get; set; } = true;
        /// <summary>
        /// HasNoVolume
        /// </summary>
        [JsonProperty("has_no_volume")]
        public bool HasNoVolume { get; set; } = false;
        /// <summary>
        /// Description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        /// <summary>
        /// Type stock" // or "futures" or "bitcoin" or "forex" or "index"
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
        /// <summary>
        /// SupportedRsolutions
        /// </summary>
        [JsonProperty("supported_resolutions")]
        public string[] SupportedRsolutions { get; set; } = new string[] { "1", "5", "15", "30", "60", "1D", "1W", "1M" };
        /// <summary>
        /// IntradayMultipliers
        /// </summary>
        [JsonProperty("intraday_multipliers")]
        public string[] IntradayMultipliers { get; set; } = new string[] { "1", "5", "15", "30", "60" };
        /// <summary>
        /// Pricescale
        /// </summary>
        [JsonProperty("pricescale")]
        public decimal Pricescale { get; set; } = 100;
        /// <summary>
        /// Ticker
        /// </summary>
        [JsonProperty("ticker")]
        public string Ticker { get; set; }
    }
}
