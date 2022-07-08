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
        public List<long> TimeArray { get; set; } = new List<long>();

        /// <summary>
        /// Close
        /// </summary>
        [JsonProperty("c")]
        public List<decimal> CloseArray { get; set; } = new List<decimal>();

        /// <summary>
        /// Open
        /// </summary>
        [JsonProperty("o")]
        public List<decimal> OpenArray { get; set; } = new List<decimal>();

        /// <summary>
        /// Open
        /// </summary>
        [JsonProperty("h")]
        public List<decimal> HighArray { get; set; } = new List<decimal>();

        /// <summary>
        /// Low
        /// </summary>
        [JsonProperty("l")]
        public List<decimal> LowArray { get; set; } = new List<decimal>();

        /// <summary>
        /// Volume
        /// </summary>
        [JsonProperty("v")]
        public List<decimal> VolumeArray { get; set; } = new List<decimal>();
    }
}
