using Microsoft.Extensions.AI;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using OpenTelemetry.Trace;

// Configure OpenTelemetry exporter
string sourceName = Guid.NewGuid().ToString();
TracerProvider tracerProvider = OpenTelemetry.Sdk.CreateTracerProviderBuilder()
    .AddSource(sourceName)
    .AddConsoleExporter()
    .Build();

// Explore changing the order of the intermediate "Use" calls to see that impact
// that has on what gets cached, traced, etc.
IEmbeddingGenerator<string, Embedding<float>> generator = new EmbeddingGeneratorBuilder<string, Embedding<float>>(
        new SampleEmbeddingGenerator(new Uri("http://coolsite.ai"), "target-ai-model"))
    .UseDistributedCache(
        new MemoryDistributedCache(
            Options.Create(new MemoryDistributedCacheOptions())))
    .UseOpenTelemetry(sourceName: sourceName)
    .Build();

GeneratedEmbeddings<Embedding<float>> embeddings = await generator.GenerateAsync(
[
    "What is AI?",
    "What is .NET?",
    "What is AI?"
]);

foreach (var embedding in embeddings)
{
    Console.WriteLine(string.Join(", ", embedding.Vector.ToArray()));
}
