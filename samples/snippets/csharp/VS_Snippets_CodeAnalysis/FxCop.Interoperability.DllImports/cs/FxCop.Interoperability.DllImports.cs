//<Snippet1>
using System;
using System.Runtime.InteropServices;

namespace InteroperabilityLibrary
{
    // Violates rule: PInvokesShouldNotBeVisible.
    public class NativeMethods
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        public static extern bool RemoveDirectory(string name);
    }
}
//</Snippet1>
