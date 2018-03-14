//<Snippet1>
using System;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.Win32.SafeHandles;

namespace CriticalFinalizer
{
    class Program
    {
        const int STD_INPUT_HANDLE   = -10;
        const int STD_OUTPUT_HANDLE = -11;
        const int STD_ERROR_HANDLE  =  -12;
        [DllImport("Kernel32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern IntPtr GetStdHandle(int type);

        static void Main(string[] args)
        {
            FileStream fsIn = null;
            FileStream fsOut = null;
            try
            {
                SafeFileHandle sfhIn = new SafeFileHandle(GetStdHandle(STD_INPUT_HANDLE), false);
                fsIn = new FileStream(sfhIn, FileAccess.Read);
                byte[] input = new byte[] {0};
                fsIn.Read(input,0,1);
                SafeFileHandle sfhOut = new SafeFileHandle(GetStdHandle(STD_OUTPUT_HANDLE), false);
                fsOut = new FileStream(sfhOut, FileAccess.Write);
                fsOut.Write(input,0,1);
                SafeFileHandle sf = fsOut.SafeFileHandle;
            }
            finally
            {
                if (fsIn != null)
                {
                    fsIn.Close();
                    fsIn = null;
                }
                if (fsOut != null)
                {
                    fsOut.Close();
                    fsOut = null;
                }
            }
        }
        
    }
}
//</Snippet1>