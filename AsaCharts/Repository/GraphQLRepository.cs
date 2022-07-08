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


        public GraphQLRepository()
        {
            var client = new GraphQLHttpClient("https://graphql.k8s.diatomix.xyz/v1/graphql", new NewtonsoftJsonSerializer());
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
        }
    }
}
