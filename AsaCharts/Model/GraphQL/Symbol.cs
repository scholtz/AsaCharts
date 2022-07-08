using Newtonsoft.Json;

namespace AsaCharts.Model.GraphQL
{
    public class Symbol
    {
        /// <summary>
        /// ASA1
        /// </summary>
        [JsonProperty("asa1")]
        public long ASA1 { get; set; }
        /// <summary>
        /// ASA2
        /// </summary>
        [JsonProperty("asa2")]
        public long ASA2 { get; set; }
        /// <summary>
        /// Env
        /// </summary>
        [JsonProperty("env")]
        public string Env { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        /// <summary>
        /// Ticker
        /// </summary>
        [JsonProperty("ticker")]
        public string Ticker { get; set; }
    }
}
