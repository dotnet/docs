// <HybridSearch>
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
IKeywordHybridSearchable<Hotel> collection = (IKeywordHybridSearchable<Hotel>)vectorStore.GetCollection<ulong, Hotel>("skhotels");

// Generate a vector for your search text, using your chosen embedding generation implementation.
ReadOnlyMemory<float> searchVector = await GenerateEmbeddingAsync("I'm looking for a hotel where customer happiness is the priority.");

// Do the search, passing an options object with a Top value to limit results to the single top match.
var searchResult = collection.HybridSearchAsync(searchVector, ["happiness", "hotel", "customer"], top: 1);

// Inspect the returned hotel.
await foreach (var record in searchResult)
{
    Console.WriteLine("Found hotel description: " + record.Record.Description);
    Console.WriteLine("Found record score: " + record.Score);
}
// </HybridSearch>

// <VectorPropertyAndAdditionalProperty>
using Microsoft.SemanticKernel.Connectors.Qdrant;
using Microsoft.Extensions.VectorData;
using Qdrant.Client;

var vectorStore = new QdrantVectorStore(new QdrantClient("localhost"), ownsClient: true);
var collection = (IKeywordHybridSearchable<Product>)vectorStore.GetCollection<ulong, Product>("skproducts");

// Create the hybrid search options and indicate that you want
// to search the DescriptionEmbedding vector property and the
// Description full text search property.
var hybridSearchOptions = new HybridSearchOptions<Product>
{
    VectorProperty = r => r.DescriptionEmbedding,
    AdditionalProperty = r => r.Description
};

// This snippet assumes searchVector is already provided, having been created using the embedding model of your choice.
var searchResult = collection.HybridSearchAsync(searchVector, ["happiness", "hotel", "customer"], top: 3, hybridSearchOptions);

public sealed class Product
{
    [VectorStoreKey]
    public int Key { get; set; }

    [VectorStoreData(IsFullTextIndexed = true)]
    public string Name { get; set; }

    [VectorStoreData(IsFullTextIndexed = true)]
    public string Description { get; set; }

    [VectorStoreData]
    public List<string> FeatureList { get; set; }

    [VectorStoreVector(1536)]
    public ReadOnlyMemory<float> DescriptionEmbedding { get; set; }

    [VectorStoreVector(1536)]
    public ReadOnlyMemory<float> FeatureListEmbedding { get; set; }
}
// </VectorPropertyAndAdditionalProperty>

// <TopAndSkip>
// Create the vector search options and indicate that you want to skip the first 40 results and then pass 20 to search to get the next 20.
var hybridSearchOptions = new HybridSearchOptions<Product>
{
    Skip = 40
};

// This snippet assumes searchVector is already provided, having been created using the embedding model of your choice.
var searchResult = collection.HybridSearchAsync(searchVector, ["happiness", "hotel", "customer"], top: 20, hybridSearchOptions);

// Iterate over the search results.
await foreach (var result in searchResult)
{
    Console.WriteLine(result.Record.Description);
}
// </TopAndSkip>

// <IncludeVectors>
// Create the hybrid search options and indicate that you want to include vectors in the search results.
var hybridSearchOptions = new HybridSearchOptions<Product>
{
    IncludeVectors = true
};

// This snippet assumes searchVector is already provided, having been created using the embedding model of your choice.
var searchResult = collection.HybridSearchAsync(searchVector, ["happiness", "hotel", "customer"], top: 3, hybridSearchOptions);

// Iterate over the search results.
await foreach (var result in searchResult)
{
    Console.WriteLine(result.Record.FeatureList);
}
// </IncludeVectors>

// <Filter>
// Create the hybrid search options and set the filter on the options.
var hybridSearchOptions = new HybridSearchOptions<Glossary>
{
    Filter = r => r.Category == "External Definitions" && r.Tags.Contains("memory")
};

// This snippet assumes searchVector is already provided, having been created using the embedding model of your choice.
var searchResult = collection.HybridSearchAsync(searchVector, ["happiness", "hotel", "customer"], top: 3, hybridSearchOptions);

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

    [VectorStoreData(IsFullTextIndexed = true)]
    public string Definition { get; set; }

    [VectorStoreVector(1536)]
    public ReadOnlyMemory<float> DefinitionEmbedding { get; set; }
}
// </Filter>