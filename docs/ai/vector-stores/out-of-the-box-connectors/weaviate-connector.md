---
title: Using the Weaviate Vector Store connector (Preview)
description: Contains information on how to use a Vector Store connector to access and manipulate data in Weaviate.
ms.topic: concept-article
ms.date: 09/23/2024
---
# Using the Weaviate Vector Store connector (Preview)

> [!WARNING]
> The Weaviate Vector Store functionality is in preview, and improvements that require breaking changes might still occur in limited circumstances before release.

## Overview

The Weaviate Vector Store connector can be used to access and manage data in Weaviate. The connector has the following characteristics.

| Feature Area                 | Support             |
|------------------------------|---------------------|
| Collection maps to           | Weaviate Collection |
| Supported key property types | Guid                |
| Supported data property types | <ul><li>string</li><li>byte</li><li>short</li><li>int</li><li>long</li><li>double</li><li>float</li><li>decimal</li><li>bool</li><li>DateTime</li><li>DateTimeOffset</li><li>Guid</li><li>*and enumerables of each of these types*</li></ul> |
| Supported vector property types | <ul><li>ReadOnlyMemory\<float\></li><li>Embedding\<float\></li><li>float[]</li></ul> |
| Supported index types | <ul><li>Hnsw</li><li>Flat</li><li>Dynamic</li></ul> |
| Supported distance functions | <ul><li>CosineDistance</li><li>NegativeDotProductSimilarity</li><li>EuclideanSquaredDistance</li><li>HammingDistance</li><li>ManhattanDistance</li></ul> |
| Supported filter clauses | <ul><li>AnyTagEqualTo</li><li>EqualTo</li></ul> |
| Supports multiple vectors in a record | Yes |
| IsIndexed supported? | Yes |
| IsFullTextIndexed supported? | Yes |
| StorageName supported? | No, use `JsonSerializerOptions` and `JsonPropertyNameAttribute` instead. [See here for more info.](#data-mapping) |
| HybridSearch supported? | Yes |

## Limitations

Notable Weaviate connector functionality limitations.

| Feature Area | Workaround |
|--|--|
| Using the 'vector' property for single vector objects is not supported | Use of the 'vectors' property is supported instead. |

> [!WARNING]
> Weaviate requires collection names to start with an upper case letter. If you do not provide a collection name with an upper case letter, Weaviate will return an error when you try and create your collection. The error that you will see is `Cannot query field "mycollection" on type "GetObjectsObj". Did you mean "Mycollection"?` where `mycollection` is your collection name. In this example, if you change your collection name to `Mycollection` instead, this will fix the error.

## Get started

Add the Weaviate Vector Store connector NuGet package to your project.

```dotnetcli
dotnet add package Microsoft.SemanticKernel.Connectors.Weaviate --prerelease
```

You can add the vector store to the `IServiceCollection` dependency injection container using extension methods provided by the Semantic Kernel connector packages.
The Weaviate vector store uses an `HttpClient` to communicate with the Weaviate service. There are two options for providing the URL/endpoint for the Weaviate service.
It can be provided via options or by setting the base address of the `HttpClient`.

This first example shows how to set the service URL via options.
Also note that these methods will retrieve an `HttpClient` instance for making calls to the Weaviate service from the dependency injection service provider.

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

// Using a ServiceCollection.
var services = new ServiceCollection();
services.AddWeaviateVectorStore(new Uri("http://localhost:8080/v1/"), apiKey: null);
```

```csharp
using Microsoft.Extensions.DependencyInjection;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddWeaviateVectorStore(new Uri("http://localhost:8080/v1/"), apiKey: null);
```

Overloads where you can specify your own `HttpClient` are also provided.
In this case it's possible to set the service url via the `HttpClient` `BaseAddress` option.

```csharp
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

// Using a ServiceCollection.
var services = new ServiceCollection();
using HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:8080/v1/") };
services.AddWeaviateVectorStore(_ => client);
```

```csharp
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
using HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:8080/v1/") };
builder.Services.AddWeaviateVectorStore(_ => client);
```

You can construct a Weaviate Vector Store instance directly as well.

```csharp
using System.Net.Http;
using Microsoft.SemanticKernel.Connectors.Weaviate;

var vectorStore = new WeaviateVectorStore(
    new HttpClient { BaseAddress = new Uri("http://localhost:8080/v1/") });
```

It's possible to construct a direct reference to a named collection.

```csharp
using System.Net.Http;
using Microsoft.SemanticKernel.Connectors.Weaviate;

var collection = new WeaviateCollection<Guid, Hotel>(
    new HttpClient { BaseAddress = new Uri("http://localhost:8080/v1/") },
    "Skhotels");
```

If needed, it is possible to pass an API key, as an option, when using any of the previously mentioned mechanisms. For example:

```csharp
using Microsoft.SemanticKernel;

var services = new ServiceCollection();
services.AddWeaviateVectorStore(new Uri("http://localhost:8080/v1/"), secretVar);
```

## Data mapping

The Weaviate Vector Store connector provides a default mapper when mapping from the data model to storage.
Weaviate requires properties to be mapped into id, payload and vectors groupings.
The default mapper uses the model annotations or record definition to determine the type of each property and to do this mapping.

- The data model property annotated as a key will be mapped to the Weaviate `id` property.
- The data model properties annotated as data will be mapped to the Weaviate `properties` object.
- The data model properties annotated as vectors will be mapped to the Weaviate `vectors` object.

The default mapper uses `System.Text.Json.JsonSerializer` to convert to the storage schema.
This means that usage of the `JsonPropertyNameAttribute` is supported if a different storage name to the
data model property name is required.

Here is an example of a data model with `JsonPropertyNameAttribute` set and how that will be represented in Weaviate.

```csharp
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
```

```json
{
    "id": "11111111-1111-1111-1111-111111111111",
    "properties": { "HotelName": "Hotel Happy", "Description": "A place where everyone can be happy." },
    "vectors": {
        "HOTEL_DESCRIPTION_EMBEDDING": [0.9, 0.1, 0.1, 0.1],
    }
}
```