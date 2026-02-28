---
title: Vector search using Vector Store connectors (Preview)
description: Describes the different options you can use when doing a vector search using Vector Store connectors.
ms.topic: concept-article
ms.date: 09/23/2024
---
# Vector search using Vector Store connectors (Preview)

The Microsoft.Extensions.VectorData library provides vector search capabilities as part of its Vector Store abstractions. This supports filtering and many other options, which this article will explain in more detail.

> [!TIP]
> To see how you can search without generating embeddings yourself, see [Letting the Vector Store generate embeddings](./embedding-generation.md#letting-the-vector-store-generate-embeddings).

## Vector search

The <xref:Microsoft.Extensions.VectorData.VectorStoreCollection%602.SearchAsync*> method allows searching using data that has already been vectorized. This method takes a vector and an optional <xref:Microsoft.Extensions.VectorData.VectorSearchOptions`1> class as input. <xref:Microsoft.Extensions.VectorData.VectorStoreCollection%602.SearchAsync*> is available on the following types:

- <xref:Microsoft.Extensions.VectorData.IVectorSearchable`1>
- <xref:Microsoft.Extensions.VectorData.VectorStoreCollection`2>

Note that <xref:Microsoft.Extensions.VectorData.VectorStoreCollection%602> implements from `IVectorSearchable<TRecord>`.

Assuming you have a collection that already contains data, you can easily search it. Here is an example using Qdrant.

```csharp
using Microsoft.SemanticKernel.Connectors.Qdrant;
using Microsoft.Extensions.VectorData;
using Qdrant.Client;

// Placeholder embedding generation method.
async Task<ReadOnlyMemory<float>> GenerateEmbeddingAsync(string textToVectorize)
{
    // your logic here
}

// Create a Qdrant VectorStore object and choose an existing collection that already contains records.
VectorStore vectorStore = new QdrantVectorStore(new QdrantClient("localhost"), ownsClient: true);
VectorStoreCollection<ulong, Hotel> collection = vectorStore.GetCollection<ulong, Hotel>("skhotels");

// Generate a vector for your search text, using your chosen embedding generation implementation.
ReadOnlyMemory<float> searchVector = await GenerateEmbeddingAsync("I'm looking for a hotel where customer happiness is the priority.");

// Do the search, passing an options object with a Top value to limit results to the single top match.
var searchResult = collection.SearchAsync(searchVector, top: 1);

// Inspect the returned hotel.
await foreach (var record in searchResult)
{
    Console.WriteLine("Found hotel description: " + record.Record.Description);
    Console.WriteLine("Found record score: " + record.Score);
}
```

> [!TIP]
> For more information on how to generate embeddings see [embedding generation](./embedding-generation.md).

## Supported vector types

<xref:Microsoft.Extensions.VectorData.VectorStoreCollection%602.SearchAsync*> takes a generic type as the vector parameter.
The types of vectors supported by each data store vary.
See [the documentation for each connector](./out-of-the-box-connectors/index.md) for the list of supported vector types.

It's also important for the search vector type to match the target vector that is being searched, for example, if you have two vectors
on the same record with different vector types, make sure that the search vector you supply matches the type of the specific vector
you are targeting.
See [VectorProperty](#vectorproperty) for how to pick a target vector if you have more than one per record.

## Vector search options

The following options can be provided using the `VectorSearchOptions<TRecord>` class.

### VectorProperty

The `VectorProperty` option can be used to specify the vector property to target during the search.
If none is provided and the data model contains only one vector, that vector will be used.
If the data model contains no vector or multiple vectors and `VectorProperty` is not provided, the search method will throw.

```csharp
using Microsoft.Extensions.VectorData;
using Microsoft.SemanticKernel.Connectors.InMemory;

var vectorStore = new InMemoryVectorStore();
var collection = vectorStore.GetCollection<int, Product>("skproducts");

// Create the vector search options and indicate that you want to search the FeatureListEmbedding property.
var vectorSearchOptions = new VectorSearchOptions<Product>
{
    VectorProperty = r => r.FeatureListEmbedding
};

// This snippet assumes searchVector is already provided, having been created using the embedding model of your choice.
var searchResult = collection.SearchAsync(searchVector, top: 3, vectorSearchOptions);

public sealed class Product
{
    [VectorStoreKey]
    public int Key { get; set; }

    [VectorStoreData]
    public string Description { get; set; }

    [VectorStoreData]
    public List<string> FeatureList { get; set; }

    [VectorStoreVector(1536)]
    public ReadOnlyMemory<float> DescriptionEmbedding { get; set; }

    [VectorStoreVector(1536)]
    public ReadOnlyMemory<float> FeatureListEmbedding { get; set; }
}
```

### `Top` and `Skip`

The `Top` and `Skip` options allow you to limit the number of results to the Top n results and
to skip a number of results from the top of the resultset.
Top and Skip can be used to do paging if you wish to retrieve a large number of results using separate calls.

```csharp
// Create the vector search options and indicate that you want to skip the first 40 results.
var vectorSearchOptions = new VectorSearchOptions<Product>
{
    Skip = 40
};

// This snippet assumes searchVector is already provided, having been created using the embedding model of your choice.
// Pass 'top: 20' to indicate that you want to retrieve the next 20 results after skipping
// the first 40
var searchResult = collection.SearchAsync(searchVector, top: 20, vectorSearchOptions);

// Iterate over the search results.
await foreach (var result in searchResult)
{
    Console.WriteLine(result.Record.FeatureList);
}
```

The default value `Skip` is 0.

### IncludeVectors

The `IncludeVectors` option allows you to specify whether you wish to return vectors in the search results.
If `false`, the vector properties on the returned model will be left null.
Using `false` can significantly reduce the amount of data retrieved from the vector store during search,
making searches more efficient.

The default value for `IncludeVectors` is `false`.

```csharp
// Create the vector search options and indicate that you want to include vectors in the search results.
var vectorSearchOptions = new VectorSearchOptions<Product>
{
    IncludeVectors = true
};

// This snippet assumes searchVector is already provided, having been created using the embedding model of your choice.
var searchResult = collection.SearchAsync(searchVector, top: 3, vectorSearchOptions);

// Iterate over the search results.
await foreach (var result in searchResult)
{
    Console.WriteLine(result.Record.FeatureList);
}
```

### Filter

The vector search filter option can be used to provide a filter for filtering the records in the chosen collection
before applying the vector search.

This has multiple benefits:

- Reduce latency and processing cost, since only records remaining after filtering need to be compared with the search vector and therefore fewer vector comparisons have to be done.
- Limit the resultset for for example, access control purposes, by excluding data that the user shouldn't have access to.

Note that in order for fields to be used for filtering, many vector stores require those fields to be indexed first.
Some vector stores will allow filtering using any field, but might optionally allow indexing to improve filtering performance.

If creating a collection via the Vector Store abstractions and you wish to enable filtering on a field,
set the <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute.IsIndexed> property to true when defining your data model or when creating your record definition.

> [!TIP]
> For more information on how to set the <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute.IsIndexed> property, see [VectorStoreDataAttribute parameters](./defining-your-data-model.md#vectorstoredataattribute-parameters) or [VectorStoreDataProperty configuration settings](./schema-with-record-definition.md#vectorstoredataproperty-configuration-settings).

Filters are expressed using LINQ expressions based on the type of the data model.
The set of LINQ expressions supported will vary depending on the functionality supported
by each database, but all databases support a broad base of common expressions, for example, equals,
not equals, and, or, etc.

```csharp
// Create the vector search options and set the filter on the options.
var vectorSearchOptions = new VectorSearchOptions<Glossary>
{
    Filter = r => r.Category == "External Definitions" && r.Tags.Contains("memory")
};

// This snippet assumes searchVector is already provided, having been created using the embedding model of your choice.
var searchResult = collection.SearchAsync(searchVector, top: 3, vectorSearchOptions);

// Iterate over the search results.
await foreach (var result in searchResult)
{
    Console.WriteLine(result.Record.Definition);
}

sealed class Glossary
{
    [VectorStoreKey]
    public ulong Key { get; set; }

    // Category is marked as indexed, since you want to filter using this property.
    [VectorStoreData(IsIndexed = true)]
    public string Category { get; set; }

    // Tags is marked as indexed, since you want to filter using this property.
    [VectorStoreData(IsIndexed = true)]
    public List<string> Tags { get; set; }

    [VectorStoreData]
    public string Term { get; set; }

    [VectorStoreData]
    public string Definition { get; set; }

    [VectorStoreVector(1536)]
    public ReadOnlyMemory<float> DefinitionEmbedding { get; set; }
}
```