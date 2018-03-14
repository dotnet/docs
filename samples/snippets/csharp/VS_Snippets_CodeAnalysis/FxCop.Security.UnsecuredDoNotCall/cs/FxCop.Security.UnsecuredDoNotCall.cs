//<Snippet1>
using System;
using System.IO;
using System.Security;
using System.Security.Permissions;

namespace SecurityRulesLibrary
{
   public class DoNotIndirectlyExposeMethodsWithLinkDemands
   {
      // Violates rule: DoNotIndirectlyExposeMethodsWithLinkDemands.
      public static string DomainInformation()
      {
         return EnvironmentSetting("USERDNSDOMAIN");
      }

      // Library method with link demand.
      // This method holds its immediate callers responsible for securing the information.
      // Because a caller must have unrestricted permission, the method asserts read permission
      // in case some caller in the stack does not have this permission. 

      [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted=true)]
      public static string EnvironmentSetting(string environmentVariable)
      {
         EnvironmentPermission envPermission = new EnvironmentPermission( EnvironmentPermissionAccess.Read,environmentVariable);
         envPermission.Assert();
  
         return Environment.GetEnvironmentVariable(environmentVariable);
      }
   }
}
//</Snippet1>
