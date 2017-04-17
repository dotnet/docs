//<Snippet1>
using System;
using System.Threading;
using System.Security.Permissions;
using System.Security.Principal;

class SecurityPrincipalDemo
{

    public static void Main()
    {
        AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
        PrincipalPermission principalPerm = new PrincipalPermission(null, "Administrators");
        principalPerm.Demand();
        Console.WriteLine("Demand succeeded.");
    }
}
//</Snippet1>