using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace PInvokeSamples
{
    public static partial class Program
    {
        [LibraryImport("nativedep")]
        private static partial int ExportedFunction();

        public static void Main(string[] args)
        {
            // Register the import resolver before calling the imported function.
            // Only one import resolver can be set for a given assembly.
            NativeLibrary.SetDllImportResolver(Assembly.GetExecutingAssembly(), DllImportResolver);

            int value = ExportedFunction();
            Console.WriteLine(value);
        }

        private static IntPtr DllImportResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
        {
            if (libraryName == "nativedep")
            {
                // On systems with AVX2 support, load a different library.
                if (System.Runtime.Intrinsics.X86.Avx2.IsSupported)
                {
                    return NativeLibrary.Load("nativedep_avx2", assembly, searchPath);
                }
            }

            // Otherwise, fallback to default import resolver.
            return IntPtr.Zero;
        }
    }
}
