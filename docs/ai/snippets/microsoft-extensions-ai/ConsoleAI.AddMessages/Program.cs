IChatClient client = new SampleChatClient(
    new Uri("http://coolsite.ai"), "target-ai-model");

// <Snippet1>
List<ChatMessage> history = [];
while (true)
{
    Console.Write("Q: ");
    history.Add(new(ChatRole.User, Console.ReadLine()));

    var response = await client.GetResponseAsync(history);
    Console.WriteLine(response);

    history.AddMessages(response);
}
// </Snippet1>

// <Snippet2>
List<ChatMessage> history = [];
while (true)
{
    Console.Write("Q: ");
    history.Add(new(ChatRole.User, Console.ReadLine()));

    List<ChatResponseUpdate> updates = [];
    await foreach (var update in client.GetStreamingResponseAsync(history))
    {
        Console.Write(update);
    }
    Console.WriteLine();

    history.AddMessages(updates);
}
// </Snippet2>
