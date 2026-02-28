// <GetStarted1>
using Microsoft.SemanticKernel;
using Couchbase.SemanticKernel;

// Using a ServiceCollection.
var kernelBuilder = Kernel
    .CreateBuilder()
    .AddCouchbaseVectorStore(
        connectionString: "couchbases://your-cluster-address",
        username: "username",
        password: "password",
        bucketName: "bucket-name",
        scopeName: "scope-name");
// </GetStarted1>

// <GetStarted2>
using Couchbase.SemanticKernel;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCouchbaseVectorStore(
    connectionString: "couchbases://your-cluster-address",
    username: "username",
    password: "password",
    bucketName: "bucket-name",
    scopeName: "scope-name");
// </GetStarted2>

// <ConfigureIndexType1>
using Couchbase.SemanticKernel;

var builder = WebApplication.CreateBuilder(args);

// Option 1: Use Hyperscale index
builder.Services.AddCouchbaseVectorStore(
    connectionString: "couchbases://your-cluster-address",
    username: "username",
    password: "password",
    bucketName: "bucket-name",
    scopeName: "scope-name",
    options: new CouchbaseVectorStoreOptions
    {
        IndexType = CouchbaseIndexType.Hyperscale
    });

// Option 2: Use Composite index
builder.Services.AddCouchbaseVectorStore(
    connectionString: "couchbases://your-cluster-address",
    username: "username",
    password: "password",
    bucketName: "bucket-name",
    scopeName: "scope-name",
    options: new CouchbaseVectorStoreOptions
    {
        IndexType = CouchbaseIndexType.Composite
    });

// Option 3: Use Search vector index
builder.Services.AddCouchbaseVectorStore(
    connectionString: "couchbases://your-cluster-address",
    username: "username",
    password: "password",
    bucketName: "bucket-name",
    scopeName: "scope-name",
    options: new CouchbaseVectorStoreOptions
    {
        IndexType = CouchbaseIndexType.Search
    });
// </ConfigureIndexType1>

// <ConfigureIndexType2>
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Couchbase;
using Couchbase.KeyValue;

// Using a ServiceCollection.
var services = new ServiceCollection();
services.AddSingleton<ICluster>(sp =>
{
    var clusterOptions = new ClusterOptions
    {
        ConnectionString = "couchbases://your-cluster-address",
        UserName = "username",
        Password = "password"
    };

    return Cluster.ConnectAsync(clusterOptions).GetAwaiter().GetResult();
});

services.AddSingleton<IScope>(sp =>
{
    var cluster = sp.GetRequiredService<ICluster>();
    var bucket = cluster.BucketAsync("bucket-name").GetAwaiter().GetResult();
    return bucket.Scope("scope-name");
});

// Add Couchbase Vector Store
services.AddCouchbaseVectorStore();
// </ConfigureIndexType2>

// <ConfigureIndexType3>
using Microsoft.Extensions.DependencyInjection;
using Couchbase.KeyValue;
using Couchbase;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICluster>(sp =>
{
    var clusterOptions = new ClusterOptions
    {
        ConnectionString = "couchbases://your-cluster-address",
        UserName = "username",
        Password = "password"
    };

    return Cluster.ConnectAsync(clusterOptions).GetAwaiter().GetResult();
});

builder.Services.AddSingleton<IScope>(sp =>
{
    var cluster = sp.GetRequiredService<ICluster>();
    var bucket = cluster.BucketAsync("bucket-name").GetAwaiter().GetResult();
    return bucket.Scope("scope-name");
});

// Add Couchbase Vector Store
builder.Services.AddCouchbaseVectorStore();
// </ConfigureIndexType3>

// <ConfigureIndexType4>
using Couchbase;
using Couchbase.KeyValue;
using Couchbase.SemanticKernel;

var clusterOptions = new ClusterOptions
{
    ConnectionString = "couchbases://your-cluster-address",
    UserName = "username",
    Password = "password"
};

var cluster = await Cluster.ConnectAsync(clusterOptions);
var bucket = await cluster.BucketAsync("bucket-name");
var scope = bucket.Scope("scope-name");

var vectorStore = new CouchbaseVectorStore(scope);
// </ConfigureIndexType4>

// <UseQueryCollectionHyperscaleOrCompositeI>
using Couchbase.SemanticKernel;
using Couchbase;
using Couchbase.KeyValue;

var cluster = await Cluster.ConnectAsync(clusterOptions);
var bucket = await cluster.BucketAsync("bucket-name");
var scope = bucket.Scope("scope-name");

// Using Hyperscale index (default)
var collection = new CouchbaseQueryCollection<string, Hotel>(
    scope,
    "skhotels",
    indexType: CouchbaseIndexType.Hyperscale);

// Or using Composite index
var collectionComposite = new CouchbaseQueryCollection<string, Hotel>(
    scope,
    "skhotels",
    indexType: CouchbaseIndexType.Composite);
// </UseQueryCollectionHyperscaleOrCompositeI>

// <UseSearchCollectionSeachVectorIndex>
using Couchbase.SemanticKernel;
using Couchbase;
using Couchbase.KeyValue;

var cluster = await Cluster.ConnectAsync(clusterOptions);
var bucket = await cluster.BucketAsync("bucket-name");
var scope = bucket.Scope("scope-name");

var collection = new CouchbaseSearchCollection<string, Hotel>(
    scope,
    "skhotels");
// </UseSearchCollectionSeachVectorIndex>

// <DataMapping1>
using Couchbase.SemanticKernel;
using Couchbase.KeyValue;
using System.Text.Json;

var jsonSerializerOptions = new JsonSerializerOptions
{
    PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseUpper
};

var options = new CouchbaseQueryCollectionOptions
{
    JsonSerializerOptions = jsonSerializerOptions
};

var collection = new CouchbaseQueryCollection<string, Hotel>(scope, "skhotelsjson", options);
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

    [JsonPropertyName("HOTEL_DESCRIPTION")]
    [VectorStoreData(IsFullTextIndexed = true)]
    public string Description { get; set; }

    [VectorStoreVector(Dimensions: 4, DistanceFunction.CosineSimilarity)]
    public ReadOnlyMemory<float>? DescriptionEmbedding { get; set; }
}
// </DataMapping2>