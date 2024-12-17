using Microsoft.Extensions.AI;

public sealed class SampleEmbeddingGenerator(
    Uri endpoint, string modelId)
        : IEmbeddingGenerator<string, Embedding<float>>
{
    public EmbeddingGeneratorMetadata Metadata { get; } =
        new(nameof(SampleEmbeddingGenerator), endpoint, modelId);

    public async Task<GeneratedEmbeddings<Embedding<float>>> GenerateAsync(
        IEnumerable<string> values,
        EmbeddingGenerationOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        // Simulate some async operation
        await Task.Delay(100, cancellationToken);

        // Create random embeddings
        return
        [
            .. from value in values
            select new Embedding<float>(
                Enumerable.Range(0, 384)
                          .Select(_ => Random.Shared.NextSingle())
                          .ToArray())
        ];
    }

    public object? GetService(Type serviceType, object? serviceKey) => this;

    public TService? GetService<TService>(object? key = null)
        where TService : class => this as TService;

    void IDisposable.Dispose() { }
}
