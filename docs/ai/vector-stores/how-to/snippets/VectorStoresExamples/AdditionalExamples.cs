// <TargetVectorProperty>
// A data model with two vector properties.
public class Hotel
{
    [VectorStoreKey]
    public int HotelId { get; set; }

    [VectorStoreData]
    public string? HotelName { get; set; }

    // Two separate embeddings for different aspects of the hotel.
    [VectorStoreVector(1536)]
    public ReadOnlyMemory<float>? DescriptionEmbedding { get; set; }

    [VectorStoreVector(1536)]
    public ReadOnlyMemory<float>? AmenitiesEmbedding { get; set; }
}

// Target the amenities embedding specifically.
var options = new VectorSearchOptions<Hotel>
{
    VectorProperty = r => r.AmenitiesEmbedding
};

IAsyncEnumerable<VectorSearchResult<Hotel>> results =
    collection.SearchAsync(queryEmbedding, top: 3, options);
// </TargetVectorProperty>

// <EmbeddingSourceModel>
public class FinanceInfo
{
    [VectorStoreKey]
    public int Key { get; set; }

    [VectorStoreData]
    public string Text { get; set; } = "";

    // Use a string type to trigger automatic embedding generation on upsert.
    [VectorStoreVector(1536)]
    public string EmbeddingSource { get; set; } = "";
}
// </EmbeddingSourceModel>

// <HybridSearch>
// Check whether the collection supports hybrid search.
if (collection is IKeywordHybridSearchable<Hotel> hybridCollection)
{
    ReadOnlyMemory<float> queryEmbedding =
        await embeddingGenerator.GenerateVectorAsync("peaceful beachfront hotel");

    // Provide both a vector and keywords for hybrid search.
    var results = hybridCollection.HybridSearchAsync(
        queryEmbedding,
        keywords: ["ocean", "beach"],
        top: 3);

    await foreach (var result in results)
    {
        Console.WriteLine($"Hotel: {result.Record.HotelName}, Score: {result.Score}");
    }
}
// </HybridSearch>

// <SwitchConnectors>
// Development: in-memory
var vectorStore = new InMemoryVectorStore();

// Production: Azure AI Search (swap in at startup)
// var vectorStore = new AzureAISearchVectorStore(new SearchIndexClient(...));
// </SwitchConnectors>
