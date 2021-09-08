using System;
using System.Threading.Tasks;

public class AnotherAsyncDisposable : IAsyncDisposable
{
    public AnotherAsyncDisposable() => throw new Exception("Oops, sorry...");

    public ValueTask DisposeAsync() => new();
}
