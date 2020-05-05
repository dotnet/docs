// <Snippet3>
using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

class BaseClass : IDisposable
{
    // To detect redundant calls
    bool _disposed = false;

    // Instantiate a SafeHandle instance.
    SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);

    // Public implementation of Dispose pattern callable by consumers.
    public void Dispose()
    {
        // Do not change this code. Put cleanup code in Dispose(bool disposing) below.
        Dispose(true);
        // TODO: uncomment the following line if the finalizer is overridden.
        // GC.SuppressFinalize(this);
    }

    // Protected implementation of Dispose pattern.
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
           // Dispose managed state (managed objects).
            _safeHandle.Dispose();
        }

        _disposed = true;
    }
}
// </Snippet3>
