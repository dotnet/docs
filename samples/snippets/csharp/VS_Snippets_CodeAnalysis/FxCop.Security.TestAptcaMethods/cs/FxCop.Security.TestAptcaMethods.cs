//<Snippet1>
using System;
using AptcaTestLibrary;

// If this test is run from the local computer, it gets full trust by default.
// Remove full trust.
[assembly:System.Security.Permissions.PermissionSetAttribute(
   System.Security.Permissions.SecurityAction.RequestRefuse, Name="FullTrust")]

namespace TestSecLibrary
{
   class TestApctaMethodRule
   {
      public static void Main()
      {
          // Indirectly calls DoWork in the full-trust class.
          ClassRequiringFullTrust testClass = new ClassRequiringFullTrust();
          testClass.Access();
      }
   }
}
//</Snippet1>
namespace AptcaTestLibrary
{
    public class ClassRequiringFullTrust
    {
        public void Access() { }
    }
}