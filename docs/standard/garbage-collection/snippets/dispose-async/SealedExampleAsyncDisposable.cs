public sealed class SealedExampleAsyncDisposable : IAsyncDisposable
{
    private readonly IAsyncDisposable _example;

    public SealedExampleAsyncDisposable() =>
        _example = new NoopAsyncDisposable();

    public ValueTask DisposeAsync() => _example.DisposeAsync();
}
