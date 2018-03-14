//<Snippet1>
using System.Security;
using System.Security.Permissions;
using System.Runtime.InteropServices;

namespace SecurityRulesLibrary
{
   [SuppressUnmanagedCodeSecurityAttribute()]
   public class BadTypeWithPublicPInvokeAndSuppress
   {
      [DllImport("native.dll")]

      public static extern void DoDangerousThing();
      public void DoWork()
      {
         // Note that because DoDangerousThing is public, this 
         // security check does not resolve the violation.
         // This only checks callers that go through DoWork().
         SecurityPermission secPerm = new SecurityPermission(
            SecurityPermissionFlag.ControlPolicy | 
            SecurityPermissionFlag.ControlEvidence
         );
         secPerm.Demand();
         DoDangerousThing();
      }
   }
}
//</Snippet1>
