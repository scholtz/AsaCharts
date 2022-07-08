using AsaCharts.Model;
using AsaCharts.Repository;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AsaCharts.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChartController : ControllerBase
    {
        private readonly ILogger<ChartController> _logger;
        private readonly GraphQLRepository graphQLRepository;
        public ChartController(ILogger<ChartController> logger, GraphQLRepository graphQLRepository)
        {
            _logger = logger;
            this.graphQLRepository = graphQLRepository;
        }

        /// <summary>
        /// Returns TV config
        /// </summary>
        /// <returns></returns>
        [HttpGet("config")]
        public ActionResult<Config> Config()
        {
            return Ok(new Config()
            {
                SupportedResolutions = new string[] { "1", "5", "15", "30", "60", "1D", "1W", "1M" },
                SupportsSearch = true
            });
        }
        /// <summary>
        /// Symbol resolve
        ///     Request: GET /symbols? symbol =< symbol >
        ///     symbol: string. Symbol name or ticker.
        ///     Example: GET /symbols? symbol = AAL, GET /symbols? symbol = NYSE:MSFT
        ///     A JSON response of the same structure as SymbolInfo
        ///     Remark: This call will be requested if your data feed sent supports_group_request: false and supports_search: true in the configuration data.
        ///     @{
        /// {"s":"error","errmsg":"unknown_symbol APPL"}
        /// }
        /// {"name":"MSFT","exchange-traded":"NasdaqNM","exchange-listed":"NasdaqNM","timezone":"America/New_York","minmov":1,"minmov2":0,"pointvalue":1,"session":"0930-1630","has_intraday":false,"has_no_volume":false,"description":"Microsoft Corporation","type":"stock","supported_resolutions":["D","2D","3D","W","3W","M","6M"],"pricescale":100,"ticker":"MSFT"}
        /// </summary>
        [HttpGet("symbols")]
        public async Task<ActionResult<Symbol>> Symbols([FromQuery] string symbol)
        {
            try
            {

                if (symbol.StartsWith("DATAPROVIDER:"))
                {
                    symbol = symbol.Substring(13);
                }
                if (symbol.StartsWith("ALGO:"))
                {
                    symbol = symbol.Substring(5);
                }

                if (graphQLRepository.Symbols.TryGetValue(symbol, out var s))
                {
                    return Ok(new Symbol()
                    {
                        Ticker = s.Ticker,
                        Description = s.Description,
                        Name = s.Name
                    });
                }

                throw new Exception($"Unable to find ticker ${symbol}");
            }
            catch (Exception e)
            {
                return Ok(new ErrorResult() { ErrorMessage = e.Message });
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="resolution"></param>
        /// <returns></returns>
        [HttpGet("history")]
        public ActionResult<ResultBase> History([FromQuery] string symbol, [FromQuery] string from, [FromQuery] string to, [FromQuery] string resolution)
        {
            try
            {
                if (symbol.StartsWith("DATAPROVIDER:"))
                {
                    symbol = symbol.Substring(13);
                }
                if (symbol.StartsWith("ALGO:"))
                {
                    symbol = symbol.Substring(5);
                }
                bool isContinual = false;
                if (symbol.EndsWith("-CONTINUALDATA"))
                {
                    symbol = symbol.Substring(0, symbol.Length - "-CONTINUALDATA".Length);
                    isContinual = true;
                }
                return Ok();
            }
            catch (Exception e)
            {
                return Ok(new ErrorResult() { ErrorMessage = e.Message });
            }
        }
        /// <summary>
        /// Quotes 
        /// 
        /// {"s":"ok","d":[{"s":"ok","n":"MSFT","v":{"ch":0,"chp":0,"short_name":"MSFT","exchange":"","original_name":"MSFT","description":"MSFT","lp":94.94,"ask":94.94,"bid":94.94,"open_price":94.94,"high_price":94.94,"low_price":94.94,"prev_close_price":93.78,"volume":94.94}}],"source":"Quandl"}
        /// </summary>
        /// <param name="symbols"></param>
        /// <returns></returns>
        [HttpGet("quotes")]
        public ActionResult<QuotesResult> Quotes([FromQuery] string symbols)
        {
            try
            {
                return Ok(new QuotesResult() { });
            }
            catch (Exception e)
            {
                return Ok(new ErrorResult() { ErrorMessage = e.Message });
            }
        }
        /// <summary>
        /// Search symbols
        /// 
        /// [
        /// {
        /// "symbol": "<short symbol name>",
        /// "full_name": "<full symbol name>", // e.g. BTCE:BTCUSD
        /// "description": "<symbol description>",
        /// "exchange": "<symbol exchange name>",
        /// "ticker": "<symbol ticker name, optional>",
        /// "type": "stock" // or "futures" or "bitcoin" or "forex" or "index"
        /// },
        /// {
        /// //    .....
        /// }
        /// ]
        /// </summary>
        [HttpGet("search")]
        public ActionResult<SearchItem[]> Search([FromQuery] string query, [FromQuery] string type, [FromQuery] string exchange, [FromQuery] string limit)
        {
            try
            {
                return Ok(new SearchItem[] { });
            }
            catch (Exception e)
            {
                return Ok(new ErrorResult() { ErrorMessage = e.Message });
            }
        }
        /// <summary>
        /// SymbolInfo
        /// </summary>
        [HttpGet("symbol_info")]
        public ActionResult<string> SymbolInfo()
        {
            try
            {
                return Ok(@"{
   symbol: [""AAPL"", ""MSFT"", ""SPX""],
   description: [""Apple Inc"", ""Microsoft corp"", ""S&P 500 index""],
   exchange-listed: ""NYSE"",
   exchange-traded: ""NYSE"",
   minmovement: 1,
   minmovement2: 0,
   pricescale: [1, 1, 100],
   has-dwm: true,
   has-intraday: true,
   has-no-volume: [false, false, true]
   type: [""stock"", ""stock"", ""index""],
   ticker: [""AAPL~0"", ""MSFT~0"", ""$SPX500""],
   timezone: ""America/New_York"",
   session-regular: ""0900-1600""
}");
            }
            catch (Exception e)
            {
                return Ok(new ErrorResult() { ErrorMessage = e.Message });
            }
        }
        /// <summary>
        /// Server time
        /// </summary>
        [HttpGet("time")]
        public ActionResult<string> Time()
        {
            try
            {
                return Ok(DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString());
            }
            catch (Exception e)
            {
                return Ok(new ErrorResult() { ErrorMessage = e.Message });
            }
        }
        /// <summary>
        /// TimescaleMarks
        /// </summary>
        [HttpGet("timescale_marks")]
        public ActionResult<string> TimescaleMarks()
        {
            try
            {
                return Ok("[]");
            }
            catch (Exception e)
            {
                return Ok(new ErrorResult() { ErrorMessage = e.Message });
            }
        }
        /// <summary>
        /// Marks 
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="resolution"></param>
        /// <returns></returns>
        [HttpGet("marks")]
        public ActionResult<string> Marks()
        {
            try
            {
                return Ok("{}");
            }
            catch (Exception e)
            {
                return Ok(new ErrorResult() { ErrorMessage = e.Message });
            }
        }
    }
}
