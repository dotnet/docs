using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

class DerivedClassWithSafeHandle : BaseClassWithSafeHandle
{
    // To detect redundant calls
    private bool _disposedValue;

    // Instantiate a SafeHandle instance.
    private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);

    // Protected implementation of Dispose pattern.
    protected override void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                _safeHandle.Dispose();
            }

            _disposedValue = true;
        }

        // Call base class implementation.
        base.Dispose(disposing);
    }
}
