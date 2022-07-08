using AsaCharts.Model.GraphQL;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using System.Collections.Concurrent;

namespace AsaCharts.Repository
{
    public class GraphQLRepository
    {
        public ConcurrentDictionary<int, Indexer> Indexers = new ConcurrentDictionary<int, Indexer>();
        public ConcurrentDictionary<string, Symbol> Symbols = new ConcurrentDictionary<string, Symbol>();
        public ConcurrentDictionary<string, ConcurrentDictionary<string, ConcurrentDictionary<long, OHLC>>> OHLC = new ConcurrentDictionary<string, ConcurrentDictionary<string, ConcurrentDictionary<long, OHLC>>>();

        public GraphQLRepository()
        {
            var client = new GraphQLHttpClient("https://graphql.k8s.diatomix.xyz/v1/graphql", new NewtonsoftJsonSerializer());


            client.WebsocketConnectionState.Subscribe(e =>
            {
                Console.WriteLine(e);
            });
            client.WebSocketReceiveErrors.Subscribe(e =>
            {
                Console.WriteLine(e);
            });
            client.WebSocketReceiveErrors.Subscribe(e =>
            {
                Console.WriteLine(e.Message);
            });

            //        var userJoinedRequest2 = new GraphQLRequest
            //        {
            //            Query = @"
            //query {
            //    indexer{
            //        id
            //        round
            //    }
            //}"
            //        };
            //var request = client.SendQueryAsync<IndexerResult>(userJoinedRequest2).Result;

            InitIndexer(client);
            InitSymbol(client);
        }
        void InitIndexer(GraphQLHttpClient client)
        {
            var indexersRequest = new GraphQLRequest
            {
                Query = @"
                    subscription {
                        indexer{
                            id
                            round
                        }
                    }"
            };

            IObservable<GraphQLResponse<IndexerResult>> subscriptionStream = client.CreateSubscriptionStream<IndexerResult>(indexersRequest);
            var subscriptionIndexer = subscriptionStream.Subscribe(response =>
            {
                if (response.Data?.indexer != null)
                {
                    foreach (var item in response.Data.indexer)
                    {
                        Indexers[item.id] = item;
                    }
                }
            });
        }
        void InitSymbol(GraphQLHttpClient client)
        {
            var symbolsRequest = new GraphQLRequest
            {
                Query = @"
                    subscription {
                        symbol{
                            asa1
                            asa2
                            env
                            name
                            description
                            ticker
                        }
                    }"
            };
            IObservable<GraphQLResponse<SymbolResult>> subscriptionStreamSymbols = client.CreateSubscriptionStream<SymbolResult>(symbolsRequest);
            var subscriptionSymbols = subscriptionStreamSymbols.Subscribe(response =>
            {
                if (response.Data?.symbol != null)
                {
                    foreach (var item in response.Data.symbol)
                    {
                        Symbols[item.Ticker] = item;
                    }
                }
            });
        }
        void InitOHLC(GraphQLHttpClient client)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                    subscription {
                        ohlc{
                            symbol
                            resolution
                            time
                            close
                            open
                            high
                            low
                            volume
                        }
                    }"
            };
            IObservable<GraphQLResponse<OHLCResult>> subscription = client.CreateSubscriptionStream<OHLCResult>(request);
            var subscriptionD = subscription.Subscribe(response =>
            {
                if (response.Data?.ohlc != null)
                {
                    foreach (var item in response.Data.ohlc)
                    {
                        if (!OHLC.ContainsKey(item.Resolution))
                        {
                            OHLC[item.Resolution] = new ConcurrentDictionary<string, ConcurrentDictionary<long, OHLC>>();
                        }
                        if (!OHLC[item.Resolution].ContainsKey(item.Resolution))
                        {
                            OHLC[item.Resolution][item.Symbol] = new ConcurrentDictionary<long, OHLC>();
                        }
                        OHLC[item.Resolution][item.Symbol][item.Time] = item;
                    }
                }
            });
        }
    }
}
