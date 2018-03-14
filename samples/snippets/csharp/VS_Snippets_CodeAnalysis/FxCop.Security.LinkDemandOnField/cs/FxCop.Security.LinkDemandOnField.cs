//<Snippet1>
using System;
using System.Reflection;
using System.Security;
using System.Security.Permissions;

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
//</Snippet1>
