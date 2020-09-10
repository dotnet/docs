using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

public class ExampleAsyncDisposable : IAsyncDisposable, IDisposable
{
    private bool _disposed;
    private Utf8JsonWriter _jsonWriter = new Utf8JsonWriter(new MemoryStream());

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore();

        Dispose(disposing: false);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        _disposed = true;

        if (disposing)
        {
            _jsonWriter?.Dispose();
        }

        _jsonWriter = null;
    }

    protected virtual async ValueTask DisposeAsyncCore()
    {
        if (!_disposed)
        {
            _disposed = true;

            if (_jsonWriter is not null)
            {
                await _jsonWriter.DisposeAsync();
            }

            _jsonWriter = null;
        }
    }
}
