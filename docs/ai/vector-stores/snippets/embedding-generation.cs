// <LetTheVectorStoreGenerateEmbeddings>
[VectorStoreVector(1536)]
public string Embedding { get; set; }
// </LetTheVectorStoreGenerateEmbeddings>

// <OnTheVectorStore>
using Microsoft.Extensions.AI;
using Microsoft.SemanticKernel.Connectors.Qdrant;
using OpenAI;
using Qdrant.Client;

var embeddingGenerator = new OpenAIClient("your key")
    .GetEmbeddingClient("your chosen model")
    .AsIEmbeddingGenerator();

var vectorStore = new QdrantVectorStore(
    new QdrantClient("localhost"),
    ownsClient: true,
    new QdrantVectorStoreOptions
    {
         EmbeddingGenerator = embeddingGenerator
    });
// </OnTheVectorStore>

// <OnACollection>
using Microsoft.Extensions.AI;
using Microsoft.SemanticKernel.Connectors.Qdrant;
using OpenAI;
using Qdrant.Client;

var embeddingGenerator = new OpenAIClient("your key")
    .GetEmbeddingClient("your chosen model")
    .AsIEmbeddingGenerator();

var collectionOptions = new QdrantCollectionOptions
{
    EmbeddingGenerator = embeddingGenerator
};
var collection = new QdrantCollection<ulong, MyRecord>(
    new QdrantClient("localhost"),
    "myCollection",
    ownsClient: true,
    collectionOptions);
// </OnACollection>

// <OnARecordDefinition>
using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;
using Microsoft.SemanticKernel.Connectors.Qdrant;
using OpenAI;
using Qdrant.Client;

var embeddingGenerator = new OpenAIClient("your key")
    .GetEmbeddingClient("your chosen model")
    .AsIEmbeddingGenerator();

var definition = new VectorStoreCollectionDefinition
{
    EmbeddingGenerator = embeddingGenerator,
    Properties = new List<VectorStoreProperty>
    {
        new VectorStoreKeyProperty("Key", typeof(ulong)),
        new VectorStoreVectorProperty("DescriptionEmbedding", typeof(string), dimensions: 1536)
    }
};

var collectionOptions = new QdrantCollectionOptions
{
    Definition = definition
};
var collection = new QdrantCollection<ulong, MyRecord>(
    new QdrantClient("localhost"),
    "myCollection",
    ownsClient: true,
    collectionOptions);
// </OnARecordDefinition>

// <OnAVectorPropertyDefinition>
using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;
using OpenAI;

var embeddingGenerator = new OpenAIClient("your key")
    .GetEmbeddingClient("your chosen model")
    .AsIEmbeddingGenerator();

var vectorProperty = new VectorStoreVectorProperty("DescriptionEmbedding", typeof(string), dimensions: 1536)
{
     EmbeddingGenerator = embeddingGenerator
};
// </OnAVectorPropertyDefinition>

// <ExampleUsage>

// The data model
internal class FinanceInfo
{
    [VectorStoreKey]
    public string Key { get; set; } = string.Empty;

    [VectorStoreData]
    public string Text { get; set; } = string.Empty;

    // Note that the vector property is typed as a string, and
    // its value is derived from the Text property. The string
    // value will however be converted to a vector on upsert and
    // stored in the database as a vector.
    [VectorStoreVector(1536)]
    public string Embedding => this.Text;
}

// Create an OpenAI embedding generator.
var embeddingGenerator = new OpenAIClient("your key")
    .GetEmbeddingClient("your chosen model")
    .AsIEmbeddingGenerator();

// Use the embedding generator with the vector store.
var vectorStore = new InMemoryVectorStore(new() { EmbeddingGenerator = embeddingGenerator });
var collection = vectorStore.GetCollection<string, FinanceInfo>("finances");
await collection.EnsureCollectionExistsAsync();

// Create some test data.
string[] budgetInfo =
{
    "The budget for 2020 is EUR 100 000",
    "The budget for 2021 is EUR 120 000",
    "The budget for 2022 is EUR 150 000",
    "The budget for 2023 is EUR 200 000",
    "The budget for 2024 is EUR 364 000"
};

// Embeddings are generated automatically on upsert.
var records = budgetInfo.Select((input, index) => new FinanceInfo { Key = index.ToString(), Text = input });
await collection.UpsertAsync(records);

// Embeddings for the search is automatically generated on search.
var searchResult = collection.SearchAsync(
    "What is my budget for 2024?",
    top: 1);

// Output the matching result.
await foreach (var result in searchResult)
{
    Console.WriteLine($"Key: {result.Record.Key}, Text: {result.Record.Text}");
}
// </ExampleUsage>

// <GenerateEmbeddingsOnUpsertWithIEmbedding>
public async Task GenerateEmbeddingsAndUpsertAsync(
    IEmbeddingGenerator<string, Embedding<float>> embeddingGenerator,
    VectorStoreCollection<ulong, Hotel> collection)
{
    // Upsert a record.
    string descriptionText = "A place where everyone can be happy.";
    ulong hotelId = 1;

    // Generate the embedding.
    ReadOnlyMemory<float> embedding =
        (await embeddingGenerator.GenerateEmbeddingAsync(descriptionText)).Vector;

    // Create a record and upsert with the already generated embedding.
    await collection.UpsertAsync(new Hotel
    {
        HotelId = hotelId,
        HotelName = "Hotel Happy",
        Description = descriptionText,
        DescriptionEmbedding = embedding,
        Tags = new[] { "luxury", "pool" }
    });
}
// </GenerateEmbeddingsOnUpsertWithIEmbedding>

// <GenerateEmbeddingsOnSearchWithIEmbedding>
public async Task GenerateEmbeddingsAndSearchAsync(
    IEmbeddingGenerator<string, Embedding<float>> embeddingGenerator,
    VectorStoreCollection<ulong, Hotel> collection)
{
    // Upsert a record.
    string descriptionText = "Find me a hotel with happiness in mind.";

    // Generate the embedding.
    ReadOnlyMemory<float> searchEmbedding =
        (await embeddingGenerator.GenerateEmbeddingAsync(descriptionText)).Vector;

    // Search using the already generated embedding.
    IAsyncEnumerable<VectorSearchResult<Hotel>> searchResult = collection.SearchAsync(searchEmbedding, top: 1);
    List<VectorSearchResult<Hotel>> resultItems = await searchResult.ToListAsync();

    // Print the first search result.
    Console.WriteLine("Score for first result: " + resultItems.FirstOrDefault()?.Score);
    Console.WriteLine("Hotel description for first result: " + resultItems.FirstOrDefault()?.Record.Description);
}
// </GenerateEmbeddingsOnSearchWithIEmbedding>

// <EmbeddingDimensions1>
[VectorStoreVector(Dimensions: 1536)]
public ReadOnlyMemory<float>? DescriptionEmbedding { get; set; }
// </EmbeddingDimensions1>

// <EmbeddingDimensions2>
new VectorStoreVectorProperty("DescriptionEmbedding", typeof(float), dimensions: 1536);
// </EmbeddingDimensions2>