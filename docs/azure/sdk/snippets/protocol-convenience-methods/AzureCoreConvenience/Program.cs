using Azure.AI.ContentSafety;
using Azure.Identity;

// Create the client
var safetyClient = new ContentSafetyClient(
    new Uri("https://contentsafetyai.cognitiveservices.azure.com/"),
    new DefaultAzureCredential());

// Call the convenience method
AnalyzeTextResult result = safetyClient.AnalyzeText("What is Microsoft Azure?");

// Display the results
foreach (var item in result.CategoriesAnalysis)
{
    Console.Write($"{item.Category}: ");
    Console.Write(item.Severity);
    Console.WriteLine();
}