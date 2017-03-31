using System.Reflection;
//<Snippet1>
using System;
using System.Security;
using System.Security.Permissions;
using SecurityRulesLibrary;

// This code executes with partial trust.
[assembly: System.Security.Permissions.PermissionSetAttribute(
   System.Security.Permissions.SecurityAction.RequestRefuse,
   Name = "FullTrust")]
namespace TestSecurityExamples
{
    public class TestLinkDemandOnField
    {
        [STAThread]
        public static void Main()
        {
            // Get an instance of the protected object.
            SecuredTypeWithFields secureType = Distributor.GetAnInstance();

            // Even though this type does not have full trust,
            // it can directly access the secured type's fields.
            Console.WriteLine(
               "Secured type fields: {0}, {1}",
               secureType.xValue,
               secureType.yValue);
            Console.WriteLine("Changing secured type's field...");
            secureType.xValue = 99;

            // Distributor must call ToString on the secured object.
            Distributor.DisplayCachedObject();

            // If the following line is uncommented, a security 
            // exception is thrown at JIT-compilation time because 
            // of the link demand for full trust that protects 
            // SecuredTypeWithFields.ToString().

            // Console.WriteLine("Secured type {0}",secureType.ToString());
        }
    }
}
//</Snippet1>
namespace SecurityRulesLibrary
{
    // This code requires immediate callers to have full trust.
    [System.Security.Permissions.PermissionSetAttribute(
        System.Security.Permissions.SecurityAction.LinkDemand,
        Name = "FullTrust")]
    public class SecuredTypeWithFields
    {
        // Even though the type is secured, these fields are not.
        // Violates rule: SecuredTypesShouldNotExposeFields.
        public double xValue;
        public double yValue;

        public SecuredTypeWithFields(double x, double y)
        {
            xValue = x;
            yValue = y;
            Console.WriteLine(
               "Creating an instance of SecuredTypeWithFields.");
        }
        public override string ToString()
        {
            return String.Format(
              "SecuredTypeWithFields {0} {1}", xValue, yValue);
        }
    }

    public class Distributor
    {
        public static SecuredTypeWithFields GetAnInstance()
        {
            SecuredTypeWithFields s = new SecuredTypeWithFields(1,2);
            return s;
        }

        public static void DisplayCachedObject()
        {
        }
    }
}