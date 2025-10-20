using System;
using System.Threading;

public class Disposable : IDisposable
{
    // Detect redundant Dispose() calls in a thread-safe manner.
    // _disposed == 0 means Dispose(bool) has not been called yet.
    // _disposed == 1 means Dispose(bool) has been already called.
    private int _disposed;

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
        // In case _disposed is 0, atomically set it to 1.
        // Enter the branch only if the original value is 0.
        if (Interlocked.CompareExchange(ref _disposed, 1, 0) == 0)
        {
            if (disposing)
            {
                // Dispose managed state (managed objects).
                // ...
            }

            // Free unmanaged resources.
            // ...
        }
    }
    // </SnippetDisposeBool>
}
