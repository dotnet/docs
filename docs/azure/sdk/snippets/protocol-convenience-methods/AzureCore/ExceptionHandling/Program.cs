using Azure.AI.ContentSafety;
using Azure.Identity;
using Azure;

// Create the client
ContentSafetyClient client = new(
    new Uri("https://contentsafetyai.cognitiveservices.azure.com/"),
    new DefaultAzureCredential());

try
{
    // Call the convenience method
    AnalyzeTextResult result = client.AnalyzeText("What is Microsoft Azure?");

    // Display the results
    foreach (TextCategoriesAnalysis item in result.CategoriesAnalysis)
    {
        Console.WriteLine($"{item.Category}: {item.Severity}");
    }
} 
catch (RequestFailedException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
