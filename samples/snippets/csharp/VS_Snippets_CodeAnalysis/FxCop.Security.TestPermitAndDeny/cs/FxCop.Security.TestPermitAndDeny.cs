//<Snippet1>
using System.Security;
using System.Security.Permissions;
using System;
using SecurityRulesLibrary;

namespace TestSecurityLibrary
{
    // Violates rule: ReviewDenyAndPermitOnlyUsage.
   public class TestPermitAndDeny
   {
      public static void TestAssertAndDeny()
      {
         EnvironmentPermission envPermission = new EnvironmentPermission(
               EnvironmentPermissionAccess.Read,
               "COMPUTERNAME;USERNAME;USERDOMAIN");
         envPermission.Assert();
         try
         {
            SomeSecuredMethods.MethodProtectedByDemand();
            Console.WriteLine(
               "Caller's Deny has no effect on Demand " + 
               "with the asserted permission.");

            SomeSecuredMethods.MethodProtectedByLinkDemand();
            Console.WriteLine(
               "Caller's Deny has no effect on LinkDemand " + 
               "with the asserted permission.");
         }
         catch (SecurityException e)
         {
            Console.WriteLine(
               "Caller's Deny protected the library.{0}", e);
         }
      }

      public static void TestDenyAndLinkDemand()
      {
         try
         {
            SomeSecuredMethods.MethodProtectedByLinkDemand();
            Console.WriteLine(
               "Caller's Deny has no effect with " +
               "LinkDemand-protected code.");
         }
         catch (SecurityException e)
         {
            Console.WriteLine(
               "Caller's Deny protected the library.{0}",e);
         }
      }
         
      public static void Main()
      {
         EnvironmentPermission envPermission = new EnvironmentPermission(
            EnvironmentPermissionAccess.Read,
            "COMPUTERNAME;USERNAME;USERDOMAIN");
         envPermission.Deny();

         //Test Deny and Assert interaction for LinkDemands and Demands.
         TestAssertAndDeny();

         //Test Deny's effects on code in different stack frame. 
         TestDenyAndLinkDemand();

         //Test Deny's effect on code in same frame as deny.
         try
         {
            SomeSecuredMethods.MethodProtectedByLinkDemand();
            Console.WriteLine(
               "This Deny has no effect with LinkDemand-protected code.");
         }
         catch (SecurityException e)
         {
            Console.WriteLine("This Deny protected the library.{0}",e);
         }
      }
   }
}
//</Snippet1>
namespace SecurityRulesLibrary
{
   public  class SomeSecuredMethods
   {
    
      // Demand immediate caller has suitable permission
      // before revealing sensitive data.
      [EnvironmentPermissionAttribute(SecurityAction.LinkDemand,
          Read="COMPUTERNAME;USERNAME;USERDOMAIN")]

      public static void MethodProtectedByLinkDemand()
      {
         Console.Write("LinkDemand: ");
      }

      [EnvironmentPermissionAttribute(SecurityAction.Demand,
          Read="COMPUTERNAME;USERNAME;USERDOMAIN")]

      public static void MethodProtectedByDemand()
      {
         Console.Write("Demand: ");
      }
   }
}