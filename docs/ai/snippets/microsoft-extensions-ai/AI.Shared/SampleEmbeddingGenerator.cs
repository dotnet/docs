using Microsoft.Extensions.AI;

public sealed class SampleEmbeddingGenerator(
    Uri endpoint, string modelId)
        : IEmbeddingGenerator<string, Embedding<float>>
{
    private readonly EmbeddingGeneratorMetadata _metadata =
        new("SampleEmbeddingGenerator", endpoint, modelId);

    public async Task<GeneratedEmbeddings<Embedding<float>>> GenerateAsync(
        IEnumerable<string> values,
        EmbeddingGenerationOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        // Simulate some async operation.
        await Task.Delay(100, cancellationToken);

        // Create random embeddings.
        return new GeneratedEmbeddings<Embedding<float>>(
            from value in values
            select new Embedding<float>(
                Enumerable.Range(0, 384).Select(_ => Random.Shared.NextSingle()).ToArray()));
    }

    public object? GetService(Type serviceType, object? serviceKey) =>
        serviceKey is not null ? null :
        serviceType == typeof(EmbeddingGeneratorMetadata) ? _metadata :
        serviceType?.IsInstanceOfType(this) is true ? this :
        null;

    void IDisposable.Dispose() { }
}
