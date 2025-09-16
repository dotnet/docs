using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Azure.AI.OpenAI;
using Azure.Identity;
using OllamaSharp;

// Build configuration
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

// Get AI provider configuration
var aiConfig = configuration.GetSection("AIProviders");
var defaultProvider = aiConfig["DefaultProvider"] ?? "Ollama";

// Create provider factory
IChatClient CreateChatClient(string providerName)
{
    var providerSection = aiConfig.GetSection($"Providers:{providerName}");
    var providerType = providerSection["Type"];
    
    return providerType switch
    {
        "Ollama" => new OllamaApiClient(
            new Uri(providerSection["Endpoint"] ?? "http://localhost:11434"),
            providerSection["Model"] ?? "llama3.1"),
            
        "AzureOpenAI" => new AzureOpenAIClient(
            new Uri(providerSection["Endpoint"] ?? throw new InvalidOperationException("Azure endpoint required")),
            new DefaultAzureCredential())
            .GetChatClient(providerSection["Model"] ?? "gpt-35-turbo")
            .AsIChatClient(),
            
        "OpenAI" => throw new NotImplementedException("OpenAI provider not implemented in this example"),
        
        _ => throw new NotSupportedException($"Provider type '{providerType}' is not supported")
    };
}

// Get the configured providers
var enabledProviders = aiConfig.GetSection("EnabledProviders").Get<string[]>() ?? [defaultProvider];

Console.WriteLine($"Default provider: {defaultProvider}");
Console.WriteLine($"Enabled providers: {string.Join(", ", enabledProviders)}");
Console.WriteLine();

// Test with each enabled provider
foreach (var providerName in enabledProviders)
{
    try
    {
        Console.WriteLine($"Testing provider: {providerName}");
        
        var client = CreateChatClient(providerName);
        var response = await client.GetResponseAsync("What is artificial intelligence?");
        
        Console.WriteLine($"Response from {providerName}: {response.ToString()[..Math.Min(response.ToString().Length, 100)]}...");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error with provider {providerName}: {ex.Message}");
    }
    
    Console.WriteLine();
}

// Example of switching based on configuration flags
var useAdvancedFeatures = configuration.GetValue<bool>("AIProviders:UseAdvancedFeatures");
var providerForComplexQueries = useAdvancedFeatures ? "AzureOpenAI" : defaultProvider;

Console.WriteLine($"For complex queries, using: {providerForComplexQueries}");

var complexQueryClient = CreateChatClient(providerForComplexQueries);
var complexResponse = await complexQueryClient.GetResponseAsync(
    "Analyze the impact of quantum computing on modern cryptography and suggest mitigation strategies.");

Console.WriteLine($"Complex query response: {complexResponse.ToString()[..Math.Min(complexResponse.ToString().Length, 150)]}...");