﻿using Microsoft.Extensions.AI;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

var sampleChatClient = new SampleChatClient(
    new Uri("http://coolsite.ai"), "target-ai-model");

IChatClient client = new ChatClientBuilder(sampleChatClient)
    .UseDistributedCache(new MemoryDistributedCache(
        Options.Create(new MemoryDistributedCacheOptions())))
    .Build();

string[] prompts = ["What is AI?", "What is .NET?", "What is AI?"];

foreach (var prompt in prompts)
{
    await foreach (var update in client.CompleteStreamingAsync(prompt))
    {
        Console.Write(update);
    }

    Console.WriteLine();
}
