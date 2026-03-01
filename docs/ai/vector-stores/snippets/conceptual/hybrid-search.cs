using Microsoft.SemanticKernel.Connectors.Qdrant;
using Microsoft.Extensions.VectorData;
using Qdrant.Client;

public class HybridSearchExample
{
    public async static void Run()
    {
        // <HybridSearch>
        // Create a Qdrant VectorStore object and choose
        // an existing collection that already contains records.
        VectorStore vectorStore = new QdrantVectorStore(new QdrantClient("localhost"), ownsClient: true);
        IKeywordHybridSearchable<Hotel> collection =
            (IKeywordHybridSearchable<Hotel>)vectorStore.GetCollection<ulong, Hotel>("skhotels");

        // Generate a vector for your search text, using
        // your chosen embedding generation implementation.
        ReadOnlyMemory<float> searchVector = await GenerateAsync("I'm looking for a hotel where customer happiness is the priority.");

        // Do the search, passing an options object with a Top value to limit results to the single top match.
        IAsyncEnumerable<VectorSearchResult<Hotel>> searchResult =
            collection.HybridSearchAsync(searchVector, ["happiness", "hotel", "customer"], top: 1);

        // Inspect the returned hotel.
        await foreach (VectorSearchResult<Hotel> record in searchResult)
        {
            Console.WriteLine($"Found hotel description: {record.Record.Description}");
            Console.WriteLine($"Found record score: {record.Score}");
        }
        // </HybridSearch>
    }

    private static async Task<ReadOnlyMemory<float>> GenerateAsync(string v) => throw new NotImplementedException();

    public class VPAndAddlPropertyExample
    {
        private object searchVector;

        // <VectorPropertyAndAdditionalProperty>
        public async Task Run()
        {
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
            IAsyncEnumerable<VectorSearchResult<Product>> searchResult =
                collection.HybridSearchAsync(searchVector, ["happiness", "hotel", "customer"], top: 3, hybridSearchOptions);
        }
    }

    public sealed class Product
    {
        [VectorStoreKey]
        public int Key { get; set; }

        [VectorStoreData(IsFullTextIndexed = true)]
        public required string Name { get; set; }

        [VectorStoreData(IsFullTextIndexed = true)]
        public required string Description { get; set; }

        [VectorStoreData]
        public required List<string> FeatureList { get; set; }

        [VectorStoreVector(1536)]
        public ReadOnlyMemory<float> DescriptionEmbedding { get; set; }

        [VectorStoreVector(1536)]
        public ReadOnlyMemory<float> FeatureListEmbedding { get; set; }
    }
    // </VectorPropertyAndAdditionalProperty>

    public class TopAndSkipExample
    {
        private object searchVector;
        private IKeywordHybridSearchable<Product> collection;

        public async Task TopAndSkipSearch()
        {
            // <TopAndSkip>
            // Create the vector search options and indicate that you want to skip the first 40 results and then pass 20 to search to get the next 20.
            HybridSearchOptions<Product> hybridSearchOptions = new()
            {
                Skip = 40
            };

            // This snippet assumes searchVector is already provided,
            // having been created using the embedding model of your choice.
            IAsyncEnumerable<VectorSearchResult<Product>> searchResult =
                collection.HybridSearchAsync(
                    searchVector,
                    ["happiness", "hotel", "customer"],
                    top: 20,
                    hybridSearchOptions);

            // Iterate over the search results.
            await foreach (VectorSearchResult<Product> result in searchResult)
            {
                Console.WriteLine(result.Record.Description);
            }
            // </TopAndSkip>

            // <IncludeVectors>
            // Create the hybrid search options and indicate that you want to include vectors in the search results.
            hybridSearchOptions = new HybridSearchOptions<Product>()
            {
                IncludeVectors = true
            };

            // This snippet assumes searchVector is already provided, having been created using the embedding model of your choice.
            searchResult = collection.HybridSearchAsync(
                searchVector,
                ["happiness", "hotel", "customer"],
                top: 3,
                hybridSearchOptions);

            // Iterate over the search results.
            await foreach (VectorSearchResult<Product> result in searchResult)
            {
                Console.WriteLine(result.Record.FeatureList);
            }
            // </IncludeVectors>
        }
    }

    public class FilterExample
    {
        private object searchVector;
        private IKeywordHybridSearchable<Glossary> collection;

        // <Filter>
        public async Task FilterSearch()
        {
            // Create the hybrid search options and set the filter on the options.
            HybridSearchOptions<Glossary> searchOptions = new()
            {
                Filter = r => r.Category == "External Definitions" && r.Tags.Contains("memory")
            };

            // This snippet assumes searchVector is already provided,
            // having been created using the embedding model of your choice.
            IAsyncEnumerable<VectorSearchResult<Glossary>> searchResult =
                collection.HybridSearchAsync(
                    searchVector,
                    ["happiness", "hotel", "customer"],
                    top: 3,
                    searchOptions);

            // Iterate over the search results.
            await foreach (VectorSearchResult<Glossary> result in searchResult)
            {
                Console.WriteLine(result.Record.Definition);
            }
        }

        sealed class Glossary
        {
            [VectorStoreKey]
            public ulong Key { get; set; }

            // Category is marked as indexed, since you want to filter using this property.
            [VectorStoreData(IsIndexed = true)]
            public required string Category { get; set; }

            // Tags is marked as indexed, since you want to filter using this property.
            [VectorStoreData(IsIndexed = true)]
            public required List<string> Tags { get; set; }
            [VectorStoreData]
            public required string Term { get; set; }

            [VectorStoreData]
            public required string Definition { get; set; }

            [VectorStoreVector(1536)]
            public ReadOnlyMemory<float> DefinitionEmbedding { get; set; }
        }
        // </Filter>
    }
}
