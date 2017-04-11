//<Snippet1>
using namespace System;
using namespace System::Runtime::InteropServices;

[assembly: ComVisible(false)];
namespace InteroperabilityLibrary
{
   [ComVisible(true)]
   ref class NativeMethods
   {
   private:
      NativeMethods() {}

   internal:
      [DllImport("user32.dll", SetLastError = true)]
      [returnvalue: MarshalAs(UnmanagedType::Bool)]
      static Boolean MessageBeep(UInt32 uType);

      [DllImport("mscoree.dll", 
                 CharSet = CharSet::Unicode, 
                 SetLastError = true)]
      [returnvalue: MarshalAs(UnmanagedType::U1)]
      static bool StrongNameSignatureVerificationEx(
         [MarshalAs(UnmanagedType::LPWStr)] String^ wszFilePath,
         [MarshalAs(UnmanagedType::U1)] Boolean fForceVerification,
         [MarshalAs(UnmanagedType::U1)] Boolean^ pfWasVerified);
   };
}
//</Snippet1>
