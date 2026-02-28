using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;
using Microsoft.SemanticKernel.Connectors.InMemory;

// <AutoEmbeddingDataModel>
// When the vector property type is string (not ReadOnlyMemory<float>),
// the vector store automatically generates embeddings using the configured IEmbeddingGenerator.
public class FinanceInfo
{
    [VectorStoreKey]
    public int Key { get; set; }

    [VectorStoreData]
    public string Text { get; set; } = "";

    // The string value placed here before upsert is automatically converted to a vector.
    [VectorStoreVector(1536)]
    public string EmbeddingSource { get; set; } = "";
}
// </AutoEmbeddingDataModel>

public static class AutoEmbeddingExample
{
    public static async Task RunAsync(IEmbeddingGenerator<string, Embedding<float>> embeddingGenerator)
    {
        // <AutoEmbeddingVectorStore>
        // Configure the embedding generator at the vector store level.
        // All collections in this store will use it unless overridden.
        var vectorStore = new InMemoryVectorStore(new InMemoryVectorStoreOptions
        {
            EmbeddingGenerator = embeddingGenerator
        });

        var collection = vectorStore.GetCollection<int, FinanceInfo>("finance");
        await collection.EnsureCollectionExistsAsync();

        // Embeddings are generated automatically on upsert.
        var records = new[]
        {
            new FinanceInfo { Key = 1, Text = "2024 Budget", EmbeddingSource = "The budget for 2024 is $100,000" },
            new FinanceInfo { Key = 2, Text = "2023 Budget", EmbeddingSource = "The budget for 2023 is $80,000" }
        };

        await collection.UpsertAsync(records[0]);
        await collection.UpsertAsync(records[1]);

        // Embeddings for search are also generated automatically.
        var results = collection.SearchAsync("What is my 2024 budget?", top: 1);

        await foreach (var result in results)
        {
            Console.WriteLine($"Found: Key={result.Record.Key}, Text={result.Record.Text}");
        }
        // </AutoEmbeddingVectorStore>
    }
}
