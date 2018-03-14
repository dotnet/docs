//<Snippet1>
using System.Security;
using System.Security.Permissions;
using System;

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
//</Snippet1>
