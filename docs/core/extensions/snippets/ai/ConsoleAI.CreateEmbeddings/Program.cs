using Microsoft.Extensions.AI;

IEmbeddingGenerator<string, Embedding<float>> generator =
    new SampleEmbeddingGenerator(
        new Uri("http://coolsite.ai"), "target-ai-model");

foreach (var embedding in await generator.GenerateAsync(["What is AI?", "What is .NET?"]))
{
    Console.WriteLine(string.Join(", ", embedding.Vector.ToArray()));
}
