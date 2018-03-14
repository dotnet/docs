//<Snippet1>
using System;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using System.ComponentModel;

class SafeHandlesExample
{

    static void Main()
    {
        try
        {

            UnmanagedFileLoader loader = new UnmanagedFileLoader("example.xml");


        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        Console.ReadLine();


    }
}

class UnmanagedFileLoader
{

    public const short FILE_ATTRIBUTE_NORMAL = 0x80;
    public const short INVALID_HANDLE_VALUE = -1;
    public const uint GENERIC_READ = 0x80000000;
    public const uint GENERIC_WRITE = 0x40000000;
    public const uint CREATE_NEW = 1;
    public const uint CREATE_ALWAYS = 2;
    public const uint OPEN_EXISTING = 3;

    // Use interop to call the CreateFile function.
    // For more information about CreateFile,
    // see the unmanaged MSDN reference library.
    [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess,
      uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition,
      uint dwFlagsAndAttributes, IntPtr hTemplateFile);


    private SafeFileHandle handleValue = null;


    public UnmanagedFileLoader(string Path)
    {
        Load(Path);
    }


    public void Load(string Path)
    {
        if (Path == null && Path.Length == 0)
        {
            throw new ArgumentNullException("Path");
        }

         // Try to open the file.
        IntPtr ptr = CreateFile(Path, GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);

        handleValue = new SafeFileHandle(ptr, true);

        // If the handle is invalid,
         // get the last Win32 error 
         // and throw a Win32Exception.
         if (handleValue.IsInvalid)
         {
             Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
         }
    }

    public SafeFileHandle Handle
    {
        get
        {
            // If the handle is valid,
            // return it.
            if (!handleValue.IsInvalid)
            {
                return handleValue;
            }
            else
            {
                return null;
            }
        }

    }

}
//</Snippet1>