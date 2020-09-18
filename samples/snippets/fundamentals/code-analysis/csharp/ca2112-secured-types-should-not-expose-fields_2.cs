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