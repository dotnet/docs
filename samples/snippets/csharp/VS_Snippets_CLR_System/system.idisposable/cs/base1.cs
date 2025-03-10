using System;
using System.IO;

public class DisposableBase : IDisposable
{
    // Detect redundant Dispose() calls.
    private bool _isDisposed;

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
        if (!_isDisposed)
        {
            _isDisposed = true;

            if (disposing)
            {
                // Dispose managed state.
                _managedResource?.Dispose();
                _managedResource = null;
            }
        }
    }
}
