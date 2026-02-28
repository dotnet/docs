// <Limitations>
var cosmosClient = new CosmosClient(connectionString, new CosmosClientOptions()
{
    UseSystemTextJsonSerializerWithOptions = JsonSerializerOptions.Default,
});
// </Limitations>

// <GetStarted1>
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

// Using a ServiceCollection.
var services = new ServiceCollection();
services.AddCosmosNoSqlVectorStore(connectionString, databaseName);
// </GetStarted1>

// <GetStarted2>
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCosmosNoSqlVectorStore(connectionString, databaseName);
// </GetStarted2>

// <GetStarted3>
using System.Text.Json;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

// Using a ServiceCollection.
var services = new ServiceCollection();
services.AddSingleton<Database>(
    sp =>
    {
        var cosmosClient = new CosmosClient(connectionString, new CosmosClientOptions()
        {
            // When initializing CosmosClient manually, setting this property is required
            // due to limitations in default serializer.
            UseSystemTextJsonSerializerWithOptions = JsonSerializerOptions.Default,
        });

        return cosmosClient.GetDatabase(databaseName);
    });
services.AddCosmosNoSqlVectorStore();
// </GetStarted3>

// <GetStarted4>
using System.Text.Json;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<Database>(
    sp =>
    {
        var cosmosClient = new CosmosClient(connectionString, new CosmosClientOptions()
        {
            // When initializing CosmosClient manually, setting this property is required
            // due to limitations in default serializer.
            UseSystemTextJsonSerializerWithOptions = JsonSerializerOptions.Default,
        });

        return cosmosClient.GetDatabase(databaseName);
    });
builder.Services.AddCosmosNoSqlVectorStore();
// </GetStarted4>

// <GetStarted5>
using System.Text.Json;
using Microsoft.Azure.Cosmos;
using Microsoft.SemanticKernel.Connectors.CosmosNoSql;

var cosmosClient = new CosmosClient(connectionString, new CosmosClientOptions()
{
    // When initializing CosmosClient manually, setting this property is required
    // due to limitations in default serializer.
    UseSystemTextJsonSerializerWithOptions = JsonSerializerOptions.Default,
});

var database = cosmosClient.GetDatabase(databaseName);
var vectorStore = new CosmosNoSqlVectorStore(database);
// </GetStarted5>

// <GetStarted6>
using System.Text.Json;
using Microsoft.Azure.Cosmos;
using Microsoft.SemanticKernel.Connectors.CosmosNoSql;

var cosmosClient = new CosmosClient(connectionString, new CosmosClientOptions()
{
    // When initializing CosmosClient manually, setting this property is required
    // due to limitations in default serializer.
    UseSystemTextJsonSerializerWithOptions = JsonSerializerOptions.Default,
});

var database = cosmosClient.GetDatabase(databaseName);
var collection = new CosmosNoSqlCollection<string, Hotel>(
    database,
    "skhotels");
// </GetStarted6>

// <DataMapping1>
using System.Text.Json;
using Microsoft.Azure.Cosmos;
using Microsoft.SemanticKernel.Connectors.CosmosNoSql;

var jsonSerializerOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseUpper };

var cosmosClient = new CosmosClient(connectionString, new CosmosClientOptions()
{
    // When initializing CosmosClient manually, setting this property is required
    // due to limitations in default serializer.
    UseSystemTextJsonSerializerWithOptions = jsonSerializerOptions
});

var database = cosmosClient.GetDatabase(databaseName);
var collection = new CosmosNoSqlCollection<string, Hotel>(
    database,
    "skhotels",
    new() { JsonSerializerOptions = jsonSerializerOptions });
// </DataMapping1>

// <DataMapping2>
using System.Text.Json.Serialization;
using Microsoft.Extensions.VectorData;

public class Hotel
{
    [VectorStoreKey]
    public string HotelId { get; set; }

    [VectorStoreData(IsIndexed = true)]
    public string HotelName { get; set; }

    [VectorStoreData(IsFullTextIndexed = true)]
    public string Description { get; set; }

    [JsonPropertyName("HOTEL_DESCRIPTION_EMBEDDING")]
    [VectorStoreVector(4, DistanceFunction = DistanceFunction.EuclideanDistance, IndexKind = IndexKind.QuantizedFlat)]
    public ReadOnlyMemory<float>? DescriptionEmbedding { get; set; }
}
// </DataMapping2>

// <UsingPartitionKey1>
var options = new CosmosNoSqlCollectionOptions
{
    PartitionKeyPropertyName = nameof(Hotel.HotelName)
};

var collection = new CosmosNoSqlCollection<string, Hotel>(database, "collection-name", options)
    as VectorStoreCollection<CosmosNoSqlCompositeKey, Hotel>;
// </UsingPartitionKey1>

// <UsingPartitionKey2>
var record = await collection.GetAsync(new CosmosNoSqlCompositeKey("hotel-id", "hotel-name"));
// </UsingPartitionKey2>