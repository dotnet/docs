using System;
using System.Runtime.InteropServices;

namespace PInvokeSamples
{
    public static partial class Program
    {
        // Import the libSystem shared library and define the method
        // corresponding to the native function.
        [LibraryImport("libSystem.dylib")]
        private static partial int getpid();

        public static void Main(string[] args)
        {
            // Invoke the function and get the process ID.
            int pid = getpid();
            Console.WriteLine(pid);
        }
    }
}
