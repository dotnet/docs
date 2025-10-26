using Microsoft.Extensions.AI;
using Azure.AI.OpenAI;
using Azure.Identity;
using OllamaSharp;

// Create different clients for different complexity levels
var simpleClient = new OllamaApiClient(new Uri("http://localhost:11434"), "llama3.1");
var complexClient = new AzureOpenAIClient(
    new Uri("YOUR-AZURE-OPENAI-ENDPOINT"), 
    new DefaultAzureCredential())
    .GetChatClient("gpt-4")
    .AsIChatClient();

// Smart routing function
IChatClient ChooseProvider(string query)
{
    // Simple heuristics for demonstration
    // In practice, you might use more sophisticated analysis
    int complexityScore = CalculateComplexity(query);
    
    return complexityScore > 50 ? complexClient : simpleClient;
}

int CalculateComplexity(string query)
{
    int score = 0;
    
    // Add points for various complexity indicators
    score += query.Length > 100 ? 20 : 0;
    score += query.Split(' ').Length > 20 ? 15 : 0;
    
    // Complex keywords
    string[] complexKeywords = { "analyze", "compare", "synthesize", "reasoning", "step-by-step" };
    score += complexKeywords.Count(keyword => 
        query.Contains(keyword, StringComparison.OrdinalIgnoreCase)) * 15;
    
    // Technical terms
    string[] technicalTerms = { "algorithm", "database", "architecture", "implementation" };
    score += technicalTerms.Count(term => 
        query.Contains(term, StringComparison.OrdinalIgnoreCase)) * 10;
    
    return Math.Min(score, 100);
}

// Test queries with different complexity levels
string[] testQueries = [
    "What is AI?",
    "Analyze the architectural implications of implementing a distributed microservices system with event sourcing, considering the trade-offs between consistency, availability, and partition tolerance in the context of the CAP theorem.",
    "Compare machine learning algorithms for natural language processing tasks and provide a step-by-step reasoning for choosing the best approach for sentiment analysis in social media data."
];

foreach (var query in testQueries)
{
    var client = ChooseProvider(query);
    var complexity = CalculateComplexity(query);
    
    Console.WriteLine($"Query: {query[..Math.Min(query.Length, 50)]}...");
    Console.WriteLine($"Complexity Score: {complexity}");
    Console.WriteLine($"Using: {(client == simpleClient ? "Local Model" : "Cloud Model")}");
    
    var response = await client.GetResponseAsync(query);
    Console.WriteLine($"Response: {response.ToString()[..Math.Min(response.ToString().Length, 100)]}...");
    Console.WriteLine();
}