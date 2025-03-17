using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

public class DisposableBaseWithFinalizer : IDisposable
{
    // Detect redundant Dispose() calls in a thread-safe manner.
    // _isDisposed == 0 means Dispose(bool) has not been called yet.
    // _isDisposed == 1 means Dispose(bool) has been already called.
    private int _isDisposed;

    // Instantiate a disposable object owned by this class.
    private Stream? _managedResource = new MemoryStream();

    // A pointer to 10 bytes allocated on the unmanaged heap.
    private IntPtr _unmanagedResource = Marshal.AllocHGlobal(10);

    ~DisposableBaseWithFinalizer() => Dispose(false);

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
                _managedResource?.Dispose();
                _managedResource = null;
            }

            Marshal.FreeHGlobal(_unmanagedResource);
        }
    }
}
