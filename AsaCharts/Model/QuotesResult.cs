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

        public List<Quote> Quotes { get; set; } = new List<Quote>();


        /// <summary>
        /// Source
        /// </summary>
        [JsonProperty("source")]

        public string Source { get; set; }


    }
}
