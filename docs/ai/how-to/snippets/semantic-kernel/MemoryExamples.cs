using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel.Connectors.Redis;
using Microsoft.SemanticKernel.Embeddings;
using Microsoft.SemanticKernel.Memory;
using Microsoft.SemanticKernel.Plugins.Memory;
using StackExchange.Redis;

// Suppress warning about embedding generation still being in evaluation
#pragma warning disable SKEXP0010 

// Suppress warning about Redis connector still being in evaluation
#pragma warning disable SKEXP0020

// Suppress warning about MemoryStore still being in evaluation
#pragma warning disable SKEXP0001

// Supress warning about TextMemoryPlugin still being in evaluation
#pragma warning disable SKEXP0050

class MemoryExamples
{
    public static async Task Examples()
    {
        await RedisearchExample();
    }


    static async Task RedisearchExample()
    {
        // <initRedis>
        // Retrieve the Redis connection config
        IConfigurationRoot config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
        string redisConfig = config["REDIS_CONFIG"]!;

        // Initialize a connection to the Redis database
        ConnectionMultiplexer connectionMultiplexer = await ConnectionMultiplexer.ConnectAsync(redisConfig);
        IDatabase database = connectionMultiplexer.GetDatabase();
        // </initRedis>

        // <initKernel>
        // Retrieve the Azure OpenAI config and secrets saved during deployment
        string endpoint = config["AZURE_OPENAI_ENDPOINT"]!;
        string embeddingModel = config["AZURE_OPENAI_EMBEDDING_NAME"]!;
        string key = config["AZURE_OPENAI_KEY"]!;

        // Build the Kernel, must add an embedding generation service
        Kernel kernel = Kernel.CreateBuilder()
            .AddAzureOpenAITextEmbeddingGeneration(embeddingModel, endpoint, key)
            .Build();
        // </initKernel>

        // <initMemory>
        // Retrieve the desired vector size for the memory store
        // If unspecified the default vector size is 1536
        int vectorSize = int.Parse(config["REDIS_MEMORY_VECTOR_SIZE"]!);

        // Initialize a memory store using the redis database
        IMemoryStore memoryStore = new RedisMemoryStore(database, vectorSize);

        // Retrieve the embedding service from the Kernel
        ITextEmbeddingGenerationService embeddingService = kernel.Services.GetRequiredService<ITextEmbeddingGenerationService>();

        // Initialize a SemanticTextMemory using the memory store and embedding generation service
        SemanticTextMemory textMemory = new(memoryStore, embeddingService);
        // </initMemory>

        // <addMemory>
        // Initialize a TextMemoryPlugin using the text memory
        TextMemoryPlugin memoryPlugin = new(textMemory);

        // Import the text memory plugin into the Kernel
        KernelPlugin memory = kernel.ImportPluginFromObject(memoryPlugin);
        // </addMemory>

        // <useMemory>
        // Retrieve the desired memory collection name
        string memoryCollectionName = config["REDIS_MEMORY_COLLECTION_NAME"]!;

        // Save a memory with the Kernel
        await kernel.InvokeAsync(memory["Save"], new()
        {
            [TextMemoryPlugin.InputParam] = "My family is from New York",
            [TextMemoryPlugin.CollectionParam] = memoryCollectionName,
            [TextMemoryPlugin.KeyParam] = "info1",
        });

        // Retrieve a memory with the Kernel
        FunctionResult result = await kernel.InvokeAsync(memory["Retrieve"], new()
        {
            [TextMemoryPlugin.CollectionParam] = memoryCollectionName,
            [TextMemoryPlugin.KeyParam] = "info1",
        });

        // Get the memory string from the function result, will return a null value if no memory is found
        Console.WriteLine($"Retrieved memory: {result.GetValue<string>() ?? "ERROR: memory not found"}");

        // Alternatively, recall similar memories with the Kernel
        // Can configure the number of memories to recall and relevance score
        result = await kernel.InvokeAsync(memory["Recall"], new()
        {
            [TextMemoryPlugin.InputParam] = "Ask: where do I live?",
            [TextMemoryPlugin.CollectionParam] = memoryCollectionName,
            [TextMemoryPlugin.LimitParam] = "2",
            [TextMemoryPlugin.RelevanceParam] = "0.79",
        });

        // If memories are recalled the function result can be deserialized as a string[]
        string? resultStr = result.GetValue<string>();
        string[]? parsedResult = string.IsNullOrEmpty(resultStr) ? null : JsonSerializer.Deserialize<string[]>(resultStr);
        Console.WriteLine($"Recalled memories: {(parsedResult?.Length > 0 ? resultStr : "ERROR: memory not found")}");
        // </useMemory>
    }
}