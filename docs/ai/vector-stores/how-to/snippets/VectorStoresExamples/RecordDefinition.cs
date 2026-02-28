using Microsoft.Extensions.VectorData;
using Microsoft.SemanticKernel.Connectors.InMemory;

public static class RecordDefinitionExample
{
    public static async Task RunAsync()
    {
        // <RecordDefinition>
        // An alternative to using attributes is to define the schema programmatically.
        // This is useful when you want to use the same data model with different configurations,
        // or when you can't modify the data model class to add attributes.
        var hotelDefinition = new VectorStoreCollectionDefinition
        {
            Properties = new List<VectorStoreProperty>
            {
                new VectorStoreKeyProperty("HotelId", typeof(int)),
                new VectorStoreDataProperty("HotelName", typeof(string)) { IsIndexed = true },
                new VectorStoreDataProperty("Description", typeof(string)) { IsFullTextIndexed = true },
                new VectorStoreVectorProperty("DescriptionEmbedding", typeof(ReadOnlyMemory<float>?), dimensions: 1536)
                {
                    DistanceFunction = DistanceFunction.CosineSimilarity,
                    IndexKind = IndexKind.Flat
                }
            }
        };

        // Pass the definition to GetCollection to override the attribute-based schema.
        var vectorStore = new InMemoryVectorStore();
        VectorStoreCollection<int, Hotel> collection =
            vectorStore.GetCollection<int, Hotel>("hotels", hotelDefinition);

        await collection.EnsureCollectionExistsAsync();
        // </RecordDefinition>
    }
}
