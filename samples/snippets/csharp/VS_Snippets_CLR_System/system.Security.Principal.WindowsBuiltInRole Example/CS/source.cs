﻿//<Snippet1>
using System;
using System.Threading;
using System.Security.Permissions;
using System.Security.Principal;

class SecurityPrincipalDemo
{
    public static void DemonstrateWindowsBuiltInRoleEnum()
    {
        AppDomain myDomain = Thread.GetDomain();

        myDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
        WindowsPrincipal myPrincipal = (WindowsPrincipal)Thread.CurrentPrincipal;
        Console.WriteLine("{0} belongs to: ", myPrincipal.Identity.Name.ToString());
        Array wbirFields = Enum.GetValues(typeof(WindowsBuiltInRole));
        //<Snippet2>
        foreach (object roleName in wbirFields)
        {
            try
            {
                // Cast the role name to a RID represented by the WindowsBuildInRole value.
                Console.WriteLine("{0}? {1}.", roleName,
                    myPrincipal.IsInRole((WindowsBuiltInRole)roleName));
                Console.WriteLine("The RID for this role is: " + ((int)roleName).ToString());
            }
            catch (Exception)
            {
                Console.WriteLine("{0}: Could not obtain role for this RID.",
                    roleName);
            }
        }
        //</Snippet2>
        //<Snippet3>
        // Get the role using the string value of the role.
        Console.WriteLine("{0}? {1}.", "Administrators",
            myPrincipal.IsInRole("BUILTIN\\" + "Administrators"));
        Console.WriteLine("{0}? {1}.", "Users",
            myPrincipal.IsInRole("BUILTIN\\" + "Users"));
        //</Snippet3>
        //<Snippet4>
        // Get the role using the WindowsBuiltInRole enumeration value.
        Console.WriteLine("{0}? {1}.", WindowsBuiltInRole.Administrator,
           myPrincipal.IsInRole(WindowsBuiltInRole.Administrator));
        //</Snippet4>
        //<Snippet5>
        // Get the role using the WellKnownSidType.
        SecurityIdentifier sid = new SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid, null);
        Console.WriteLine("WellKnownSidType BuiltinAdministratorsSid  {0}? {1}.", sid.Value, myPrincipal.IsInRole(sid));
        //</snippet5>
    }

    public static void Main()
    {
        DemonstrateWindowsBuiltInRoleEnum();
    }
}
// </Snippet1>
