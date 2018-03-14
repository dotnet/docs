//<Snippet1>
using System.Runtime.InteropServices;

namespace InteroperabilityLibrary
{
   public class NativeMethods
   {
      // If DoSomethingUnmanaged does not exist, or has 
      // a different signature or return type, the following 
      // code violates rule PInvokeEntryPointsShouldExist.
      [DllImport("kernel32.dll")]
      public static extern void DoSomethingUnmanaged();
   }
}
//</Snippet1>
