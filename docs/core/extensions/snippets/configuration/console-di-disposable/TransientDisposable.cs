namespace ConsoleDisposable.Example;

public sealed class TransientDisposable : IDisposable
{
    public void Dispose() => Console.WriteLine($"{nameof(TransientDisposable)}.Dispose()");
}
