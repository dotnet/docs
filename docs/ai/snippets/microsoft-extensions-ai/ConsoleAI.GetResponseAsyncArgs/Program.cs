using Microsoft.Extensions.AI;
using OllamaSharp;

IChatClient client = new OllamaApiClient(
    new Uri("http://localhost:11434/"), "phi3:mini");

// <Snippet1>
Console.WriteLine(await client.GetResponseAsync(
[
    new(ChatRole.System, "You are a helpful AI assistant"),
    new(ChatRole.User, "What is AI?"),
]));
// </Snippet1>
