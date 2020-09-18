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