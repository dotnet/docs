//<Snippet1>
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace InteroperabilityLibrary
{
    // The platform invoke methods in this class violate the rule.
    [ComVisible(true)]
    internal class NativeMethods
    {
        private NativeMethods() { }

        [DllImport("kernel32.dll", SetLastError = true)]
        internal extern static uint ReadFile(
           IntPtr hFile, IntPtr lpBuffer, int nNumberOfBytesToRead,
           IntPtr lpNumberOfBytesRead, IntPtr overlapped);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal extern static bool ReadFileEx(
           IntPtr hFile, IntPtr lpBuffer, int nNumberOfBytesToRead,
           NativeOverlapped overlapped, IntPtr lpCompletionRoutine);
    }

    // The platform invoke methods in this class satisfy the rule.
    [ComVisible(true)]
    internal class UnsafeNativeMethods
    {
        private UnsafeNativeMethods() { }

        //To compile this code, uncomment these lines and compile
        //with "/unsafe".
        //[DllImport("kernel32.dll", SetLastError = true)]
        //unsafe internal extern static uint ReadFile(
        //   IntPtr hFile, IntPtr lpBuffer, int nNumberOfBytesToRead,
        //   IntPtr lpNumberOfBytesRead, NativeOverlapped* overlapped);

        //[DllImport("kernel32.dll", SetLastError = true)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //unsafe internal extern static bool ReadFileEx(
        //   IntPtr hFile, IntPtr lpBuffer, int nNumberOfBytesToRead,
        //   NativeOverlapped* overlapped, IntPtr lpCompletionRoutine);
    }
}
//</Snippet1>
