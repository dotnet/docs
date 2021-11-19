using System;

public class Disposable : IDisposable
{
    private bool _disposed;
    // <SnippetDispose>
    public void Dispose()
    {
        // Dispose of unmanaged resources.
        Dispose(true);
        // Suppress finalization.
        GC.SuppressFinalize(this);
    }
    // </SnippetDispose>

    // <SnippetDisposeBool>
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            // TODO: dispose managed state (managed objects).
        }

        // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
        // TODO: set large fields to null.

        _disposed = true;
    }
    // </SnippetDisposeBool>
}
