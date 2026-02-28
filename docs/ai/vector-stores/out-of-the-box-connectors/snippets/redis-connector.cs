// <GetStarted1>
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

// Using a ServiceCollection.
var services = new ServiceCollection();
services.AddRedisVectorStore("localhost:6379");
// </GetStarted1>

// <GetStarted2>
using Microsoft.SemanticKernel;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRedisVectorStore("localhost:6379");
// </GetStarted2>

// <GetStarted3>
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using StackExchange.Redis;

// Using a ServiceCollection.
var services = new ServiceCollection();
services.AddSingleton<IDatabase>(sp => ConnectionMultiplexer.Connect("localhost:6379").GetDatabase());
services.AddRedisVectorStore();
// </GetStarted3>

// <GetStarted4>
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using StackExchange.Redis;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IDatabase>(sp => ConnectionMultiplexer.Connect("localhost:6379").GetDatabase());
builder.Services.AddRedisVectorStore();
// </GetStarted4>

// <GetStarted5>
using Microsoft.SemanticKernel.Connectors.Redis;
using StackExchange.Redis;

var vectorStore = new RedisVectorStore(ConnectionMultiplexer.Connect("localhost:6379").GetDatabase());
// </GetStarted5>

// <GetStarted6>
using Microsoft.SemanticKernel.Connectors.Redis;
using StackExchange.Redis;

// Using Hashes.
var hashesCollection = new RedisHashSetCollection<string, Hotel>(
    ConnectionMultiplexer.Connect("localhost:6379").GetDatabase(),
    "skhotelshashes");
// </GetStarted6>

// <GetStarted7>
using Microsoft.SemanticKernel.Connectors.Redis;
using StackExchange.Redis;

// Using JSON.
var jsonCollection = new RedisJsonCollection<string, Hotel>(
    ConnectionMultiplexer.Connect("localhost:6379").GetDatabase(),
    "skhotelsjson");
// </GetStarted7>

// <GetStarted8>
using Microsoft.SemanticKernel.Connectors.Redis;
using StackExchange.Redis;

var vectorStore = new RedisVectorStore(
    ConnectionMultiplexer.Connect("localhost:6379").GetDatabase(),
    new() { StorageType = RedisStorageType.HashSet });
// </GetStarted8>

// <IndexPrefixes>
using Microsoft.SemanticKernel.Connectors.Redis;
using StackExchange.Redis;

var collection = new RedisJsonCollection<string, Hotel>(
    ConnectionMultiplexer.Connect("localhost:6379").GetDatabase(),
    "skhotelsjson",
    new() { PrefixCollectionNameToKeyNames = false });

await collection.GetAsync("myprefix_h1");
// </IndexPrefixes>

// <DataMappingWhenUsingTheJSONStorageType1>
var jsonSerializerOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseUpper };
var collection = new RedisJsonCollection<string, Hotel>(
    ConnectionMultiplexer.Connect("localhost:6379").GetDatabase(),
    "skhotelsjson",
    new() { JsonSerializerOptions = jsonSerializerOptions });
// </DataMappingWhenUsingTheJSONStorageType1>

// <DataMappingWhenUsingTheJSONStorageType2>
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

    [VectorStoreVector(Dimensions: 4, DistanceFunction = DistanceFunction.CosineSimilarity, IndexKind = IndexKind.Hnsw)]
    public ReadOnlyMemory<float>? DescriptionEmbedding { get; set; }
}
// </DataMappingWhenUsingTheJSONStorageType2>

// <DataMappingWhenUsingTheHashesStorageType>
using Microsoft.Extensions.VectorData;

public class Hotel
{
    [VectorStoreKey]
    public string HotelId { get; set; }

    [VectorStoreData(IsIndexed = true, StorageName = "hotel_name")]
    public string HotelName { get; set; }

    [VectorStoreData(IsFullTextIndexed = true, StorageName = "hotel_description")]
    public string Description { get; set; }

    [VectorStoreVector(Dimensions: 4, DistanceFunction = DistanceFunction.CosineSimilarity, IndexKind = IndexKind.Hnsw, StorageName = "hotel_description_embedding")]
    public ReadOnlyMemory<float>? DescriptionEmbedding { get; set; }
}
// </DataMappingWhenUsingTheHashesStorageType>