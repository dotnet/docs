// <SnippetCreateChatClient>
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.AI;
using Azure.AI.OpenAI;
using Azure.Identity;

var config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();
string endpoint = config["AZURE_OPENAI_ENDPOINT"];
string deployment = config["AZURE_OPENAI_GPT_NAME"];

IChatClient client =
    new AzureOpenAIClient(new Uri(endpoint), new DefaultAzureCredential())
        .GetChatClient(deployment)
        .AsIChatClient();
// </SnippetCreateChatClient>

// <SnippetCreatePrompt>
string text = File.ReadAllText("benefits.md");
string prompt = $"""
    Summarize the the following text in 20 words or less:
    {text}
    """;
// </SnippetCreatePrompt>

// <SnippetGetResponse>
// Submit the prompt and print out the response.
ChatResponse response = await client.GetResponseAsync(
    prompt,
    new ChatOptions { MaxOutputTokens = 400 });
Console.WriteLine(response);
// </SnippetGetResponse>
