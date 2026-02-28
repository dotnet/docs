// <GetStarted1>
using Microsoft.SemanticKernel;
using Elastic.Clients.Elasticsearch;

// Using a ServiceCollection.
var kernelBuilder = Kernel
    .CreateBuilder()
    .AddElasticsearchVectorStore(new ElasticsearchClientSettings(new Uri("http://localhost:9200")));
// </GetStarted1>

// <GetStarted2>
using Microsoft.SemanticKernel;
using Elastic.Clients.Elasticsearch;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddElasticsearchVectorStore(new ElasticsearchClientSettings(new Uri("http://localhost:9200")));
// </GetStarted2>

// <GetStarted3>
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Elastic.Clients.Elasticsearch;

// Using a ServiceCollection.
var services = new ServiceCollection();
services.AddSingleton<ElasticsearchClient>(sp =>
    new ElasticsearchClient(new ElasticsearchClientSettings(new Uri("http://localhost:9200"))));
services.AddElasticsearchVectorStore();
// </GetStarted3>

// <GetStarted4>
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Elastic.Clients.Elasticsearch;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ElasticsearchClient>(sp =>
    new ElasticsearchClient(new ElasticsearchClientSettings(new Uri("http://localhost:9200"))));
builder.Services.AddElasticsearchVectorStore();
// </GetStarted4>

// <GetStarted5>
using Elastic.SemanticKernel.Connectors.Elasticsearch;
using Elastic.Clients.Elasticsearch;

var vectorStore = new ElasticsearchVectorStore(
    new ElasticsearchClient(new ElasticsearchClientSettings(new Uri("http://localhost:9200"))));
// </GetStarted5>

// <GetStarted6>
using Elastic.SemanticKernel.Connectors.Elasticsearch;
using Elastic.Clients.Elasticsearch;

var collection = new ElasticsearchVectorStoreRecordCollection<Hotel>(
    new ElasticsearchClient(new ElasticsearchClientSettings(new Uri("http://localhost:9200"))),
    "skhotels");
// </GetStarted6>

// <DataMapping1>
using Elastic.SemanticKernel.Connectors.Elasticsearch;
using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.Serialization;
using Elastic.Transport;

var nodePool = new SingleNodePool(new Uri("http://localhost:9200"));
var settings = new ElasticsearchClientSettings(
    nodePool,
    sourceSerializer: (defaultSerializer, settings) =>
        new DefaultSourceSerializer(settings, options =>
            options.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseUpper));
var client = new ElasticsearchClient(settings);

var collection = new ElasticsearchVectorStoreRecordCollection<Hotel>(
    client,
    "skhotelsjson");
// </DataMapping1>

// <DataMapping2>
using Elastic.SemanticKernel.Connectors.Elasticsearch;
using Elastic.Clients.Elasticsearch;

var settings = new ElasticsearchClientSettings(new Uri("http://localhost:9200"));
settings.DefaultFieldNameInferrer(name => JsonNamingPolicy.SnakeCaseUpper.ConvertName(name));
var client = new ElasticsearchClient(settings);

var collection = new ElasticsearchVectorStoreRecordCollection<Hotel>(
    client,
    "skhotelsjson");
// </DataMapping2>

// <DataMapping3>
using System.Text.Json.Serialization;
using Microsoft.Extensions.VectorData;

public class Hotel
{
    [VectorStoreKey]
    public string HotelId { get; set; }

    [VectorStoreData(IsIndexed = true)]
    public string HotelName { get; set; }

    [JsonPropertyName("HOTEL_DESCRIPTION")]
    [VectorStoreData(IsFullTextIndexed = true)]
    public string Description { get; set; }

    [VectorStoreVector(Dimensions: 4, DistanceFunction.CosineSimilarity, IndexKind.Hnsw)]
    public ReadOnlyMemory<float>? DescriptionEmbedding { get; set; }
}
// </DataMapping3>