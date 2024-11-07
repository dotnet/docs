using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;

// Retrieve the local secrets that were set from the command line
var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
string model = "gpt-3.5-turbo";
string key = config["OpenAIKey"];

// Create a Kernel containing the OpenAI Chat Completion Service
Kernel kernel = Kernel.CreateBuilder()
    .AddOpenAIChatCompletion(model, key)
    .Build();

// Create and print out the prompt
string prompt = $"""
    Please summarize the the following text in 20 words or less:
    {File.ReadAllText("benefits.md")}
    """;
Console.WriteLine($"user >>> {prompt}");

// Submit the prompt and print out the response
string response = await kernel.InvokePromptAsync<string>(prompt, new(new OpenAIPromptExecutionSettings() { MaxTokens = 400 }));
Console.WriteLine($"assistant >>> {response}");