using Microsoft.Extensions.AI;
using System.Threading.RateLimiting;

IEmbeddingGenerator<string, Embedding<float>> generator =
    new RateLimitingEmbeddingGenerator(
        new SampleEmbeddingGenerator(new Uri("http://coolsite.ai"), "target-ai-model"),
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
