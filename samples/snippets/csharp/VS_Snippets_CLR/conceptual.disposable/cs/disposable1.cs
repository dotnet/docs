// <Snippet1>
public sealed class Foo : IDisposable
{
    readonly IDisposable _bar;

    public Foo()
    {
        _bar = new Bar();
    }

    public void Dispose()
    {
        _bar?.Dispose();
    }
}
// </Snippet1>