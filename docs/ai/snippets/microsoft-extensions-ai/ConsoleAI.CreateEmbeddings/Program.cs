// <Snippet1>
using Microsoft.Extensions.AI;

IEmbeddingGenerator<string, Embedding<float>> generator =
    new SampleEmbeddingGenerator(
        new Uri("http://coolsite.ai"), "target-ai-model");

foreach (Embedding<float> embedding in
    await generator.GenerateAsync(["What is AI?", "What is .NET?"]))
{
    Console.WriteLine(string.Join(", ", embedding.Vector.ToArray()));
}
// </Snippet1>

// <Snippet2>
ReadOnlyMemory<float> vector = await generator.GenerateEmbeddingVectorAsync("What is AI?");
// </Snippet2>
