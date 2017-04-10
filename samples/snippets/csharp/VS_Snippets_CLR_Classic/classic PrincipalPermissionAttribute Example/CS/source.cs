//<Snippet1>
using System;
using System.Threading;
using System.Security.Permissions;
using System.Security.Principal;

class SecurityPrincipalDemo
{
    public static void Main()
    {
        try
        {
            // PrincipalPolicy must be set to WindowsPrincipal to check roles.
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            // Check using the PrincipalPermissionAttribute
            CheckAdministrator();
            // Check using PrincipalPermission class.
            PrincipalPermission principalPerm = new PrincipalPermission(null, "Administrators");
            principalPerm.Demand();
            Console.WriteLine("Demand succeeded.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    [PrincipalPermission(SecurityAction.Demand, Role = "Administrators")]
    static void CheckAdministrator()
    {
        Console.WriteLine("User is an administrator");
    }
}
//</Snippet1>