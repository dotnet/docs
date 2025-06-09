// <SnippetCreateChatClient>
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using OpenAI;

IConfigurationRoot config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();
string? model = config["ModelName"];
string? key = config["OpenAIKey"];

IChatClient client =
    new OpenAIClient(key).GetChatClient(model).AsIChatClient();
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
