//<Snippet1>
using System;
using System.Security;
using System.Security.Permissions;

[assembly:AllowPartiallyTrustedCallers]  

namespace SecurityRulesLibrary
{
   // Violates rule: ReviewDeclarativeSecurityOnValueTypes.
   [System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")]

   public struct SecuredTypeStructure 
   {
      internal double xValue;
      internal double yValue;
      
      public SecuredTypeStructure(double x, double y) 
      {
         xValue = x;
         yValue = y;
         Console.WriteLine("Creating an instance of SecuredTypeStructure.");
      }     
      public override string ToString()
      {
         return String.Format ("SecuredTypeStructure {0} {1}", xValue, yValue);
      }
   }

   public class StructureManager
   {
      // This method asserts trust, incorrectly assuming that the caller must have 
      // permission because they passed in instance of the value type.
      [System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Assert, Name="FullTrust")]

      public static SecuredTypeStructure AddStepValue(SecuredTypeStructure aStructure)
      {
         aStructure.xValue += 100;
         aStructure.yValue += 100;
         Console.WriteLine ("New values {0}", aStructure.ToString());
         return aStructure;
      }
   }
}
//</Snippet1>
