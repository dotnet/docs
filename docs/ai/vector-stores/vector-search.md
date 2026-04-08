---
title: Vector search using vector store providers
description: Describes the different options you can use when doing a vector search using vector store providers.
ms.topic: concept-article
ms.date: 02/28/2026
ai-usage: ai-assisted
---
# Vector search using vector store providers

The <xref:Microsoft.Extensions.VectorData> library provides vector search capabilities as part of its vector store abstractions. These capabilities include filtering and many other options.

## Vector search

The <xref:Microsoft.Extensions.VectorData.VectorStoreCollection`2.SearchAsync*> method performs a similarity search, returning records whose vector property is most similar to a given value. Assuming you have a collection that already contains data, here is a minimal sample showing vector search using Qdrant:

```csharp
// Create a Qdrant VectorStore object and get a VectorStoreCollection for a collection that already contains records
VectorStore vectorStore = new QdrantVectorStore(new QdrantClient("localhost"), ownsClient: true);
VectorStoreCollection<ulong, Hotel> collection = vectorStore.GetCollection<ulong, Hotel>("skhotels");

// Get the 3 hotels whose vector property is most similar to the query text
IAsyncEnumerable<VectorSearchResult<Hotel>> results = collection.SearchAsync("Big rooms with a view", top: 3);

// Inspect the returned hotels and their similarity scores
await foreach (VectorSearchResult<Hotel> record in results)
{
    Console.WriteLine("Found hotel description: " + record.Record.Description);
    Console.WriteLine("Found record score: " + record.Score);
}
```

For more information on embedding generation, see [Vector properties and embedding generation](./define-your-data-model.md#vector-properties-and-embedding-generation).

## Number of results and skipping results

<xref:Microsoft.Extensions.VectorData.VectorStoreCollection`2.SearchAsync*> has a mandatory `top` parameter that controls the maximum number of records returned from the search. Always consider how many top records you actually need, as overfetching can reduce application performance:

```csharp
IAsyncEnumerable<VectorSearchResult<Hotel>> searchResult = collection.SearchAsync("Big rooms with a view", top: 3);
```

In addition, you can optionally skip records. For example, the following search returns the 20 most relevant products after skipping 40:

```csharp
IAsyncEnumerable<VectorSearchResult<Product>> results = collection.SearchAsync(
    "Green socks",
    top: 20,
    new() { Skip = 40 });
```

`top` and `Skip` can be used to perform paging to retrieve a large number of results using separate calls. However, this technique might not perform well on your database, as it must still find and process the skipped records. For more information, consult your database documentation.

### Metadata filtering

Use the <xref:Microsoft.Extensions.VectorData.VectorSearchOptions`1.Filter?displayProperty=nameWithType> option to filter the records in the chosen collection before applying the vector search. This has multiple benefits:

- Reduces latency and processing cost, since only records remaining after filtering need to be compared with the search vector and therefore fewer vector comparisons have to be done.
- Limits the result set. For example, you can implement access control by excluding data that the user shouldn't have access to, or search only within a specific category of products.

For fields to be used for filtering, many vector stores require those fields to be indexed first. For more information on how to enable indexing on data properties, see [Data property](./define-your-data-model.md#data-property).

Filters are expressed using LINQ expressions based on the type of the data model. The set of LINQ expressions supported varies depending on the functionality supported by each database, but all databases support a broad base of common expressions, for example, equals, not equals, `and`, and `or`.

```csharp
class Glossary
{
    // ...

    // Category is marked as indexed, since you want to filter using this property.
    [VectorStoreData(IsIndexed = true)]
    public required string Category { get; set; }

    // Tags is marked as indexed, since you want to filter using this property.
    [VectorStoreData(IsIndexed = true)]
    public required List<string> Tags { get; set; }
}

IAsyncEnumerable<VectorSearchResult<Glossary>> results = collection.SearchAsync(
    "Some term",
    top: 3,
    new()
    {
        Filter = r => r.Category == "External Definitions" && r.Tags.Contains("memory")
    });
```

### Include vectors in results

By default, vector properties aren't included in the search results, which reduces data transfer. You can configure the search to include them:

```csharp
IAsyncEnumerable<VectorSearchResult<Product>> results = collection.SearchAsync(
    "Green socks",
    top: 3,
    new() { IncludeVectors = true });
```

## Specify the vector property

In most scenarios, only a single vector property is defined in the data model, and `SearchAsync` automatically searches against it. However, when multiple vector properties are defined, you must specify which one should be used:

```csharp
class Product
{
    // ...

    // Multiple vector properties:
    [VectorStoreVector(1536)]
    public ReadOnlyMemory<float> DescriptionEmbedding { get; set; }

    [VectorStoreVector(1536)]
    public ReadOnlyMemory<float> FeatureListEmbedding { get; set; }
}

IAsyncEnumerable<VectorSearchResult<Hotel>> results = collection.SearchAsync(
    "I'm looking for a product with a specific feature.",
    top: 3,
    new() { VectorProperty = r => r.FeatureListEmbedding });
```

## Hybrid search

Hybrid search combines vector similarity search with traditional keyword search, executing both in parallel and returning a combination of the two result sets. This can improve search quality, since keyword matching can capture exact term matches that vector similarity might miss, and vice versa.

> [!NOTE]
> Hybrid search is only available on databases that support it. Only providers for these databases implement the <xref:Microsoft.Extensions.VectorData.IKeywordHybridSearchable`1> interface.

To use hybrid search, your data model needs a string field with full-text search enabled via <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute.IsFullTextIndexed>:

```csharp
class Hotel
{
    [VectorStoreKey]
    public ulong Key { get; set; }

    [VectorStoreData(IsFullTextIndexed = true)]
    public required string Description { get; set; }

    [VectorStoreVector(1536)]
    public string DescriptionEmbedding { get; set; }
}
```

Then call <xref:Microsoft.Extensions.VectorData.IKeywordHybridSearchable`1.HybridSearchAsync*>, passing both search text and keywords:

```csharp
var hybridCollection = (IKeywordHybridSearchable<Hotel>)collection;

IAsyncEnumerable<VectorSearchResult<Hotel>> results = hybridCollection.HybridSearchAsync(
    "I'm looking for a hotel where customer happiness is the priority.",
    ["happiness", "hotel", "customer"],
    top: 3);
```

All the options described for vector search (`top`, `Skip`, `Filter`, `IncludeVectors`, `VectorProperty`) are also available for hybrid search via <xref:Microsoft.Extensions.VectorData.HybridSearchOptions`1>.

In addition, hybrid search supports an `AdditionalProperty` option for specifying which full-text search property to target. If your data model has only one property with `IsFullTextIndexed = true`, it's used automatically; if there are multiple, you must specify which one:

```csharp
IAsyncEnumerable<VectorSearchResult<Hotel>> results = hybridCollection.HybridSearchAsync(
    "I'm looking for a hotel where customer happiness is the priority.",
    ["happiness", "hotel", "customer"],
    top: 3,
    new()
    {
        VectorProperty = r => r.DescriptionEmbedding,
        AdditionalProperty = r => r.Description
    });
```
