using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
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

public class DisposableBaseWithSafeHandle : IDisposable
{
    // Detect redundant Dispose() calls in a thread-safe manner.
    // _isDisposed == 0 means Dispose(bool) has not been called yet.
    // _isDisposed == 1 means Dispose(bool) has been already called.
    private int _isDisposed;

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
        // In case _isDisposed is 0, atomically set it to 1.
        // Enter the branch only if the original value is 0.
        if (Interlocked.CompareExchange(ref _isDisposed, 1, 0) == 0)
        {
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
