using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

public class DisposableStreamResource2 : DisposableStreamResource
{
    // Define additional constants.
    protected const uint GENERIC_WRITE = 0x40000000;
    protected const uint OPEN_ALWAYS = 4;

    // Define additional APIs.
    [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
    protected static extern bool WriteFile(
        SafeFileHandle safeHandle, string lpBuffer,
        int nNumberOfBytesToWrite, out int lpNumberOfBytesWritten,
        IntPtr lpOverlapped);

    // To detect redundant calls
    private bool _disposed = false;
    private bool _created = false;
    private SafeFileHandle _safeHandle;
    private readonly string _fileName;

    public DisposableStreamResource2(string fileName) : base(fileName) => _fileName = fileName;

    public void WriteFileInfo()
    {
        if (!_created)
        {
            _safeHandle = CreateFile(
                @".\FileInfo.txt", GENERIC_WRITE, 0, IntPtr.Zero,
                OPEN_ALWAYS, FILE_ATTRIBUTE_NORMAL, IntPtr.Zero);

            _created = true;
        }

        string output = $"{_fileName}: {Size:N0} bytes\n";
        _ = WriteFile(_safeHandle, output, output.Length, out _, IntPtr.Zero);
    }

    protected override void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        // Release any managed resources here.
        if (disposing)
        {
            // Dispose managed state (managed objects).
            _safeHandle?.Dispose();
        }

        // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
        // TODO: set large fields to null.

        _disposed = true;

        // Call the base class implementation.
        base.Dispose(disposing);
    }
}
