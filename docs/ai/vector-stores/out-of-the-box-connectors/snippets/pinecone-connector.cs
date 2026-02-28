// <GetStarted1>
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

// Using a ServiceCollection.
var services = new ServiceCollection();
services.AddPineconeVectorStore(pineconeApiKey);
// </GetStarted1>

// <GetStarted2>
using Microsoft.Extensions.DependencyInjection;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddPineconeVectorStore(pineconeApiKey);
// </GetStarted2>

// <GetStarted3>
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using PineconeClient = Pinecone.PineconeClient;

// Using a ServiceCollection.
var services = new ServiceCollection();
services.AddSingleton<PineconeClient>(
    sp => new PineconeClient(pineconeApiKey));
services.AddPineconeVectorStore();
// </GetStarted3>

// <GetStarted4>
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using PineconeClient = Pinecone.PineconeClient;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<PineconeClient>(
    sp => new PineconeClient(pineconeApiKey));
builder.Services.AddPineconeVectorStore();
// </GetStarted4>

// <GetStarted5>
using Microsoft.SemanticKernel.Connectors.Pinecone;
using PineconeClient = Pinecone.PineconeClient;

var vectorStore = new PineconeVectorStore(
    new PineconeClient(pineconeApiKey));
// </GetStarted5>

// <GetStarted6>
using Microsoft.SemanticKernel.Connectors.Pinecone;
using PineconeClient = Pinecone.PineconeClient;

var collection = new PineconeCollection<string, Hotel>(
    new PineconeClient(pineconeApiKey),
    "skhotels");
// </GetStarted6>

// <IndexNamespace>
using Microsoft.SemanticKernel.Connectors.Pinecone;
using PineconeClient = Pinecone.PineconeClient;

var collection = new PineconeCollection<string, Hotel>(
    new PineconeClient(pineconeApiKey),
    "skhotels",
    new() { IndexNamespace = "seasidehotels" });
// </IndexNamespace>

// <PropertyNameOverride>
using Microsoft.Extensions.VectorData;

public class Hotel
{
    [VectorStoreKey]
    public string HotelId { get; set; }

    [VectorStoreData(IsIndexed = true, StorageName = "hotel_name")]
    public string HotelName { get; set; }

    [VectorStoreData(IsFullTextIndexed = true, StorageName = "hotel_description")]
    public string Description { get; set; }

    [VectorStoreVector(Dimensions: 4, DistanceFunction = DistanceFunction.CosineSimilarity, IndexKind = IndexKind.Hnsw)]
    public ReadOnlyMemory<float>? DescriptionEmbedding { get; set; }
}
// </PropertyNameOverride>