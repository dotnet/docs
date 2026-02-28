---
title: Using the Couchbase Vector Store connector (Preview)
description: Contains information on how to use a Vector Store connector to access and manipulate data in Couchbase.
author: azaddhirajkumar
ms.topic: concept-article
ms.date: 11/03/2025
---

# Using the Couchbase connector (Preview)

> [!WARNING]
> The Vector Store functionality is in preview, and improvements that require breaking changes might still occur in limited circumstances before release.

## Overview

The Couchbase Vector Store connector can be used to access and manage data in Couchbase. The connector has the
following characteristics.

| Feature Area                 | Support                      |
|------------------------------|------------------------------|
| Collection maps to           | Couchbase collection + index |
| Supported key property types | <ul><li>`string`</li></ul>   |
| Supported data property types | All types that are supported by `System.Text.Json` (either built-in or by using a custom converter) |
| Supported vector property types | <ul><li>`ReadOnlyMemory<float>`</li><li>`Embedding<float>`</li><li>`float[]`</li></ul> |
| Supported distance functions | <ul><li>CosineSimilarity</li><li>DotProductSimilarity</li><li>EuclideanDistance</li></ul> |
| Supported filter clauses | <ul><li>`AnyTagEqualTo`</li><li>`EqualTo`</li></ul> |
| Supports multiple vectors in a record | Yes |
| IsIndexed supported? | Yes |
| IsFullTextIndexed supported? | Yes |
| StoragePropertyName supported? | No, use `JsonSerializerOptions` and `JsonPropertyNameAttribute` instead. [See here for more info.](#data-mapping) |
| HybridSearch supported? | Yes |

## Get started

Add the Couchbase Vector Store connector NuGet package to your project.

```dotnetcli
dotnet add package CouchbaseConnector.SemanticKernel --prerelease
```

You can add the vector store to the `IServiceCollection` dependency injection container using extension methods provided by the Semantic Kernel connector packages.

```csharp
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
```

```csharp
using Couchbase.SemanticKernel;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCouchbaseVectorStore(
    connectionString: "couchbases://your-cluster-address",
    username: "username",
    password: "password",
    bucketName: "bucket-name",
    scopeName: "scope-name");
```

## Configure index type

The vector store defaults to using Hyperscale indexes. You can specify a different index type by passing `CouchbaseVectorStoreOptions`:

```csharp
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
```

Extension methods that take no parameters are also provided. These require an instance of the `IScope` class to be
separately registered with the dependency injection container.

```csharp
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
```

```csharp
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
```

You can construct a Couchbase Vector Store instance directly.

```csharp
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
```

It's possible to construct a direct reference to a named collection.

## Use query collection (Hyperscale or composite index)

For high-performance vector search with Hyperscale indexes:

```csharp
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
```

### Use search collection (seach vector index)

For hybrid search scenarios combining full-text search:

```csharp
using Couchbase.SemanticKernel;
using Couchbase;
using Couchbase.KeyValue;

var cluster = await Cluster.ConnectAsync(clusterOptions);
var bucket = await cluster.BucketAsync("bucket-name");
var scope = bucket.Scope("scope-name");

var collection = new CouchbaseSearchCollection<string, Hotel>(
    scope,
    "skhotels");
```

### Index type comparison

Couchbase offers three types of indexes for vector search:

**Hyperscale vector indexes**

- Best for pure vector searches - content discovery, recommendations, semantic search
- High performance with low memory footprint - designed to scale to billions of vectors
- Optimized for concurrent operations - supports simultaneous searches and inserts
- **Use when:** You primarily perform vector-only queries without complex scalar filtering
- **Ideal for:** Large-scale semantic search, recommendation systems, content discovery
- **Requires:** Couchbase Server 8.0+ or Capella

**Composite vector indexes**

- Best for filtered vector searches - combines vector search with scalar value filtering
- Efficient pre-filtering - scalar attributes reduce the vector comparison scope
- **Use when:** Your queries combine vector similarity with scalar filters that eliminate large portions of data
- **Ideal for:** Compliance-based filtering, user-specific searches, time-bounded queries
- **Requires:** Couchbase Server 8.0+ or Capella

**Search vector indexes**

- Best for hybrid searches combining full-text search with vector similarity
- Allows semantic search alongside traditional keyword matching
- Supports geospatial searches in addition to vector and text
- **Use when:** You need to combine traditional keyword search with vector similarity search in the same query
- **Ideal for:** E-commerce product search, travel recommendations, content discovery with multiple search criteria
- **Requires:** Couchbase Server 7.6+ or Capella

#### Choose the right index type

- Start with **Hyperscale Index** for pure vector searches and large datasets (scales to billions)
- Choose **Composite Index** when scalar filters significantly reduce your search space (works well for tens of millions to billions of vectors)
- Use **Search Vector Index** for hybrid search combining text and vectors

[Detailed comparison of vector index types](https://docs.couchbase.com/server/current/vector-index/use-vector-indexes.html)

## Data mapping

The Couchbase connector will use `System.Text.Json.JsonSerializer` to do mapping. Properties in the data model are serialized into a JSON object and stored as the document value in Couchbase.

Usage of the `JsonPropertyNameAttribute` is supported if a different storage name to the data model property name is required. It's also possible to use a custom `JsonSerializerOptions` instance with a customized property naming policy.

```csharp
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
```

Since a naming policy of snake case upper was chosen, here is an example of how this data type will be stored in Couchbase. Also note the use of `JsonPropertyNameAttribute` on the `Description` property to further customize the storage naming.

```csharp
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
```

```json
{
  "_id" : "h1",
  "HOTEL_ID" : "h1",
  "HOTEL_NAME" : "Hotel Happy",
  "HOTEL_DESCRIPTION" : "A place where everyone can be happy.",
  "DESCRIPTION_EMBEDDING" : [
    0.9,
    0.1,
    0.1,
    0.1
  ]
}
```