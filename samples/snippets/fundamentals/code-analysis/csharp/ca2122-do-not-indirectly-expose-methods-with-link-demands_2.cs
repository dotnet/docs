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