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