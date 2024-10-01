using Azure;
using Azure.AI.ContentSafety;
using Azure.Core;
using Azure.Core.Serialization;
using Azure.Identity;

// Create the client
ContentSafetyClient client = new(
    new Uri("https://contentsafetyai.cognitiveservices.azure.com/"),
    new DefaultAzureCredential());

// Create the prompt
RequestContent prompt = RequestContent.Create(new
{
    text = "What is Microsoft Azure?",
});

// Call the protocol method
Response response = client.AnalyzeText(
    prompt,
    new RequestContext
    {
        ErrorOptions = ErrorOptions.NoThrow,
    });

// Any non-200 response code from Azure AI Content Safety AnalyzeText REST API isn't considered a success response.
// See REST API details at https://azure-ai-content-safety-api-docs.developer.azure-api.net/api-details#api=content-safety-service-2023-10-01&operation=TextOperations_AnalyzeText
if (response.Status != 200)
{
    throw new RequestFailedException(response);
}

// With this dynamic instance, you can use response content like a convenience model. As convenience APIs are added
// to the library, this approach helps you evolve code from protocol to convenience with minimal code changes.
dynamic content = response.Content.ToDynamicFromJson(JsonPropertyNames.CamelCase);

// Display the results
foreach (var item in content.CategoriesAnalysis)
{
    Console.WriteLine($"{item.Category}: {item.Severity}");
}
