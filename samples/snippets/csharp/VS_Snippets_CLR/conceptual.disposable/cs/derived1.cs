// <Snippet10>
using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

public class DisposableStreamResource2 : DisposableStreamResource
{
    // Define additional constants.
    protected const uint GENERIC_WRITE = 0x40000000;
    protected const uint OPEN_ALWAYS = 4;

    // Define additional APIs.
    [DllImport("kernel32.dll")]
    protected static extern bool WriteFile(
        SafeFileHandle safeHandle, string lpBuffer,
        int nNumberOfBytesToWrite, out int lpNumberOfBytesWritten,
        IntPtr lpOverlapped);

    // Define locals.
    bool _disposed = false;
    bool _created = false;
    SafeFileHandle _safeHandle;
    readonly string _fileName;

    public DisposableStreamResource2(string fileName) : base(fileName) => _fileName = fileName;

    public void WriteFileInfo()
    {
        if (!_created)
        {
            IntPtr hFile = CreateFile(
                @".\FileInfo.txt", GENERIC_WRITE, 0, IntPtr.Zero,
                OPEN_ALWAYS, FILE_ATTRIBUTE_NORMAL, IntPtr.Zero);

            if (hFile == INVALID_HANDLE_VALUE)
            {
                throw new IOException("Unable to create output file.");
            }

            _safeHandle = new SafeFileHandle(hFile, true);
            _created = true;
        }

        var output = $"{_fileName}: {Size:N0} bytes\n";
        bool result = WriteFile(_safeHandle, output, output.Length, out int bytesWritten, IntPtr.Zero);
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
            _safeHandle?.Dispose();
        }

        _disposed = true;

        // Release any unmanaged resources not wrapped by safe handles here.

        // Call the base class implementation.
        base.Dispose(disposing);
    }
}
// </Snippet10>

class Example
{
    static void Main()
    {
        using var resource = new DisposableStreamResource2(@"C:\Windows\Explorer.exe");
        resource.WriteFileInfo();

        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();
    }
}

public class DisposableStreamResource : IDisposable
{
    // Define constants.
    protected const uint GENERIC_READ = 0x80000000;
    protected const uint FILE_SHARE_READ = 0x00000001;
    protected const uint OPEN_EXISTING = 3;
    protected const uint FILE_ATTRIBUTE_NORMAL = 0x80;
    protected IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
    const int INVALID_FILE_SIZE = unchecked((int)0xFFFFFFFF);

    // Define Windows APIs.
    [DllImport("kernel32.dll", EntryPoint = "CreateFileW", CharSet = CharSet.Unicode)]
    protected static extern IntPtr CreateFile(
        string lpFileName, uint dwDesiredAccess,
        uint dwShareMode, IntPtr lpSecurityAttributes,
        uint dwCreationDisposition, uint dwFlagsAndAttributes,
        IntPtr hTemplateFile);

    [DllImport("kernel32.dll")]
    static extern int GetFileSize(SafeFileHandle hFile, out int lpFileSizeHigh);

    // Define locals.
    bool _disposed = false;
    readonly SafeFileHandle _safeHandle;
    readonly int _upperWord;

    public DisposableStreamResource(string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
        {
            throw new ArgumentException("The fileName cannot be null or an empty string");
        }

        IntPtr handle = CreateFile(
            fileName, GENERIC_READ, FILE_SHARE_READ, IntPtr.Zero,
            OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, IntPtr.Zero);

        if (handle == INVALID_HANDLE_VALUE)
        {
            throw new FileNotFoundException($"Cannot open '{fileName}'");
        }

        _safeHandle = new SafeFileHandle(handle, true);

        // Get file size.
        Size = GetFileSize(_safeHandle, out _upperWord);
        if (Size == INVALID_FILE_SIZE)
        {
            Size = -1;
        }
        else if (_upperWord > 0)
        {
            Size = (((long)_upperWord) << 32) + Size;
        }
    }

    public long Size { get; }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        // Dispose of managed resources here.
        if (disposing)
        {
            _safeHandle.Dispose();
        }

        // Dispose of any unmanaged resources not wrapped in safe handles.

        _disposed = true;
    }
}
