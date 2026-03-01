using Microsoft.Extensions.VectorData;
using Microsoft.SemanticKernel.Connectors.InMemory;

// <CreateVectorStore>
// Create an in-memory vector store (no external service required).
// For production, replace this with a connector for your preferred database.
var vectorStore = new InMemoryVectorStore();
// </CreateVectorStore>

// <GetCollection>
// Get a reference to a collection named "hotels".
VectorStoreCollection<int, Hotel> collection =
    vectorStore.GetCollection<int, Hotel>("hotels");

// Ensure the collection exists in the database.
await collection.EnsureCollectionExistsAsync();
// </GetCollection>

// <UpsertRecords>
// Upsert records into the collection.
// In a real app, generate embeddings using an IEmbeddingGenerator.
// The CreateFakeEmbedding helper at the bottom of this file generates
// placeholder vectors for demonstration purposes only.
var hotels = new List<Hotel>
{
    new()
    {
        HotelId = 1,
        HotelName = "Seaside Retreat",
        Description = "A peaceful hotel on the coast with stunning ocean views.",
        DescriptionEmbedding = CreateFakeEmbedding(1),
        Tags = ["beach", "ocean", "relaxation"]
    },
    new()
    {
        HotelId = 2,
        HotelName = "Mountain Lodge",
        Description = "A cozy lodge in the mountains with hiking trails nearby.",
        DescriptionEmbedding = CreateFakeEmbedding(2),
        Tags = ["mountain", "hiking", "nature"]
    },
    new()
    {
        HotelId = 3,
        HotelName = "City Centre Hotel",
        Description = "A modern hotel in the heart of the city, close to attractions.",
        DescriptionEmbedding = CreateFakeEmbedding(3),
        Tags = ["city", "business", "urban"]
    }
};

foreach (Hotel h in hotels)
{
    await collection.UpsertAsync(h);
}
// </UpsertRecords>

// <GetRecord>
// Get a specific record by its key.
Hotel? hotel = await collection.GetAsync(1);
if (hotel is not null)
{
    Console.WriteLine($"Hotel: {hotel.HotelName}");
    Console.WriteLine($"Description: {hotel.Description}");
}
// </GetRecord>

// <GetBatch>
// Get multiple records by their keys.
IAsyncEnumerable<Hotel> hotelBatch = collection.GetAsync([1, 2, 3]);
await foreach (Hotel h in hotelBatch)
{
    Console.WriteLine($"Batch hotel: {h.HotelName}");
}
// </GetBatch>

ReadOnlyMemory<float> queryEmbedding = CreateFakeEmbedding(1);

// <SearchBasic>
// Search for the top 2 hotels most similar to the query embedding.
IAsyncEnumerable<VectorSearchResult<Hotel>> searchResults =
    collection.SearchAsync(queryEmbedding, top: 2);

await foreach (VectorSearchResult<Hotel> result in searchResults)
{
    Console.WriteLine($"Found: {result.Record.HotelName} (score: {result.Score:F4})");
}
// </SearchBasic>

// <SearchWithFilter>
// Filter results before the vector comparison.
// Only properties marked with IsIndexed = true can be used in filters.
var searchOptions = new VectorSearchOptions<Hotel>
{
    Filter = h => h.HotelName == "Seaside Retreat"
};

IAsyncEnumerable<VectorSearchResult<Hotel>> filteredResults =
    collection.SearchAsync(queryEmbedding, top: 2, searchOptions);

await foreach (VectorSearchResult<Hotel> result in filteredResults)
{
    Console.WriteLine($"Filtered: {result.Record.HotelName} (score: {result.Score:F4})");
}
// </SearchWithFilter>

// <SearchOptions>
// Use VectorSearchOptions to control paging and vector inclusion.
var pagedOptions = new VectorSearchOptions<Hotel>
{
    Skip = 1,           // Skip the first result (useful for paging).
    IncludeVectors = false  // Don't include vector data in results (default).
};

IAsyncEnumerable<VectorSearchResult<Hotel>> pagedResults =
    collection.SearchAsync(queryEmbedding, top: 2, pagedOptions);

await foreach (VectorSearchResult<Hotel> result in pagedResults)
{
    Console.WriteLine($"Paged: {result.Record.HotelName}");
}
// </SearchOptions>

// <DeleteRecord>
// Delete a record by its key.
await collection.DeleteAsync(3);
// </DeleteRecord>

// <DeleteCollection>
// Delete the entire collection from the vector store.
await collection.EnsureCollectionDeletedAsync();
// </DeleteCollection>

// Helper to create a predictable fake embedding for demonstration.
// In a real app, use IEmbeddingGenerator to generate real embeddings.
static ReadOnlyMemory<float> CreateFakeEmbedding(int seed)
{
    var random = new Random(seed);
    float[] vector = new float[1536];
    for (int i = 0; i < vector.Length; i++)
    {
        vector[i] = (float)random.NextDouble();
    }
    return new ReadOnlyMemory<float>(vector);
}
