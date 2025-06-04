using Microsoft.Extensions.AI;
using OllamaSharp;

IChatClient client = new OllamaApiClient(
    new Uri("http://localhost:11434/"), "phi3:mini");

// <Snippet1>
List<ChatMessage> history = [];
while (true)
{
    Console.Write("Q: ");
    history.Add(new(ChatRole.User, Console.ReadLine()));

    ChatResponse response = await client.GetResponseAsync(history);
    Console.WriteLine(response);

    history.AddMessages(response);
}
// </Snippet1>

// <Snippet2>
List<ChatMessage> chatHistory = [];
while (true)
{
    Console.Write("Q: ");
    chatHistory.Add(new(ChatRole.User, Console.ReadLine()));

    List<ChatResponseUpdate> updates = [];
    await foreach (ChatResponseUpdate update in
        client.GetStreamingResponseAsync(history))
    {
        Console.Write(update);
        updates.Add(update);
    }
    Console.WriteLine();

    chatHistory.AddMessages(updates);
}
// </Snippet2>
