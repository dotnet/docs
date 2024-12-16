using Microsoft.Extensions.AI;

IChatClient client = new SampleChatClient(
    new Uri("http://coolsite.ai"), "my-custom-model");

var response = await client.CompleteAsync("What is AI?");

Console.WriteLine(response.Message);
