//<Snippet1>
using System;
using System.Security;
using System.Security.Permissions;
using System.Reflection;

// This code is compiled into a strong-named assembly
// that requires full trust. 

namespace AptcaTestLibrary
{
   public class ClassRequiringFullTrustWhenInherited
   {
      // This field should be overridable by fully trusted derived types.
      protected static string location = "shady glen";
     
      // A trusted type can see the data, but cannot change it.
      public virtual string TrustedLocation 
      {
         get 
         {
            return location;
         }
      }
   }
}
//</Snippet1>
