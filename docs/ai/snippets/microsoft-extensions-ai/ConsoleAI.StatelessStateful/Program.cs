using Microsoft.Extensions.AI;
using OllamaSharp;

IChatClient client = new OllamaApiClient(new Uri("http://localhost:11434"), "llama3.1");

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
ChatOptions statefulOptions = new() { ConversationId = "my-conversation-id" };
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

    options.ConversationId = response.ConversationId;
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

    chatOptions.ConversationId = response.ConversationId;
    if (response.ConversationId is not null)
    {
        chatHistory.Clear();
    }
    else
    {
        chatHistory.AddMessages(response);
    }
}
// </Snippet4>
