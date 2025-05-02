using Microsoft.Extensions.AI;

IChatClient client = new SampleChatClient(
    new Uri("http://coolsite.ai"), "target-ai-model");

Console.WriteLine(await client.GetResponseAsync("What is AI?"));
