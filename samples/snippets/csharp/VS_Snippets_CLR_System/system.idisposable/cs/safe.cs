using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

// Wraps the IntPtr allocated by Marshal.AllocHGlobal() into a SafeHandle.
class LocalAllocHandle : SafeHandleZeroOrMinusOneIsInvalid
{
    private LocalAllocHandle() : base(ownsHandle: true) { }

    // No need to implement a finalizer - SafeHandle's finalizer will call ReleaseHandle for you.
    protected override bool ReleaseHandle()
    {
        Marshal.FreeHGlobal(handle);
        return true;
    }

    // Allocate bytes with Marshal.AllocHGlobal() and wrap the result into a SafeHandle.
    public static LocalAllocHandle Allocate(int numberOfBytes)
    {
        IntPtr nativeHandle = Marshal.AllocHGlobal(numberOfBytes);
        LocalAllocHandle safeHandle = new LocalAllocHandle();
        safeHandle.SetHandle(nativeHandle);
        return safeHandle;
    }
}

public class DisposableWithSafeHandle : IDisposable
{
    // Detect redundant Dispose() calls.
    private bool _isDisposed;

    // Managed disposable objects owned by this class
    private LocalAllocHandle? _safeHandle = LocalAllocHandle.Allocate(10);
    private Stream? _otherUnmanagedResource = new MemoryStream();

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
                _otherUnmanagedResource?.Dispose();
                _safeHandle?.Dispose();
                _otherUnmanagedResource = null;
                _safeHandle = null;
            }
        }
    }
}
