﻿using Microsoft.Extensions.AI;

IChatClient client = new SampleChatClient(
    new Uri("http://coolsite.ai"), "target-ai-model");

await foreach (var update in client.CompleteStreamingAsync("What is AI?"))
{
    Console.Write(update);
}
