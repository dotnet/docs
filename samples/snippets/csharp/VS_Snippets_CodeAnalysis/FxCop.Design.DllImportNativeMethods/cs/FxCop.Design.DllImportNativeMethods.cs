//<Snippet1>
using System;
using System.Runtime.InteropServices;

namespace DesignLibrary
{
// Violates rule: MovePInvokesToNativeMethodsClass.
    internal class UnmanagedApi
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        internal static extern bool RemoveDirectory(string name);
    }
}
//</Snippet1>
