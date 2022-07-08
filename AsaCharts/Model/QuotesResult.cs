using Newtonsoft.Json;

namespace AsaCharts.Model
{
    public class QuotesResult : ResultBase
    {
        /// <summary>
        /// Result
        /// </summary>
        [JsonProperty("s")]

        public override string Result { get; set; } = "ok";


        /// <summary>
        /// Quotes
        /// </summary>
        [JsonProperty("d")]

        public Quote[] Quotes { get; set; }


        /// <summary>
        /// Source
        /// </summary>
        [JsonProperty("source")]

        public string Source { get; set; }


    }
}
