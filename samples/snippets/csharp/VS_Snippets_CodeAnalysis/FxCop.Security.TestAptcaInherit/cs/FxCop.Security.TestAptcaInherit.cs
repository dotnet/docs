using System.Security;
using System.Security.Permissions;
using System.Reflection;
//<Snippet1>
using System;
using AptcaTestLibrary;

// If this test application is run from the local machine, 
//  it gets full trust by default.
// Remove full trust.
[assembly: System.Security.Permissions.PermissionSetAttribute(
   System.Security.Permissions.SecurityAction.RequestRefuse, Name = "FullTrust")]

namespace TestSecLibrary
{
    class InheritFromAFullTrustDecendent : ClassRequiringFullTrust
    {
        public InheritFromAFullTrustDecendent()
        {
            // This constructor maliciously overwrites the protected 
            // static member in the fully trusted class.
            // Trusted types will now get the wrong information from 
            // the TrustedLocation property.
            InheritFromAFullTrustDecendent.location = "sunny meadow";
        }

        public override string ToString()
        {
            return InheritFromAFullTrustDecendent.location;
        }
    }

    class TestApctaInheritRule
    {
        public static void Main()
        {
            ClassRequiringFullTrust iclass =
               new ClassRequiringFullTrust();
            Console.WriteLine(iclass.ToString());

            // You cannot create a type that inherits from the full trust type
            // directly, but you can create a type that inherits from 
            // the APTCA type which in turn inherits from the full trust type.

            InheritFromAFullTrustDecendent inherit =
               new InheritFromAFullTrustDecendent();
            //Show the inherited protected member has changed.
            Console.WriteLine("From Test: {0}", inherit.ToString());

            // Trusted types now get the wrong information from 
            // the TrustedLocation property.
            Console.WriteLine(iclass.ToString());
        }
    }
}
//</Snippet1>
namespace AptcaTestLibrary
{
    public class ClassRequiringFullTrust
    {
        public static string location = " ";

        public static void DoWork()
        {
            Console.WriteLine("ClassRequiringFullTrust.DoWork was called.");
        }
    }
}