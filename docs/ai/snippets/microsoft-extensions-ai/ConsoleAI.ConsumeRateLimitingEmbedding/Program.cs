using Microsoft.Extensions.AI;
using OllamaSharp;
using System.Threading.RateLimiting;

IEmbeddingGenerator<string, Embedding<float>> generator =
    new RateLimitingEmbeddingGenerator(
        new OllamaApiClient(new Uri("http://localhost:11434/"), "phi3:mini"),
        new ConcurrencyLimiter(new()
        {
            PermitLimit = 1,
            QueueLimit = int.MaxValue
        }));

foreach (Embedding<float> embedding in
    await generator.GenerateAsync(["What is AI?", "What is .NET?"]))
{
    Console.WriteLine(string.Join(", ", embedding.Vector.ToArray()));
}
