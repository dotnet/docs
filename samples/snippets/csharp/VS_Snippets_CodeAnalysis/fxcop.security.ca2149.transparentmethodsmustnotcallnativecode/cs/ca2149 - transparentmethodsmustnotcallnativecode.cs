//<Snippet1>
using System;
using System.Runtime.InteropServices;

namespace TransparencyWarningsDemo
{

    public class CallNativeCodeClass
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool Beep(uint dwFreq, uint dwDuration);

        public void CallNativeMethod()
        {
            // CA2149 violation - transparent method calling native code
            Beep(10000, 1);
        }
    }

}

//</Snippet1>