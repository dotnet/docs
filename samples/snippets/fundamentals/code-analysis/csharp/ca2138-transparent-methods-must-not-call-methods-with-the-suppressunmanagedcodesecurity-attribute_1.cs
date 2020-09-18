using System;
using System.Runtime.InteropServices;
using System.Security;


namespace TransparencyWarningsDemo
{

    public class CallSuppressUnmanagedCodeSecurityClass
    {
        [SuppressUnmanagedCodeSecurity]
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool Beep(uint dwFreq, uint dwDuration);

        public void CallNativeMethod()
        {
            // CA2138 violation - transparent method calling a method marked with SuppressUnmanagedCodeSecurity
            // (this is also a CA2149 violation as well, since this is a P/Invoke and not an interface call).
            Beep(10000, 1);
        }
    }

}
