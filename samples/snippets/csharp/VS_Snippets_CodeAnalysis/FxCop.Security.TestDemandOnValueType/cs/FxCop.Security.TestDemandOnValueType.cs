//<Snippet1>
using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using SecurityRulesLibrary;

// Run this test code with partial trust.
[assembly: System.Security.Permissions.PermissionSetAttribute(
   System.Security.Permissions.SecurityAction.RequestRefuse, 
   Name="FullTrust")]

namespace TestSecurityExamples
{
   public class TestDemandOnValueType
   {
      static SecuredTypeStructure mystruct;

      [STAThread]
      public static void Main() 
      {
         try
         {
            mystruct = new SecuredTypeStructure(10,10);
            
         }
         catch (SecurityException e)
         {
            Console.WriteLine(
               "Structure custom constructor: {0}", e.Message);
         }

         // The call to the default constructor 
         // does not throw an exception.
         try 
         {
            mystruct = StructureManager.AddStepValue(
               new SecuredTypeStructure());
         }
         catch (SecurityException e)
         {
            Console.WriteLine(
               "Structure default constructor: {0}", e.Message);
         }

         try 
         {
            StructureManager.AddStepValue(mystruct);
         } 

         catch (Exception e)
         {  
            Console.WriteLine(
               "StructureManager add step: {0}", e.Message);
         }
      }
   }
}
//</Snippet1>

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