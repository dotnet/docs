using Microsoft.Extensions.AI;
using OllamaSharp;

string GetCurrentWeather() => Random.Shared.NextDouble() > 0.5 ? "It's sunny" : "It's raining";

IChatClient client = new OllamaApiClient(new Uri("http://localhost:11434"), "llama3.1");

client = ChatClientBuilderChatClientExtensions
    .AsBuilder(client)
    .UseFunctionInvocation()
    .Build();

ChatOptions options = new() { Tools = [AIFunctionFactory.Create(GetCurrentWeather)] };

var response = client.GetStreamingResponseAsync("Should I wear a rain coat?", options);
await foreach (var update in response)
{
    Console.Write(update);
}
