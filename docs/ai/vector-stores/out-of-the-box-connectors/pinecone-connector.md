---
title: Using the Pinecone Vector Store connector (Preview)
description: Contains information on how to use a Vector Store connector to access and manipulate data in Pinecone.
ms.topic: concept-article
ms.date: 07/08/2024
---
# Using the Pinecone connector (Preview)

> [!WARNING]
> The Pinecone Vector Store functionality is in preview, and improvements that require breaking changes might still occur in limited circumstances before release.

## Overview

The Pinecone Vector Store connector can be used to access and manage data in Pinecone. The connector has the following characteristics.

| Feature Area                 | Support                   |
|------------------------------|---------------------------|
| Collection maps to           | Pinecone serverless Index |
| Supported key property types | string                    |
| Supported data property types | <ul><li>string</li><li>int</li><li>long</li><li>double</li><li>float</li><li>bool</li><li>decimal</li><li>*enumerables of type* string</li></ul> |
| Supported vector property types | <ul><li>ReadOnlyMemory\<float\></li><li>Embedding\<float\></li><li>float[]</li></ul> |
| Supported index types | PGA (Pinecone Graph Algorithm) |
| Supported distance functions | <ul><li>CosineSimilarity</li><li>DotProductSimilarity</li><li>EuclideanSquaredDistance</li></ul> |
| Supported filter clauses | <ul><li>EqualTo</li></ul> |
| Supports multiple vectors in a record | No |
| IsIndexed supported? | Yes |
| IsFullTextIndexed supported? | No |
| StorageName supported? | Yes |
| HybridSearch supported? | No |
| Integrated Embeddings supported? | No |

## Get started

Add the Pinecone Vector Store connector NuGet package to your project.

```dotnetcli
dotnet add package Microsoft.SemanticKernel.Connectors.Pinecone --prerelease
```

You can add the vector store to the `IServiceCollection` dependency injection container using extension methods provided by the Semantic Kernel connector packages.

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

// Using a ServiceCollection.
var services = new ServiceCollection();
services.AddPineconeVectorStore(pineconeApiKey);
```

```csharp
using Microsoft.Extensions.DependencyInjection;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddPineconeVectorStore(pineconeApiKey);
```

Extension methods that take no parameters are also provided. These require an instance of the `PineconeClient` to be separately registered with the dependency injection container.

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using PineconeClient = Pinecone.PineconeClient;

// Using a ServiceCollection.
var services = new ServiceCollection();
services.AddSingleton<PineconeClient>(
    sp => new PineconeClient(pineconeApiKey));
services.AddPineconeVectorStore();
```

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using PineconeClient = Pinecone.PineconeClient;

// Using IServiceCollection with ASP.NET Core.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<PineconeClient>(
    sp => new PineconeClient(pineconeApiKey));
builder.Services.AddPineconeVectorStore();
```

You can construct a Pinecone Vector Store instance directly.

```csharp
using Microsoft.SemanticKernel.Connectors.Pinecone;
using PineconeClient = Pinecone.PineconeClient;

var vectorStore = new PineconeVectorStore(
    new PineconeClient(pineconeApiKey));
```

It's possible to construct a direct reference to a named collection.

```csharp
using Microsoft.SemanticKernel.Connectors.Pinecone;
using PineconeClient = Pinecone.PineconeClient;

var collection = new PineconeCollection<string, Hotel>(
    new PineconeClient(pineconeApiKey),
    "skhotels");
```

## Index namespace

The Vector Store abstraction does not support a multi tiered record grouping mechanism. Collections in the abstraction map to a Pinecone serverless index
and no second level exists in the abstraction. Pinecone does support a second level of grouping called namespaces.

By default the Pinecone connector will pass null as the namespace for all operations. However it is possible to pass a single namespace to the
Pinecone collection when constructing it and use this instead for all operations.

```csharp
using Microsoft.SemanticKernel.Connectors.Pinecone;
using PineconeClient = Pinecone.PineconeClient;

var collection = new PineconeCollection<string, Hotel>(
    new PineconeClient(pineconeApiKey),
    "skhotels",
    new() { IndexNamespace = "seasidehotels" });
```

## Data mapping

The Pinecone connector provides a default mapper when mapping data from the data model to storage.
Pinecone requires properties to be mapped into id, metadata and values groupings.
The default mapper uses the model annotations or record definition to determine the type of each property and to do this mapping.

- The data model property annotated as a key will be mapped to the Pinecone id property.
- The data model properties annotated as data will be mapped to the Pinecone metadata object.
- The data model property annotated as a vector will be mapped to the Pinecone vector property.

### Property name override

For data properties, you can provide override field names to use in storage that is different to the
property names on the data model. This is not supported for keys, since a key has a fixed name in Pinecone.
It's also not supported for vectors, since the vector is stored under a fixed name `values`.
The property name override is done by setting the <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute.StorageName> option via the data model attributes or record definition.

Here is an example of a data model with <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute.StorageName> set on its attributes and how that will be represented in Pinecone.

```csharp
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
```

```json
{
    "id": "h1",
    "values": [0.9, 0.1, 0.1, 0.1],
    "metadata": { "hotel_name": "Hotel Happy", "hotel_description": "A place where everyone can be happy." }
}
```