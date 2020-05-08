// <Snippet1>
public sealed class Foo : IDisposable
{
    readonly IDisposable _bar;

    public Foo(IDisposable bar)
    {
        _bar = bar;
    }

    void IDisposable.Dispose()
    {
        _bar?.Dispose();
    }
}
// </Snippet1>