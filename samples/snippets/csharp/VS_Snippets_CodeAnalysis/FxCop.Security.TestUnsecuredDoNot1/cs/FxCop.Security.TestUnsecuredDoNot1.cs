using System.IO;
//<Snippet1>
using System;
using SecurityRulesLibrary;
using System.Security;
using System.Security.Permissions;

// You have no permission to access the sensitive information,
// but you will get data from the unprotected method.
[assembly:EnvironmentPermissionAttribute(
   SecurityAction.RequestRefuse,Unrestricted=true)]
namespace TestUnsecuredMembers
{
   class TestUnsecured
   {
      [STAThread]
      static void Main(string[] args)
      {
         string value = null;
         try 
         {
            value = DoNotIndirectlyExposeMethodsWithLinkDemands.DomainInformation();
         }
         catch (SecurityException e) 
         {
            Console.WriteLine(
               "Call to unsecured member was stopped by code access security! {0}",
               e.Message);
            throw;
         }
         if (value != null) 
         {
            Console.WriteLine("Value from unsecured member: {0}", value);
         }
      }
   }
}
//</Snippet1>
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