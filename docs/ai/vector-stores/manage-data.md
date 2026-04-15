---
title: Manage vector store data
description: Describes how to upsert, delete, and retrieve records in a vector store collection using Microsoft.Extensions.VectorData.
ms.topic: concept-article
ms.date: 04/06/2026
ai-usage: ai-assisted
---

# Manage data

Once you've [defined your data model](./define-your-data-model.md) and obtained a <xref:Microsoft.Extensions.VectorData.VectorStoreCollection`2>, you can manage records in your vector store collection. This article covers the core data management operations: upserting, deleting, and retrieving records. Searching your data using vector similarity is covered in [Vector search](./vector-search.md).

All the examples below use the following data model, which uses [automatic embedding generation](./define-your-data-model.md#automatic-embedding-generation-recommended):

```csharp
public class Hotel
{
    [VectorStoreKey]
    public ulong HotelId { get; set; }

    [VectorStoreData(IsIndexed = true)]
    public required string HotelName { get; set; }

    [VectorStoreData(IsFullTextIndexed = true)]
    public required string Description { get; set; }

    [VectorStoreVector(Dimensions: 1536, DistanceFunction = DistanceFunction.CosineSimilarity)]
    public required string DescriptionEmbedding { get; set; }

    [VectorStoreData(IsIndexed = true)]
    public required string[] Tags { get; set; }
}
```

Note that the `DescriptionEmbedding` property is a `string` rather than a vector type such as `ReadOnlyMemory<float>`. This means MEVD automatically generates embeddings when upserting records, using the <xref:Microsoft.Extensions.AI.IEmbeddingGenerator`2> configured on the vector store.

The following setup code gets a collection and ensures it exists:

```csharp
var vectorStore = new QdrantVectorStore(
    new QdrantClient("localhost"),
    ownsClient: true,
    new QdrantVectorStoreOptions
    {
        EmbeddingGenerator = embeddingGenerator
    });

var collection = vectorStore.GetCollection<ulong, Hotel>("hotels");
await collection.EnsureCollectionExistsAsync();
```

## Upsert records

Use <xref:Microsoft.Extensions.VectorData.VectorStoreCollection`2.UpsertAsync*> to insert a new record or update an existing one. If a record with the same key already exists, it's replaced; otherwise, a new record is created:

```csharp
var hotel = new Hotel
{
    HotelId = 1,
    HotelName = "Hotel Happy",
    Description = "A happy hotel with good vibes.",
    DescriptionEmbedding = "A happy hotel with good vibes.",
    Tags = ["happy", "vibes"]
};

await collection.UpsertAsync(hotel);
```

To upsert multiple records at once, pass a collection:

```csharp
var hotels = new[]
{
    new Hotel
    {
        HotelId = 1,
        HotelName = "Hotel Happy",
        Description = "A happy hotel with good vibes.",
        DescriptionEmbedding = "A happy hotel with good vibes.",
        Tags = ["happy", "vibes"]
    },
    new Hotel
    {
        HotelId = 2,
        HotelName = "Hotel Luxury",
        Description = "A luxurious hotel with top-notch amenities.",
        DescriptionEmbedding = "A luxurious hotel with top-notch amenities.",
        Tags = ["luxury", "amenities"]
    }
};

await collection.UpsertAsync(hotels);
```

> [!TIP]
> Prefer the batch overload when upserting multiple records, as this reduces database roundtrips. Also, with automatic embedding generation, the batch overload usually generates embeddings for all records in a single call to the embedding model, which is more efficient than generating them one at a time.

## Delete records

Use <xref:Microsoft.Extensions.VectorData.VectorStoreCollection`2.DeleteAsync*> to remove records from the collection by key:

```csharp
await collection.DeleteAsync(key: 1);
```

To delete multiple records at once, pass a collection:

```csharp
await collection.DeleteAsync(keys: [1, 2, 3]);
```

> [!NOTE]
> If a record with the specified key doesn't exist, the delete operation is silently ignored.

## Retrieve records by key

Use <xref:Microsoft.Extensions.VectorData.VectorStoreCollection`2.GetAsync*> to retrieve records by their key:

```csharp
Hotel? hotel = await collection.GetAsync(key: 1);
```

`GetAsync` returns the record if found, or `null` if no record with the given key exists.

To retrieve multiple records at once, pass a collection of keys. This overload returns an `IAsyncEnumerable<TRecord>` containing only the records that were found:

```csharp
IAsyncEnumerable<Hotel> hotels = collection.GetAsync(keys: [1, 2, 3]);

await foreach (Hotel hotel in hotels)
{
    Console.WriteLine(hotel.HotelName);
}
```

> [!NOTE]
> Only found records are returned, so the result set might be smaller than the set of requested keys. There is no guarantee on the ordering of the returned records.

### Include vectors in results

By default, vector properties aren't included in the retrieved records, which reduces data transfer. To include them, pass a <xref:Microsoft.Extensions.VectorData.RecordRetrievalOptions> with <xref:Microsoft.Extensions.VectorData.RecordRetrievalOptions.IncludeVectors> set to `true`:

```csharp
var hotel = await collection.GetAsync(
    key: 1,
    new() { IncludeVectors = true });
```

## Retrieve records by filter

Use the filter overload of <xref:Microsoft.Extensions.VectorData.VectorStoreCollection`2.GetAsync*> to retrieve records that match a given condition, rather than by key or vector similarity:

```csharp
IAsyncEnumerable<Hotel> hotels = collection.GetAsync(
    filter: h => h.HotelName == "Hotel Happy",
    top: 10);

await foreach (Hotel hotel in hotels)
{
    Console.WriteLine(hotel.HotelName);
}
```

Filters are expressed as LINQ expressions. The supported expressions vary depending on the database provider, but all providers support common comparisons such as equality, inequality, and logical `&&` and `||`.

> [!IMPORTANT]
> For properties to be usable in filters, many databases require them to be indexed. Even where indexes aren't required, they can greatly increase the performance of filters. Set `IsIndexed = true` on the <xref:Microsoft.Extensions.VectorData.VectorStoreDataAttribute> when defining your data model. For more information, see [Data property](./define-your-data-model.md#data-property).

### Filter options

Use <xref:Microsoft.Extensions.VectorData.FilteredRecordRetrievalOptions`1> to control paging, ordering, and whether vectors are included in the results:

```csharp
IAsyncEnumerable<Hotel> hotels = collection.GetAsync(
    filter: h => h.Tags.Contains("luxury"),
    top: 10,
    new()
    {
        Skip = 20,
        IncludeVectors = false,
        OrderBy = order => order.Ascending(h => h.HotelName)
    });
```

The following table describes the available options:

| Option           | Description                                                                                     |
|------------------|-------------------------------------------------------------------------------------------------|
| `Skip`           | Number of matching records to skip before returning results. Useful for paging. Default is `0`. |
| `OrderBy`        | Specifies the property and direction to order results by. Use `.Ascending()` or `.Descending()` to define the sort. If not provided, the order is non-deterministic. |
| `IncludeVectors` | Whether to include vector data in the returned records. Default is `false`.                     |
