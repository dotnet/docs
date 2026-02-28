// <GetStarted1>
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

// Using a ServiceCollection.
var services = new ServiceCollection();
services.AddQdrantVectorStore("localhost");
// </GetStarted1>

// <GetStarted2>
using Microsoft.Extensions.DependencyInjection;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddQdrantVectorStore("localhost");
// </GetStarted2>

// <GetStarted3>
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Qdrant.Client;

// Using a ServiceCollection.
var services = new ServiceCollection();
services.AddSingleton<QdrantClient>(sp => new QdrantClient("localhost"));
services.AddQdrantVectorStore();
// </GetStarted3>

// <GetStarted4>
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Qdrant.Client;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<QdrantClient>(sp => new QdrantClient("localhost"));
builder.Services.AddQdrantVectorStore();
// </GetStarted4>

// <GetStarted5>
using Microsoft.SemanticKernel.Connectors.Qdrant;
using Qdrant.Client;

var vectorStore = new QdrantVectorStore(new QdrantClient("localhost"), ownsClient: true);
// </GetStarted5>

// <GetStarted6>
using Microsoft.SemanticKernel.Connectors.Qdrant;
using Qdrant.Client;

var collection = new QdrantCollection<ulong, Hotel>(
    new QdrantClient("localhost"),
    "skhotels",
    ownsClient: true);
// </GetStarted6>

// <PropertyNameOverride>
using Microsoft.Extensions.VectorData;

public class Hotel
{
    [VectorStoreKey]
    public ulong HotelId { get; set; }

    [VectorStoreData(IsIndexed = true, StorageName = "hotel_name")]
    public string HotelName { get; set; }

    [VectorStoreData(IsFullTextIndexed = true, StorageName = "hotel_description")]
    public string Description { get; set; }

    [VectorStoreVector(4, DistanceFunction = DistanceFunction.CosineSimilarity, IndexKind = IndexKind.Hnsw, StorageName = "hotel_description_embedding")]
    public ReadOnlyMemory<float>? DescriptionEmbedding { get; set; }
}
// </PropertyNameOverride>

// <SingleUnnamedVector>
new Hotel
{
    HotelId = 1,
    HotelName = "Hotel Happy",
    Description = "A place where everyone can be happy.",
    DescriptionEmbedding = new float[4] { 0.9f, 0.1f, 0.1f, 0.1f }
};
// </SingleUnnamedVector>

// <NamedVectors1>
new Hotel
{
    HotelId = 1,
    HotelName = "Hotel Happy",
    Description = "A place where everyone can be happy.",
    HotelNameEmbedding = new float[4] { 0.9f, 0.5f, 0.5f, 0.5f }
    DescriptionEmbedding = new float[4] { 0.9f, 0.1f, 0.1f, 0.1f }
};
// </NamedVectors1>

// <NamedVectors2>
using Microsoft.SemanticKernel.Connectors.Qdrant;
using Qdrant.Client;

var vectorStore = new QdrantVectorStore(
    new QdrantClient("localhost"),
    ownsClient: true,
    new() { HasNamedVectors = true });

var collection = new QdrantCollection<ulong, Hotel>(
    new QdrantClient("localhost"),
    "skhotels",
    ownsClient: true,
    new() { HasNamedVectors = true });
// </NamedVectors2>