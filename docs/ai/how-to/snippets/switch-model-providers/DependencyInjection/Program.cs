using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Azure.AI.OpenAI;
using Azure.Identity;
using OllamaSharp;

// Create host builder
var builder = Host.CreateApplicationBuilder();

// Register multiple chat clients with different keys
builder.Services.AddKeyedSingleton<IChatClient>("local", (sp, key) =>
    new OllamaApiClient(new Uri("http://localhost:11434"), "llama3.1"));

builder.Services.AddKeyedSingleton<IChatClient>("cloud", (sp, key) =>
    new AzureOpenAIClient(
        new Uri("YOUR-AZURE-OPENAI-ENDPOINT"),
        new DefaultAzureCredential())
        .GetChatClient("gpt-35-turbo")
        .AsIChatClient());

builder.Services.AddKeyedSingleton<IChatClient>("premium", (sp, key) =>
    new AzureOpenAIClient(
        new Uri("YOUR-AZURE-OPENAI-ENDPOINT"),
        new DefaultAzureCredential())
        .GetChatClient("gpt-4")
        .AsIChatClient());

// Register a provider selector service
builder.Services.AddScoped<IChatProviderSelector, ChatProviderSelector>();

// Register a service that uses the chat providers
builder.Services.AddScoped<AIService>();

var host = builder.Build();

// Get and use the AI service
var aiService = host.Services.GetRequiredService<AIService>();

await aiService.ProcessQueriesAsync([
    "Hello, how are you?",
    "Explain the theory of relativity in detail with mathematical formulations",
    "What's the weather like today?"
]);

// Interface for provider selection
public interface IChatProviderSelector
{
    IChatClient SelectProvider(string query);
}

// Implementation of provider selector
public class ChatProviderSelector : IChatProviderSelector
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<ChatProviderSelector> _logger;

    public ChatProviderSelector(IServiceProvider serviceProvider, ILogger<ChatProviderSelector> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public IChatClient SelectProvider(string query)
    {
        // Simple logic for demonstration
        // In practice, this could be much more sophisticated
        string selectedProvider = query.Length switch
        {
            < 50 => "local",
            < 200 => "cloud", 
            _ => "premium"
        };

        _logger.LogInformation("Selected provider '{Provider}' for query of length {Length}", 
            selectedProvider, query.Length);

        return _serviceProvider.GetRequiredKeyedService<IChatClient>(selectedProvider);
    }
}

// Service that uses AI providers
public class AIService
{
    private readonly IChatProviderSelector _providerSelector;
    private readonly ILogger<AIService> _logger;

    public AIService(IChatProviderSelector providerSelector, ILogger<AIService> logger)
    {
        _providerSelector = providerSelector;
        _logger = logger;
    }

    public async Task ProcessQueriesAsync(string[] queries)
    {
        foreach (var query in queries)
        {
            _logger.LogInformation("Processing query: {Query}", query[..Math.Min(query.Length, 50)]);
            
            try
            {
                var client = _providerSelector.SelectProvider(query);
                var response = await client.GetResponseAsync(query);
                
                _logger.LogInformation("Response received: {Response}", 
                    response.ToString()[..Math.Min(response.ToString().Length, 100)]);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing query: {Query}", query);
            }
        }
    }
}