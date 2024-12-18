using Microsoft.Extensions.AI;

IChatClient client = new SampleChatClient(
    new Uri("http://coolsite.ai"), "target-ai-model");

var response = await client.CompleteAsync("What is AI?");

Console.WriteLine(response.Message);
