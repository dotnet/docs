using System;

namespace ConsoleDisposable.Example
{
    public class TransientDisposable : IDisposable
    {
        public void Dispose() => Console.WriteLine($"{nameof(TransientDisposable)}.Dispose()");
    }
}
