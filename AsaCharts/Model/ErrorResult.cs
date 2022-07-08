using AsaCharts.Model.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AsaCharts.Model
{
    public class ErrorResult : ResultBase
    {
        /// <summary>
        /// Result
        /// </summary>
        [JsonProperty("s")]

        public override string Result { get; set; } = "error";

        /// <summary>
        /// Time
        /// </summary>
        [JsonProperty("errmsg")]
        public string ErrorMessage { get; set; } = "Error occured";

    }
}
