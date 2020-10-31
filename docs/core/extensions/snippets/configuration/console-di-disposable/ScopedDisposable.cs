using System;

namespace ConsoleDisposable.Example
{
    public class ScopedDisposable : IDisposable
    {
        public void Dispose() => Console.WriteLine($"{nameof(ScopedDisposable)}.Dispose()");
    }
}
