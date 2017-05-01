//<Snippet1>
using System;
using System.Runtime.InteropServices;

[assembly: ComVisible(false)]
namespace InteroperabilityLibrary
{
   [ComVisible(true)]
   internal class NativeMethods
   {
      private NativeMethods() {}

      [DllImport("user32.dll", SetLastError = true)]
      [return: MarshalAs(UnmanagedType.Bool)]
      internal static extern Boolean MessageBeep(UInt32 uType);

      [DllImport("mscoree.dll", 
                 CharSet = CharSet.Unicode, 
                 SetLastError = true)]
      [return: MarshalAs(UnmanagedType.U1)]
      internal static extern bool StrongNameSignatureVerificationEx(
         [MarshalAs(UnmanagedType.LPWStr)] string wszFilePath,
         [MarshalAs(UnmanagedType.U1)] bool fForceVerification,
         [MarshalAs(UnmanagedType.U1)] out bool pfWasVerified);
   }
}
//</Snippet1>
