using Microsoft.Extensions.AI;

IChatClient client = new ChatClientBuilder(
        new OllamaChatClient(new Uri("http://localhost:11434")))
    .ConfigureOptions(options => options.ModelId ??= "phi3")
    .Build();

// will request "phi3"
Console.WriteLine(await client.GetResponseAsync("What is AI?"));

// will request "llama3.1"
Console.WriteLine(await client.GetResponseAsync(
    "What is AI?", new() { ModelId = "llama3.1" }));
