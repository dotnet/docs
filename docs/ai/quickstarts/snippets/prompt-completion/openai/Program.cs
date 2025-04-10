using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using OpenAI;

IConfigurationRoot config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
string? model = config["ModelName"];
string? key = config["OpenAIKey"];

// Create the IChatClient
IChatClient client =
    new OpenAIClient(key).GetChatClient(model).AsIChatClient();

// Create and print out the prompt
string prompt = $"""
    summarize the the following text in 20 words or less:
    {File.ReadAllText("benefits.md")}
    """;

Console.WriteLine($"user >>> {prompt}");

// Submit the prompt and print out the response
ChatResponse response = await client.GetResponseAsync(prompt, new ChatOptions { MaxOutputTokens = 400 });
Console.WriteLine($"assistant >>> {response}");
