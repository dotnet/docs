using Microsoft.Extensions.AI;
using Azure.AI.OpenAI;
using Azure.Identity;
using OllamaSharp;

// Get the current environment
string environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Development";

// Create chat client based on environment
IChatClient chatClient = environment == "Development"
    ? new OllamaApiClient(new Uri("http://localhost:11434"), "llama3.1")
    : new AzureOpenAIClient(
        new Uri("YOUR-AZURE-OPENAI-ENDPOINT"), 
        new DefaultAzureCredential())
        .GetChatClient("gpt-4")
        .AsIChatClient();

// Send a chat request
await foreach (var message in chatClient.GetStreamingResponseAsync("What is AI?"))
{
    Console.Write($"{message.Text}");
}
Console.WriteLine();

// Create embedding generator based on environment
IEmbeddingGenerator<string, Embedding<float>> embeddingGenerator = 
    environment == "Development"
        ? new OllamaApiClient(new Uri("http://localhost:11434"), "all-minilm")
        : new AzureOpenAIClient(
            new Uri("YOUR-AZURE-OPENAI-ENDPOINT"), 
            new DefaultAzureCredential())
            .GetEmbeddingClient("text-embedding-3-small")
            .AsIEmbeddingGenerator();

// Generate embeddings
var embedding = await embeddingGenerator.GenerateAsync("What is AI?");
Console.WriteLine($"Generated embedding with {embedding.Vector.Length} dimensions");