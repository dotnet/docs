//<Snippet1>
using System;
using System.Security.Permissions;

namespace SecurityLibrary
{
   [EnvironmentPermission(SecurityAction.LinkDemand, Read = "PATH")]
   public class TypesWithLinkDemands
   {
      public virtual void UnsecuredMethod() {}

      [EnvironmentPermission(SecurityAction.InheritanceDemand, Read = "PATH")]
      public virtual void SecuredMethod() { }
   }
}
//</Snippet1>
