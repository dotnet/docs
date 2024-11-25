﻿using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using OpenAI;

var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
string model = config["ModelName"];
string key = config["OpenAIKey"];

// Create the IChatClient
IChatClient client =
    new OpenAIClient(key).AsChatClient(model);

// Create and print out the prompt
string prompt = $"""
    summarize the the following text in 20 words or less:
    {File.ReadAllText("benefits.md")}
    """;

Console.WriteLine($"user >>> {prompt}");

// Submit the prompt and print out the response
ChatCompletion response = await client.CompleteAsync(prompt, new ChatOptions { MaxOutputTokens = 400 });
Console.WriteLine($"assistant >>> {response}");
