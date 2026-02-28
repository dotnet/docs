// <GetStarted1>
using Oracle.VectorData;
using Microsoft.Extensions.DependencyInjection;

// Using a ServiceCollection.
var services = new ServiceCollection();
services.AddOracleVectorStore("<connection string>");
// </GetStarted1>

// <GetStarted2>
using Microsoft.AspNetCore.Builder;
using Oracle.VectorData;
using Microsoft.Extensions.DependencyInjection;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOracleVectorStore("<connection string>");
// </GetStarted2>

// <GetStarted3>
using Oracle.VectorData;
using Microsoft.Extensions.DependencyInjection;
using Oracle.ManagedDataAccess.Client;

// Using a ServiceCollection.
var services = new ServiceCollection();
services.AddSingleton<OracleDataSource>(sp =>
{
    OracleDataSourceBuilder dataSourceBuilder = new("<connection string>");
    return dataSourceBuilder.Build();
});

services.AddOracleVectorStore();
// </GetStarted3>

// <GetStarted4>
using Microsoft.AspNetCore.Builder;
using Oracle.VectorData;
using Microsoft.Extensions.DependencyInjection;
using Oracle.ManagedDataAccess.Client;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<OracleDataSource>(sp =>
{
    OracleDataSourceBuilder dataSourceBuilder = new("<connection string>");
    return dataSourceBuilder.Build();
});

builder.Services.AddOracleVectorStore();
// </GetStarted4>

// <GetStarted5>
using Oracle.VectorData;
using Oracle.ManagedDataAccess.Client;

OracleDataSourceBuilder dataSourceBuilder = new("<connection string>");
var dataSource = dataSourceBuilder.Build();

var connection = new OracleVectorStore(dataSource);
// </GetStarted5>

// <GetStarted6>
using Oracle.VectorData;

var connection = new OracleVectorStore("<connection string>");
// </GetStarted6>

// <GetStarted7>
using Oracle.VectorData;
using Oracle.ManagedDataAccess.Client;

OracleDataSourceBuilder dataSourceBuilder = new("<connection string>");
var dataSource = dataSourceBuilder.Build();

var collection = new OracleCollection<string, Hotel>(dataSource, "skhotels");
// </GetStarted7>

// <GetStarted8>
using Oracle.VectorData;

var collection = new OracleCollection<string, Hotel>("<connection string>", "skhotels");
// </GetStarted8>

// <PropertyNameOverride>
using Microsoft.Extensions.VectorData;

public class Hotel
{
    [VectorStoreKey]
    public long HotelId { get; set; }

    [VectorStoreData(StorageName = "hotel_name")]
    public string? HotelName { get; set; }

    [VectorStoreData(StorageName = "hotel_description")]
    public string? Description { get; set; }

    [VectorStoreVector(Dimensions: 384, DistanceFunction = DistanceFunction.CosineDistance)]
    public ReadOnlyMemory<float>? DescriptionEmbedding { get; set; }
}
// </PropertyNameOverride>