using Azure;
using Azure.AI.OpenAI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DataIngestion;
using Microsoft.Extensions.DataIngestion.Chunkers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.VectorData;
using Microsoft.ML.Tokenizers;
using Microsoft.SemanticKernel.Connectors.SqliteVec;

class DataIngestionExample
{
    public static async Task Main()
    {
        // <ConfigureReader>
        // Configure document reader.
        IngestionDocumentReader reader = new MarkdownReader();
        // </ConfigureReader>

        // <ConfigureLogging>
        using ILoggerFactory loggerFactory =
            LoggerFactory.Create(builder => builder.AddSimpleConsole());
        // </ConfigureLogging>

        // <ConfigureChatClient>
        // Configure IChatClient to use Azure OpenAI.
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddUserSecrets<DataIngestionExample>()
            .Build();

        string endpoint = config["AZURE_OPENAI_ENDPOINT"];
        string apiKey = config["AZURE_OPENAI_API_KEY"];
        string model = "gpt-4o";
        string embeddingModel = "text-embedding-3-small";

        AzureOpenAIClient azureClient = new(
            new Uri(endpoint),
            new AzureKeyCredential(apiKey));

        IChatClient chatClient =
            azureClient.GetChatClient(model).AsIChatClient();
        // </ConfigureChatClient>

        // <ConfigureDocumentProcessor>
        // Configure document processor.
        EnricherOptions enricherOptions = new(chatClient)
        {
            // Enricher failures should not fail the whole ingestion pipeline,
            // as they are best-effort enhancements.
            // This logger factory can create loggers to log such failures.
            LoggerFactory = loggerFactory
        };

        IngestionDocumentProcessor imageAlternativeTextEnricher =
            new ImageAlternativeTextEnricher(enricherOptions);
        // </ConfigureDocumentProcessor>

        // <ConfigureEmbeddingGenerator>
        // Configure embedding generator.
        IEmbeddingGenerator<string, Embedding<float>> embeddingGenerator =
            azureClient.GetEmbeddingClient(embeddingModel).AsIEmbeddingGenerator();
        // </ConfigureEmbeddingGenerator>

        // <ConfigureChunker>
        // Configure chunker to split text into semantic chunks.
        IngestionChunkerOptions chunkerOptions = new(TiktokenTokenizer.CreateForModel(model))
        {
            MaxTokensPerChunk = 2000,
            OverlapTokens = 0
        };

        IngestionChunker<string> chunker =
            new SemanticSimilarityChunker(embeddingGenerator, chunkerOptions);
        // </ConfigureChunker>

        // <ConfigureChunkProcessor>
        // Configure chunk processor to generate summaries for each chunk.
        IngestionChunkProcessor<string> summaryEnricher = new SummaryEnricher(enricherOptions);
        // </ConfigureChunkProcessor>

        // <ConfigureVectorStore>
        // Configure SQLite Vector Store.
        using SqliteVectorStore vectorStore = new(
            "Data Source=vectors.db;Pooling=false",
            new()
            {
                EmbeddingGenerator = embeddingGenerator
            });

        // The writer requires the embedding dimension count to be specified.
        using VectorStoreWriter<string> writer = new(
            vectorStore,
            dimensionCount: 1024,
            new VectorStoreWriterOptions { CollectionName = "data" });
        // </ConfigureVectorStore>

        // <ComposePipeline>
        // Compose data ingestion pipeline
        using IngestionPipeline<string> pipeline =
            new(reader, chunker, writer, loggerFactory: loggerFactory)
        {
            DocumentProcessors = { imageAlternativeTextEnricher },
            ChunkProcessors = { summaryEnricher }
        };
        // </ComposePipeline>

        // <ProcessDocuments>
        await foreach (IngestionResult result in pipeline.ProcessAsync(
            new DirectoryInfo("./data"),
            searchPattern: "*.md"))
        {
            Console.WriteLine($"Completed processing '{result.DocumentId}'. " +
                $"Succeeded: '{result.Succeeded}'.");
        }
        // </ProcessDocuments>

        // <SearchVectorStore>
        // Search the vector store collection and display results
        VectorStoreCollection<object, Dictionary<string, object?>> collection =
            writer.VectorStoreCollection;

        while (true)
        {
            Console.Write("Enter your question (or 'exit' to quit): ");
            string? searchValue = Console.ReadLine();
            if (string.IsNullOrEmpty(searchValue) || searchValue == "exit")
            {
                break;
            }

            Console.WriteLine("Searching...\n");
            await foreach (VectorSearchResult<Dictionary<string, object?>> result in
                collection.SearchAsync(searchValue, top: 3))
            {
                Console.WriteLine($"Score: {result.Score}\n\tContent: {result.Record["content"]}");
            }
        }
        // </SearchVectorStore>
    }
}
