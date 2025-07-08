using Azure.AI.ContentSafety;
using Azure.Identity;

// Create the client
ContentSafetyClient client = new(
    new Uri("https://contentsafetyai.cognitiveservices.azure.com/"),
    new DefaultAzureCredential());

// Call the convenience method
AnalyzeTextResult result = client.AnalyzeText("What is Microsoft Azure?");

// Display the results
foreach (TextCategoriesAnalysis item in result.CategoriesAnalysis)
{
    Console.WriteLine($"{item.Category}: {item.Severity}");
}
