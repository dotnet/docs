namespace ConsoleDisposable.Example;

public sealed class ScopedDisposable : IDisposable
{
    public void Dispose() => Console.WriteLine($"{nameof(ScopedDisposable)}.Dispose()");
}
