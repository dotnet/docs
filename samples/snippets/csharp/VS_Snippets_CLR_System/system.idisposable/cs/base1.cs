using System;
using System.IO;
using System.Threading;

public class DisposableBase : IDisposable
{
    // Detect redundant Dispose() calls in a thread-safe manner.
    // _isDisposed == 0 means Dispose(bool) has not been called yet.
    // _isDisposed == 1 means Dispose(bool) has been already called.
    private int _isDisposed;

    // Instantiate a disposable object owned by this class.
    private Stream? _managedResource = new MemoryStream();

    // Public implementation of Dispose pattern callable by consumers.
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    // Protected implementation of Dispose pattern.
    protected virtual void Dispose(bool disposing)
    {
        // In case _isDisposed is 0, atomically set it to 1.
        // Enter the branch only if the original value is 0.
        if (Interlocked.CompareExchange(ref _isDisposed, 1, 0) == 0)
        {
            if (disposing)
            {
                // Dispose managed state.
                _managedResource?.Dispose();
                _managedResource = null;
            }
        }
    }
}
