using Microsoft.Extensions.AI;

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
ChatOptions statefulOptions = new() { ChatThreadId = "my-conversation-id" };
while (true)
{
    Console.Write("Q: ");
    ChatMessage message = new(ChatRole.User, Console.ReadLine());

    Console.WriteLine(await client.GetResponseAsync(message, statefulOptions));
}
// </Snippet2>

// <Snippet3>
ChatOptions options = new();
while (true)
{
    Console.Write("Q: ");
    ChatMessage message = new(ChatRole.User, Console.ReadLine());

    ChatResponse response = await client.GetResponseAsync(message, options);
    Console.WriteLine(response);

    options.ChatThreadId = response.ChatThreadId;
}
// </Snippet3>

// <Snippet4>
List<ChatMessage> chatHistory = [];
ChatOptions chatOptions = new();
while (true)
{
    Console.Write("Q: ");
    chatHistory.Add(new(ChatRole.User, Console.ReadLine()));

    ChatResponse response = await client.GetResponseAsync(chatHistory);
    Console.WriteLine(response);

    chatOptions.ChatThreadId = response.ChatThreadId;
    if (response.ChatThreadId is not null)
    {
        chatHistory.Clear();
    }
    else
    {
        chatHistory.AddMessages(response);
    }
}
// </Snippet4>
