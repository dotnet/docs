// <chatCompletionFlow>
using Azure;
using Azure.AI.OpenAI;

string endpoint = "YOUR_OPENAI_ENDPOINT";
string key = "YOUR_OPENAI_KEY";

OpenAIClient client = new(new Uri(endpoint), new AzureKeyCredential(key));

var chatCompletionsOptions = new ChatCompletionsOptions()
{
    DeploymentName = "YOUR_DEPLOYMENT_NAME",
    Messages =
    {
        new ChatRequestSystemMessage("You are a helpful assistant."),
        new ChatRequestUserMessage("YOUR_PROMPT")
    }
};

Response<ChatCompletions> response = client.GetChatCompletions(chatCompletionsOptions);
Console.WriteLine(response.Value.Choices[0].Message.Content);
Console.WriteLine();
// </chatCompletionFlow>

// <printContentFilteringResult>
foreach (var promptFilterResult in response.Value.PromptFilterResults)
{
    var results = promptFilterResult.ContentFilterResults;
    Console.WriteLine(@$"Hate category is filtered: 
        {results.Hate.Filtered} with {results.Hate.Severity} severity.");
    Console.WriteLine(@$"Self-harm category is filtered: 
        {results.SelfHarm.Filtered} with {results.SelfHarm.Severity} severity.");
    Console.WriteLine(@$"Sexual category is filtered: 
        {results.Sexual.Filtered} with {results.Sexual.Severity} severity.");
    Console.WriteLine(@$"Violence category is filtered: 
        {results.Violence.Filtered} with {results.Violence.Severity} severity.");
}
// </printContentFilteringResult>