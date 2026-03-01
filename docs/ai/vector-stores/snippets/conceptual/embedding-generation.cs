using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;
using Microsoft.SemanticKernel.Connectors.InMemory;
using Microsoft.SemanticKernel.Connectors.Qdrant;
using OpenAI;
using Qdrant.Client;

public class EmbeddingExamples
{
    // <LetTheVectorStoreGenerateEmbeddings>
    [VectorStoreVector(1536)]
    public required string Embedding { get; set; }
    // </LetTheVectorStoreGenerateEmbeddings>

    public static void ConfigureEmbeddingGeneration()
    {
        IEmbeddingGenerator embeddingGenerator = new OpenAIClient("your key")
            .GetEmbeddingClient("your chosen model")
            .AsIEmbeddingGenerator();

        // <OnTheVectorStore>
        VectorStore vectorStore = new QdrantVectorStore(
            new QdrantClient("localhost"),
            ownsClient: true,
            new QdrantVectorStoreOptions
            {
                EmbeddingGenerator = embeddingGenerator
            });
        // </OnTheVectorStore>

        // <OnACollection>
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
        var definition = new VectorStoreCollectionDefinition
        {
            EmbeddingGenerator = embeddingGenerator,
            Properties =
            [
                new VectorStoreKeyProperty("Key", typeof(ulong)),
                new VectorStoreVectorProperty("DescriptionEmbedding", typeof(string), dimensions: 1536)
            ]
        };

        collectionOptions = new QdrantCollectionOptions
        {
            Definition = definition
        };

        collection = new QdrantCollection<ulong, MyRecord>(
            new QdrantClient("localhost"),
            "myCollection",
            ownsClient: true,
            collectionOptions);
        // </OnARecordDefinition>

        // <OnAVectorPropertyDefinition>
        VectorStoreVectorProperty vectorProperty = new(
            "DescriptionEmbedding",
            typeof(string),
            dimensions: 1536)
        {
            EmbeddingGenerator = embeddingGenerator
        };
        // </OnAVectorPropertyDefinition>
    }

    private class MyRecord { }
}

public class ExampleUsage
{
    // <ExampleUsage>

    // The data model.
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
        public string Embedding => Text;
    }

    public static async Task RunAsync()
    {
        // Create an OpenAI embedding generator.
        var embeddingGenerator = new OpenAIClient("your key")
            .GetEmbeddingClient("your chosen model")
            .AsIEmbeddingGenerator();

        // Use the embedding generator with the vector store.
        VectorStore vectorStore = new InMemoryVectorStore(new()
            { EmbeddingGenerator = embeddingGenerator }
            );
        InMemoryCollection<string, FinanceInfo> collection =
            (InMemoryCollection<string, FinanceInfo>)vectorStore.GetCollection<string, FinanceInfo>("finances");
        await collection.EnsureCollectionExistsAsync();

        // Create some test data.
        string[] budgetInfo =
        [
            "The budget for 2020 is EUR 100 000",
            "The budget for 2021 is EUR 120 000",
            "The budget for 2022 is EUR 150 000",
            "The budget for 2023 is EUR 200 000",
            "The budget for 2024 is EUR 364 000"
        ];

        // Embeddings are generated automatically on upsert.
        IEnumerable<FinanceInfo> records = budgetInfo.Select(
            (input, index) => new FinanceInfo { Key = index.ToString(), Text = input }
            );
        await collection.UpsertAsync(records);

        // Embeddings for the search is automatically generated on search.
        IAsyncEnumerable<VectorSearchResult<FinanceInfo>> searchResult =
            collection.SearchAsync("What is my budget for 2024?", top: 1);

        // Output the matching result.
        await foreach (VectorSearchResult<FinanceInfo> result in searchResult)
        {
            Console.WriteLine($"Key: {result.Record.Key}, Text: {result.Record.Text}");
        }
    }
    // </ExampleUsage

    // <GenerateEmbeddingsOnUpsertWithIEmbedding>
    async Task GenerateEmbeddingsAndUpsertAsync(
        IEmbeddingGenerator<string, Embedding<float>> embeddingGenerator,
        VectorStoreCollection<ulong, Hotel> collection)
    {
        // Upsert a record.
        string descriptionText = "A place where everyone can be happy.";
        ulong hotelId = 1;

        // Generate the embedding.
        ReadOnlyMemory<float> embedding =
            (await embeddingGenerator.GenerateAsync(descriptionText)).Vector;

        // Create a record and upsert with the already generated embedding.
        await collection.UpsertAsync(new Hotel
        {
            HotelId = hotelId,
            HotelName = "Hotel Happy",
            Description = descriptionText,
            DescriptionEmbedding = embedding,
            Tags = ["luxury", "pool"]
        });
    }
    // </GenerateEmbeddingsOnUpsertWithIEmbedding>

    // <GenerateEmbeddingsOnSearchWithIEmbedding>
    async Task GenerateEmbeddingsAndSearchAsync(
        IEmbeddingGenerator<string, Embedding<float>> embeddingGenerator,
        VectorStoreCollection<ulong, Hotel> collection)
    {
        // Upsert a record.
        string descriptionText = "Find me a hotel with happiness in mind.";

        // Generate the embedding.
        ReadOnlyMemory<float> searchEmbedding =
            (await embeddingGenerator.GenerateAsync(descriptionText)).Vector;

        // Search using the already generated embedding.
        IAsyncEnumerable<VectorSearchResult<Hotel>> searchResult = collection.SearchAsync(searchEmbedding, top: 1);
        List<VectorSearchResult<Hotel>> resultItems = await searchResult.ToListAsync();

        // Print the first search result.
        Console.WriteLine("Score for first result: " + resultItems.FirstOrDefault()?.Score);
        Console.WriteLine("Hotel description for first result: " + resultItems.FirstOrDefault()?.Record.Description);
    }
    // </GenerateEmbeddingsOnSearchWithIEmbedding>
}
