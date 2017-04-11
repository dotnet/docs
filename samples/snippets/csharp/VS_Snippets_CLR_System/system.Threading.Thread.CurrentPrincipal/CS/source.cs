// <Snippet1>
using System;
using System.Security;
using System.Security.Permissions;
using System.Security.Principal;
using System.Threading;

class Principal
{
    static void Main()
    {
        string[] rolesArray = {"managers", "executives"};
        try
        {
            // Set the principal to a new generic principal.
            Thread.CurrentPrincipal = 
                new GenericPrincipal(new GenericIdentity(
                "Bob", "Passport"), rolesArray);
        }
        catch(SecurityException secureException)
        {
            Console.WriteLine("{0}: Permission to set Principal " +
                "is denied.", secureException.GetType().Name);
        }

        IPrincipal threadPrincipal = Thread.CurrentPrincipal;
        Console.WriteLine("Name: {0}\nIsAuthenticated: {1}" +
            "\nAuthenticationType: {2}", 
            threadPrincipal.Identity.Name, 
            threadPrincipal.Identity.IsAuthenticated,
            threadPrincipal.Identity.AuthenticationType);
    }
}
// </Snippet1>