//<Snippet1>
using System.Security;

// These two classes are identical
// except for the location of the attribute.

namespace SecurityRulesLibrary
{
    public class MyBadMemberClass
   {
      [SuppressUnmanagedCodeSecurityAttribute()]
      public void DoWork()
      {
         FormatHardDisk();
      }

      void FormatHardDisk()
      {
         // Code that calls unmanaged code.
      }
   }

   [SuppressUnmanagedCodeSecurityAttribute()]
   public class MyBadTypeClass
   {
      public void DoWork()
      {
         FormatHardDisk();
      }

      void FormatHardDisk()
      {
         // Code that calls unmanaged code.
      }
   }
}
//</Snippet1>
