﻿using Microsoft.Extensions.AI;

IChatClient client = new SampleChatClient(
    new Uri("http://coolsite.ai"), "target-ai-model");

Console.WriteLine(await client.CompleteAsync(
[
    new(ChatRole.System, "You are a helpful AI assistant"),
    new(ChatRole.User, "What is AI?"),
]));
