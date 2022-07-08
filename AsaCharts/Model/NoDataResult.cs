using AsaCharts.Model.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AsaCharts.Model
{
    public class NoDataResult: ResultBase
    {
        /// <summary>
        /// Result
        /// </summary>
        [JsonProperty("s")]

        public override string Result  { get; set; } = "no_data";

        /// <summary>
        /// Time
        /// </summary>
        [JsonProperty("errmsg")]
        public long[]? ErrorMessage { get; set; }

    }
}
