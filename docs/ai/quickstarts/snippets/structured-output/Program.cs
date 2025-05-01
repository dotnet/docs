using Azure.AI.OpenAI;
using Azure.Identity;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;

// <SnippetGetChatClient>
IConfigurationRoot config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

string endpoint = config["AZURE_OPENAI_ENDPOINT"];
string model = config["AZURE_OPENAI_GPT_NAME"];
string tenantId = config["AZURE_TENANT_ID"];

// Get a chat client for the Azure OpenAI endpoint.
AzureOpenAIClient azureClient =
    new(
        new Uri(endpoint),
        new DefaultAzureCredential(new DefaultAzureCredentialOptions() { TenantId = tenantId }));
IChatClient chatClient = azureClient
    .GetChatClient(deploymentName: model)
    .AsIChatClient();
// </SnippetGetChatClient>

// <SnippetSimpleRequest>
string review = "I'm happy with the product!";
var response = await chatClient.GetResponseAsync<Sentiment>($"What's the sentiment of this review? {review}");
Console.WriteLine($"Sentiment: {response.Result}");
// </SnippetSimpleRequest>

// <SnippetMultipleReviews>
string[] inputs = [
    "Best purchase ever!",
    "Returned it immediately.",
    "Hello",
    "It works as advertised.",
    "The packaging was damaged but otherwise okay."
];

foreach (var i in inputs)
{
    var response2 = await chatClient.GetResponseAsync<Sentiment>($"What's the sentiment of this review? {i}");
    Console.WriteLine($"Review: {i} | Sentiment: {response2.Result}");
}
// </SnippetMultipleReviews>

// <SnippetRecordRequest>
var review3 = "This product worked okay.";
var response3 = await chatClient.GetResponseAsync<SentimentRecord>($"What's the sentiment of this review? {review3}");

Console.WriteLine($"Response text: {response3.Result.ResponseText}" +
    $" | Sentiment: {response3.Result.ReviewSentiment}");
// </SnippetRecordRequest>

// <SnippetInputOutputRecord>
record SentimentRecord(string ResponseText, Sentiment ReviewSentiment);
// </SnippetInputOutputRecord>

// <SnippetSentimentEnum>
public enum Sentiment
{
    Positive,
    Negative,
    Neutral
}
// </SnippetSentimentEnum>
