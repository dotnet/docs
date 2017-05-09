//<Snippet1>
using System;
using System.Reflection;
using System.Security;
using System.Security.Permissions;

// This assembly executes with full trust. 

namespace SecurityRulesLibrary
{
   // This type creates and returns instances of the secured type.
   // The GetAnInstance method incorrectly gives the instance 
   // to a type that does not have the link demanded permission.

   public class Distributor
   {
      static SecuredTypeWithFields s = new SecuredTypeWithFields(22,33);
      public static SecuredTypeWithFields GetAnInstance ()
      {
            return s;
      }

      public static void DisplayCachedObject ()
      {
         Console.WriteLine(
            "Cached Object fields: {0}, {1}", s.xValue , s.yValue);
      }
   }
}
//</Snippet1>

namespace SecurityRulesLibrary
{
   // This code requires immediate callers to have full trust.
   [System.Security.Permissions.PermissionSetAttribute(
       System.Security.Permissions.SecurityAction.LinkDemand, 
       Name="FullTrust")]
   public class SecuredTypeWithFields 
   {
      // Even though the type is secured, these fields are not.
      // Violates rule: SecuredTypesShouldNotExposeFields.
      public double xValue;
      public double yValue;
      
      public SecuredTypeWithFields (double x, double y) 
      {
         xValue = x;
         yValue = y;
         Console.WriteLine(
            "Creating an instance of SecuredTypeWithFields.");
      }
      public override string ToString()
      {
          return String.Format (
            "SecuredTypeWithFields {0} {1}", xValue, yValue);
      }
   }
}