//<Snippet1>
using System.Security;
using System.Runtime.InteropServices;

namespace SecurityRulesLibrary
{
   public class SuppressIsOnPlatformInvoke
   {
      // The DoWork method is public and provides unsecured access
      // to the platform invoke method FormatHardDisk.
      [SuppressUnmanagedCodeSecurityAttribute()]
      [DllImport("native.dll")]

      private static extern void FormatHardDisk();
      public void DoWork()
      {
         FormatHardDisk();
      }
   }

   // Having the attribute on the type also violates the rule.
   [SuppressUnmanagedCodeSecurityAttribute()]
   public class SuppressIsOnType
   {
      [DllImport("native.dll")]

      private static extern void FormatHardDisk();
      public void DoWork()
      {
         FormatHardDisk();
      }
   }
}
//</Snippet1>
