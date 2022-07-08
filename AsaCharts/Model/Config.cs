using Newtonsoft.Json;

namespace AsaCharts.Model
{
    public class Config
    {
        /// <summary>
        /// supported_resolutions
        /// </summary>
        [JsonProperty("supported_resolutions")]
        public string[] SupportedResolutions { get; set; } = new string[0];
        /// <summary>
        /// supports_search
        /// </summary>
        [JsonProperty("supports_search")]
        public bool SupportsSearch { get; set; } = false;
        /// <summary>
        /// supports_marks
        /// </summary>
        [JsonProperty("supports_marks")]
        public bool SupportsMarks { get; set; } = false;
        /// <summary>
        /// supports_timescale_marks
        /// </summary>
        [JsonProperty("supports_timescale_marks")]
        public bool SupportsTimescaleMarks { get; set; } = false;
        /// <summary>
        /// supports_group_request
        /// </summary>
        [JsonProperty("supports_group_request")]
        public bool SupportsGroupRequest { get; set; } = false;

    }
}
