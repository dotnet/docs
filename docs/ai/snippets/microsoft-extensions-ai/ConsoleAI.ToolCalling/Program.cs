using Microsoft.Extensions.AI;

string GetCurrentWeather() => Random.Shared.NextDouble() > 0.5 ? "It's sunny" : "It's raining";

IChatClient client = new OllamaChatClient(new Uri("http://localhost:11434"), "llama3.1")
    .AsBuilder()
    .UseFunctionInvocation()
    .Build();

ChatOptions options = new() { Tools = [AIFunctionFactory.Create(GetCurrentWeather)] };

var response = client.GetStreamingResponseAsync("Should I wear a rain coat?", options);
await foreach (var update in response)
{
    Console.Write(update);
}
