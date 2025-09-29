using Microsoft.Extensions.AI;
using OllamaSharp;

IChatClient client = new OllamaApiClient(
    new Uri("http://localhost:11434/"), "phi3:mini");

// <Snippet1>
await foreach (ChatResponseUpdate update in client.GetStreamingResponseAsync("What is AI?"))
{
    Console.Write(update);
}
// </Snippet1>
