// <GetStarted1>
using Microsoft.Extensions.DependencyInjection;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServerVectorStore(_ => "<connectionstring>");
// </GetStarted1>

// <GetStarted2>
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServerVectorStore(_ => "<connectionstring>")
// </GetStarted2>

// <GetStarted3>
using Microsoft.SemanticKernel.Connectors.SqlServer;

var vectorStore = new SqlServerVectorStore("<connectionstring>");
// </GetStarted3>

// <GetStarted4>
using Microsoft.SemanticKernel.Connectors.SqlServer;

var collection = new SqlServerCollection<string, Hotel>("<connectionstring>", "skhotels");
// </GetStarted4>

// <PropertyNameOverride>
using Microsoft.Extensions.VectorData;

public class Hotel
{
    [VectorStoreKey]
    public ulong HotelId { get; set; }

    [VectorStoreData(StorageName = "hotel_name")]
    public string? HotelName { get; set; }

    [VectorStoreData(StorageName = "hotel_description")]
    public string? Description { get; set; }

    [VectorStoreVector(Dimensions: 4, DistanceFunction = DistanceFunction.CosineDistance)]
    public ReadOnlyMemory<float>? DescriptionEmbedding { get; set; }
}
// </PropertyNameOverride>