public class AnotherAsyncDisposable : IAsyncDisposable
{
    public AnotherAsyncDisposable() => throw new Exception("Oops, sorry...");

    public ValueTask DisposeAsync() => new();
}
