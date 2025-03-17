using System.ComponentModel;
using Microsoft.Extensions.AI;

[Description("Gets the current weather")]
string GetCurrentWeather() => Random.Shared.NextDouble() > 0.5
    ? "It's sunny"
    : "It's raining";

IChatClient client = new ChatClientBuilder(
        new OllamaChatClient(new Uri("http://localhost:11434"), "llama3.1"))
    .UseFunctionInvocation()
    .Build();

IAsyncEnumerable<ChatResponseUpdate> response = client.GetStreamingResponseAsync(
    "Should I wear a rain coat?",
    new() { Tools = [AIFunctionFactory.Create(GetCurrentWeather)] });

await foreach (ChatResponseUpdate update in response)
{
    Console.Write(update);
}
