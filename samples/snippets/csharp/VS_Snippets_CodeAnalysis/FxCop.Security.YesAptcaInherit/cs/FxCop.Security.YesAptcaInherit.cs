//<Snippet1>
using System;
using System.Security;
using System.Security.Permissions;
using System.Reflection;

// This class is compiled into an assembly that executes with full 
// trust and allows partially trusted callers. 

// Violates rule: AptcaTypesShouldOnlyExtendAptcaBaseTypes.

namespace AptcaTestLibrary
{
   public class InheritAClassRequiringFullTrust: 
      ClassRequiringFullTrustWhenInherited
   {
      private DateTime meetingDay = DateTime.Parse("February 22 2003");

      public override string ToString() 
      {
         // Another error:
         // This method gives untrusted callers the value 
         // of TrustedLocation. This information should 
         // only be seen by trusted callers.
         string s = String.Format(
            "Meet at the {0} {1}!", 
            this.TrustedLocation, meetingDay.ToString());
         return s;
      }
   }
}
//</Snippet1>
namespace AptcaTestLibrary
{
    public class ClassRequiringFullTrustWhenInherited
    {
        public string TrustedLocation = " ";
    }
}