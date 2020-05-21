// <Snippet4>
using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

class DerivedClass : BaseClass
{
    // To detect redundant calls
    private bool _disposed = false;

    // Instantiate a SafeHandle instance.
    private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);

    // Protected implementation of Dispose pattern.
    protected override void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
           // Dispose managed state (managed objects).
            _safeHandle?.Dispose();
        }

        _disposed = true;

        // Call base class implementation.
        base.Dispose(disposing);
    }
}
// </Snippet4>

class BaseClass : IDisposable
{
    // To detect redundant calls
    private bool _disposed = false;

    // Public implementation of Dispose pattern callable by consumers.
    public void Dispose() => Dispose(true);

    // Protected implementation of Dispose pattern.
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

        _disposed = true;
    }
}