using AsaCharts.Model.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AsaCharts.Model
{
    public class HistoryResult : ResultBase
    {

        /// <summary>
        /// Result
        /// </summary>
        [JsonProperty("s")]

        public override string Result { get; set; } = "ok";

        /// <summary>
        /// Time
        /// </summary>
        [JsonProperty("t")]
        public long[] TimeArray { get; set; } = new long[0];

        /// <summary>
        /// Close
        /// </summary>
        [JsonProperty("c")]
        public decimal[] CloseArray { get; set; } = new decimal[0];

        /// <summary>
        /// Open
        /// </summary>
        [JsonProperty("o")]
        public decimal[] OpenArray { get; set; } = new decimal[0];

        /// <summary>
        /// Open
        /// </summary>
        [JsonProperty("h")]
        public decimal[] HighArray { get; set; } = new decimal[0];

        /// <summary>
        /// Low
        /// </summary>
        [JsonProperty("l")]
        public decimal[] LowArray { get; set; } = new decimal[0];

        /// <summary>
        /// Volume
        /// </summary>
        [JsonProperty("v")]
        public decimal[] Volume { get; set; } = new decimal[0];
    }
}
