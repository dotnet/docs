using System;

public sealed class Foo : IDisposable
{
    // Model simplified for brevity sake.
    private readonly IDisposable _bar = new Bar();
    public void Dispose() => _bar.Dispose();
}
