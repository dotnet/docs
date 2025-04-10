using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.AI;
using Azure.AI.OpenAI;
using Azure.Identity;

var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
string endpoint = config["AZURE_OPENAI_ENDPOINT"];
string deployment = config["AZURE_OPENAI_GPT_NAME"];

IChatClient client =
    new AzureOpenAIClient(new Uri(endpoint), new DefaultAzureCredential())
        .GetChatClient(deployment)
        .AsIChatClient();

// Create and print out the prompt
string prompt = $"""
    summarize the the following text in 20 words or less:
    {File.ReadAllText("benefits.md")}
    """;

Console.WriteLine($"user >>> {prompt}");

// Submit the prompt and print out the response
ChatResponse response = await client.GetResponseAsync(prompt, new ChatOptions { MaxOutputTokens = 400 });
Console.WriteLine($"assistant >>> {response}");
