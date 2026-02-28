// <GetStarted1>
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

// Using a ServiceCollection.
var services = new ServiceCollection();
services.AddCosmosMongoVectorStore(connectionString, databaseName);
// </GetStarted1>

// <GetStarted2>
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCosmosMongoVectorStore(connectionString, databaseName);
// </GetStarted2>

// <GetStarted3>
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using MongoDB.Driver;

// Using a ServiceCollection.
var services = new ServiceCollection();
services.AddSingleton<IMongoDatabase>(
    sp =>
    {
        var mongoClient = new MongoClient(connectionString);
        return mongoClient.GetDatabase(databaseName);
    });
services.AddCosmosMongoVectorStore();
// </GetStarted3>

// <GetStarted4>
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using MongoDB.Driver;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IMongoDatabase>(
    sp =>
    {
        var mongoClient = new MongoClient(connectionString);
        return mongoClient.GetDatabase(databaseName);
    });
builder.Services.AddCosmosMongoVectorStore();
// </GetStarted4>

// <GetStarted5>
using Microsoft.SemanticKernel.Connectors.CosmosMongoDB;
using MongoDB.Driver;

var mongoClient = new MongoClient(connectionString);
var database = mongoClient.GetDatabase(databaseName);
var vectorStore = new CosmosMongoVectorStore(database);
// </GetStarted5>

// <GetStarted6>
using Microsoft.SemanticKernel.Connectors.CosmosMongoDB;
using MongoDB.Driver;

var mongoClient = new MongoClient(connectionString);
var database = mongoClient.GetDatabase(databaseName);
var collection = new CosmosMongoCollection<ulong, Hotel>(
    database,
    "skhotels");
// </GetStarted6>

// <PropertyNameOverride>
using Microsoft.Extensions.VectorData;

public class Hotel
{
    [VectorStoreKey]
    public ulong HotelId { get; set; }

    [BsonElement("hotel_name")]
    [VectorStoreData(IsIndexed = true)]
    public string HotelName { get; set; }

    [BsonElement("hotel_description")]
    [VectorStoreData(IsFullTextIndexed = true)]
    public string Description { get; set; }

    [BsonElement("hotel_description_embedding")]
    [VectorStoreVector(4, DistanceFunction = DistanceFunction.CosineDistance, IndexKind = IndexKind.Hnsw)]
    public ReadOnlyMemory<float>? DescriptionEmbedding { get; set; }
}
// </PropertyNameOverride>