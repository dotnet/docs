//<Snippet1>
using System;
using System.Runtime.InteropServices;
[assembly: System.Security.AllowPartiallyTrustedCallers()]

namespace SecurityLibrary
{
    class NativeMethods
    {
        // Violates rule: SpecifyMarshalingForPInvokeStringArguments.
        [DllImport("advapi32.dll", CharSet=CharSet.Auto)]
        internal static extern int RegCreateKey(IntPtr key, String subKey, out IntPtr result);

        // Satisfies rule: SpecifyMarshalingForPInvokeStringArguments.
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode)]
        internal static extern int RegCreateKey2(IntPtr key, String subKey, out IntPtr result);
    }
}
//</Snippet1>
