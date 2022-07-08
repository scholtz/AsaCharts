using AsaCharts.Model.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace AsaCharts.Model
{
    [KnownType(typeof(ErrorResult))]
    [KnownType(typeof(HistoryResult))]
    [KnownType(typeof(NoDataResult))]
    public abstract class ResultBase
    {
        /// <summary>
        /// Result
        /// </summary>
        [JsonProperty("s")]
        [JsonConverter(typeof(StringEnumConverter))]
        abstract public string Result { get; set; }
    }
}
