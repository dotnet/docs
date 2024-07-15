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

using (StreamReader streamReader = new StreamReader(response.ContentStream))
{
    // Display the results
    Console.WriteLine(streamReader.ReadToEnd());
}