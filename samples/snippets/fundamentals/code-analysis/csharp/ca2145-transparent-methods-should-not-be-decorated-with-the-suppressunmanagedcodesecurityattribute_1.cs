using System;
using System.Runtime.InteropServices;
using System.Security;

namespace TransparencyWarningsDemo
{

    public class SafeNativeMethods
    {
        // CA2145 violation - transparent method marked SuppressUnmanagedCodeSecurity.  This should be fixed by
        // marking this method SecurityCritical.
        [DllImport("kernel32.dll", SetLastError = true)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool Beep(uint dwFreq, uint dwDuration);
    }
}
