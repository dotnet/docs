//<Snippet1>
using System;
using System.Security;
using System.Security.Permissions;
using System.Reflection;

// This assembly executes with full trust and 
// allows partially trusted callers. 

[assembly:AllowPartiallyTrustedCallers]  

namespace AptcaTestLibrary
{
   public class AccessAClassRequiringFullTrust
   {
      public static void Access()
      {    
         // This security check fails if the caller 
         // does not have full trust. 
         NamedPermissionSet pset= new NamedPermissionSet("FullTrust");

         // This try-catch block shows the caller's permissions.
         // Correct code would either not catch the exception,
         // or would rethrow it.
         try 
         {
            pset.Demand();
         }
         catch (SecurityException e)
         {
            Console.WriteLine("Demand for full trust:{0}", e.Message);
         }
         // Call the type that requires full trust.
         // Violates rule AptcaMethodsShouldOnlyCallAptcaMethods.
         ClassRequiringFullTrust.DoWork();
     }
   }
}
//</Snippet1>
namespace AptcaTestLibrary
{
   public class ClassRequiringFullTrust
   {
      public static void DoWork()
      {
        Console.WriteLine("ClassRequiringFullTrust.DoWork was called.");
      }
   }
}