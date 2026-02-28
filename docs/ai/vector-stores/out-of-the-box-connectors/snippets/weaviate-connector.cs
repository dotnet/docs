// <GetStarted1>
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

// Using a ServiceCollection.
var services = new ServiceCollection();
services.AddWeaviateVectorStore(new Uri("http://localhost:8080/v1/"), apiKey: null);
// </GetStarted1>

// <GetStarted2>
using Microsoft.Extensions.DependencyInjection;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddWeaviateVectorStore(new Uri("http://localhost:8080/v1/"), apiKey: null);
// </GetStarted2>

// <GetStarted3>
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

// Using a ServiceCollection.
var services = new ServiceCollection();
using HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:8080/v1/") };
services.AddWeaviateVectorStore(_ => client);
// </GetStarted3>

// <GetStarted4>
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
using HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:8080/v1/") };
builder.Services.AddWeaviateVectorStore(_ => client);
// </GetStarted4>

// <GetStarted5>
using System.Net.Http;
using Microsoft.SemanticKernel.Connectors.Weaviate;

var vectorStore = new WeaviateVectorStore(
    new HttpClient { BaseAddress = new Uri("http://localhost:8080/v1/") });
// </GetStarted5>

// <GetStarted6>
using System.Net.Http;
using Microsoft.SemanticKernel.Connectors.Weaviate;

var collection = new WeaviateCollection<Guid, Hotel>(
    new HttpClient { BaseAddress = new Uri("http://localhost:8080/v1/") },
    "Skhotels");
// </GetStarted6>

// <GetStarted7>
using Microsoft.SemanticKernel;

var services = new ServiceCollection();
services.AddWeaviateVectorStore(new Uri("http://localhost:8080/v1/"), secretVar);
// </GetStarted7>

// <DataMapping>
using System.Text.Json.Serialization;
using Microsoft.Extensions.VectorData;

public class Hotel
{
    [VectorStoreKey]
    public Guid HotelId { get; set; }

    [VectorStoreData(IsIndexed = true)]
    public string HotelName { get; set; }

    [VectorStoreData(IsFullTextIndexed = true)]
    public string Description { get; set; }

    [JsonPropertyName("HOTEL_DESCRIPTION_EMBEDDING")]
    [VectorStoreVector(4, DistanceFunction = DistanceFunction.CosineDistance, IndexKind = IndexKind.QuantizedFlat)]
    public ReadOnlyMemory<float>? DescriptionEmbedding { get; set; }
}
// </DataMapping>