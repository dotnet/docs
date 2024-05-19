public class ExampleAsyncDisposable : IAsyncDisposable
{
    private IAsyncDisposable? _example;

    public ExampleAsyncDisposable() =>
        _example = new NoopAsyncDisposable();

    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore().ConfigureAwait(false);

        GC.SuppressFinalize(this);
    }

    protected virtual async ValueTask DisposeAsyncCore()
    {
        if (_example is not null)
        {
            await _example.DisposeAsync().ConfigureAwait(false);
        }

        _example = null;
    }
}
