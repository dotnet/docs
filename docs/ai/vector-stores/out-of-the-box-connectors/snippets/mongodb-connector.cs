// <GetStarted1>
using Microsoft.Extensions.DependencyInjection;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMongoVectorStore(connectionString, databaseName);
// </GetStarted1>

// <GetStarted2>
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IMongoDatabase>(
    sp =>
    {
        var mongoClient = new MongoClient(connectionString);
        return mongoClient.GetDatabase(databaseName);
    });
builder.Services.AddMongoVectorStore();
// </GetStarted2>

// <GetStarted3>
using Microsoft.SemanticKernel.Connectors.MongoDB;
using MongoDB.Driver;

var mongoClient = new MongoClient(connectionString);
var database = mongoClient.GetDatabase(databaseName);
var vectorStore = new MongoVectorStore(database);
// </GetStarted3>

// <GetStarted4>
using Microsoft.SemanticKernel.Connectors.MongoDB;
using MongoDB.Driver;

var mongoClient = new MongoClient(connectionString);
var database = mongoClient.GetDatabase(databaseName);
var collection = new MongoCollection<string, Hotel>(
    database,
    "skhotels");
// </GetStarted4>

// <PropertyNameOverride>
using Microsoft.Extensions.VectorData;
using MongoDB.Bson.Serialization.Attributes;

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
    [VectorStoreVector(4, DistanceFunction = DistanceFunction.CosineSimilarity)]
    public ReadOnlyMemory<float>? DescriptionEmbedding { get; set; }
}
// </PropertyNameOverride>