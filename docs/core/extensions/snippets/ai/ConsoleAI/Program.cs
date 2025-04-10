using Microsoft.Extensions.AI;

IChatClient client = new SampleChatClient(
    new Uri("http://coolsite.ai"), "target-ai-model");

var response = await client.GetResponseAsync("What is AI?");

Console.WriteLine(response.Messages.Single());
