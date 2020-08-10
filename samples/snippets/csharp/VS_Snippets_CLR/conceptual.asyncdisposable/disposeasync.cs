using System;
using System.Text.Json;
using System.Threading.Tasks;

public class ExampleAsyncDisposable : IAsyncDisposable, IDisposable
{
    // To detect redundant calls
    private bool _disposed = false;

    // Created in .ctor, omitted for brevity.
    private Utf8JsonWriter _jsonWriter;

    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore();

        Dispose(false);
        GC.SuppressFinalize(this);
    }

    protected virtual async ValueTask DisposeAsyncCore()
    {
        // Cascade async dispose calls
        if (_jsonWriter != null)
        {
            await _jsonWriter.DisposeAsync();
            _jsonWriter = null;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            _jsonWriter?.Dispose();
            // TODO: dispose managed state (managed objects).
        }

        // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
        // TODO: set large fields to null.

        _disposed = true;
    }
}
