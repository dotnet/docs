using Microsoft.Extensions.VectorData;
using Microsoft.SemanticKernel.Connectors.Qdrant;
using Qdrant.Client;

public class DynamicDataModel
{
    public static async Task RunAsync()
    {
        VectorStore vectorStore = new QdrantVectorStore(new QdrantClient("localhost"), ownsClient: true);

        // <Example1>
        VectorStoreCollectionDefinition definition = new()
        {
            Properties =
            [
                new VectorStoreKeyProperty("Key", typeof(string)),
                new VectorStoreDataProperty("Term", typeof(string)),
                new VectorStoreDataProperty("Definition", typeof(string)),
                new VectorStoreVectorProperty("DefinitionEmbedding", typeof(ReadOnlyMemory<float>), dimensions: 1536)
            ]
        };

        // Use GetDynamicCollection instead of the regular GetCollection method
        // to get an instance of a collection using Dictionary<string, object?>.
        VectorStoreCollection<object, Dictionary<string, object?>> dynamicDataModelCollection =
            vectorStore.GetDynamicCollection("glossary", definition);

        // Since schema information is available from the record definition,
        // it's possible to create a collection with the right vectors,
        // dimensions, indexes, and distance functions.
        await dynamicDataModelCollection.EnsureCollectionExistsAsync();

        // When retrieving a record from the collection,
        // access key, data, and vector values via the dictionary entries.
        Dictionary<string, object?>? record = await dynamicDataModelCollection.GetAsync("SK");
        Console.WriteLine(record["Definition"]);
        // </Example1>
    }
}
