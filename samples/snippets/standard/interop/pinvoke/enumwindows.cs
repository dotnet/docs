using System;
using System.Runtime.InteropServices;

namespace ConsoleApplication1
{
    public static unsafe partial class Program
    {
        // Import user32.dll (containing the function we need) and define
        // the method corresponding to the native function.
        [LibraryImport("user32.dll")]
        private static partial int EnumWindows(delegate* unmanaged<IntPtr, IntPtr, int> lpEnumFunc, IntPtr lParam);

        // Define the implementation of the callback; here, we simply output the window handle.
        [UnmanagedCallersOnly]
        private static int OutputWindow(IntPtr hwnd, IntPtr lParam)
        {
            Console.WriteLine(hwnd.ToInt64());
            return 1 /* true */;
        }

        public static void Main2(string[] args)
        {
            // Invoke the method; note the delegate as a first parameter.
            EnumWindows(&OutputWindow, IntPtr.Zero);
        }
    }
}
