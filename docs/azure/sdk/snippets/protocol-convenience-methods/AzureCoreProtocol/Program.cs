using Azure;
using Azure.AI.ContentSafety;
using Azure.Core;
using Azure.Identity;

// Create the client
var safetyClient = new ContentSafetyClient(
    new Uri("https://contentsafetyai.cognitiveservices.azure.com/"),
    new DefaultAzureCredential());

// Create the prompt
RequestContent prompt = RequestContent.Create(new
{
    text = "What is Microsoft Azure?",
});

// Call the protocol method
Response response = safetyClient.AnalyzeText(
    prompt, 
    new RequestContext() { ErrorOptions = ErrorOptions.NoThrow});

// Any response code other than 200 from Azure ContentSafety AnalyzeText REST API is not considered a success response
// See REST API details at https://azure-ai-content-safety-api-docs.developer.azure-api.net/api-details#api=content-safety-service-2023-10-01&operation=TextOperations_AnalyzeText
if (response.Status != 200) 
{
    throw new RequestFailedException(response); 
}

// Display the results
Console.WriteLine(response.Content);