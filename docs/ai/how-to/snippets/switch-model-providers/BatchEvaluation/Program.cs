using Microsoft.Extensions.AI;
using Azure.AI.OpenAI;
using Azure.Identity;
using OllamaSharp;
using System.Diagnostics;

// Define providers for evaluation
var providers = new Dictionary<string, IChatClient>
{
    ["Ollama-Llama3.1"] = new OllamaApiClient(new Uri("http://localhost:11434"), "llama3.1"),
    ["Azure-GPT4"] = new AzureOpenAIClient(
        new Uri("YOUR-AZURE-OPENAI-ENDPOINT"), 
        new DefaultAzureCredential())
        .GetChatClient("gpt-4")
        .AsIChatClient(),
    ["Azure-GPT35"] = new AzureOpenAIClient(
        new Uri("YOUR-AZURE-OPENAI-ENDPOINT"), 
        new DefaultAzureCredential())
        .GetChatClient("gpt-35-turbo")
        .AsIChatClient()
};

// Test prompts for evaluation
string[] testPrompts = [
    "Explain quantum computing in simple terms.",
    "Write a haiku about artificial intelligence.",
    "What are the pros and cons of renewable energy?",
    "How does machine learning work?",
    "Describe the water cycle."
];

// Evaluation results
var results = new List<EvaluationResult>();

Console.WriteLine("Starting batch evaluation across providers...\n");

foreach (var prompt in testPrompts)
{
    Console.WriteLine($"Evaluating prompt: \"{prompt}\"");
    Console.WriteLine(new string('-', 50));
    
    foreach (var (providerName, client) in providers)
    {
        try
        {
            var stopwatch = Stopwatch.StartNew();
            var response = await client.GetResponseAsync(prompt);
            stopwatch.Stop();
            
            var result = new EvaluationResult
            {
                Prompt = prompt,
                Provider = providerName,
                Response = response.ToString(),
                ResponseTime = stopwatch.Elapsed,
                InputTokens = (int)(response.Usage?.InputTokenCount ?? 0),
                OutputTokens = (int)(response.Usage?.OutputTokenCount ?? 0),
                Success = true
            };
            
            results.Add(result);
            
            Console.WriteLine($"{providerName}:");
            Console.WriteLine($"  Response time: {stopwatch.ElapsedMilliseconds}ms");
            Console.WriteLine($"  Tokens: {result.InputTokens} in, {result.OutputTokens} out");
            Console.WriteLine($"  Response: {response.ToString()[..Math.Min(response.ToString().Length, 100)]}...");
        }
        catch (Exception ex)
        {
            var result = new EvaluationResult
            {
                Prompt = prompt,
                Provider = providerName,
                Response = "",
                ResponseTime = TimeSpan.Zero,
                InputTokens = 0,
                OutputTokens = 0,
                Success = false,
                ErrorMessage = ex.Message
            };
            
            results.Add(result);
            
            Console.WriteLine($"{providerName}: ERROR - {ex.Message}");
        }
    }
    
    Console.WriteLine();
}

// Generate summary report
Console.WriteLine("EVALUATION SUMMARY");
Console.WriteLine(new string('=', 50));

var groupedResults = results.GroupBy(r => r.Provider);

foreach (var group in groupedResults)
{
    var successfulResults = group.Where(r => r.Success).ToList();
    
    Console.WriteLine($"\n{group.Key}:");
    Console.WriteLine($"  Success rate: {successfulResults.Count}/{group.Count()} ({(double)successfulResults.Count / group.Count() * 100:F1}%)");
    
    if (successfulResults.Any())
    {
        Console.WriteLine($"  Avg response time: {successfulResults.Average(r => r.ResponseTime.TotalMilliseconds):F0}ms");
        Console.WriteLine($"  Avg output tokens: {successfulResults.Average(r => r.OutputTokens):F0}");
    }
}

// Data model for evaluation results
public class EvaluationResult
{
    public string Prompt { get; set; } = "";
    public string Provider { get; set; } = "";
    public string Response { get; set; } = "";
    public TimeSpan ResponseTime { get; set; }
    public int InputTokens { get; set; }
    public int OutputTokens { get; set; }
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }
}