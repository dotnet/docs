// <Snippet1>
using System;
using System.Security.Permissions;
using System.Security.Principal;
using System.Threading;
using System.Security.Claims;
using System.IdentityModel.Services;

namespace ClaimsBasedAuthorization
{
    /// <summary>
    /// Program illustrates using Claims-based authorization
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
// <Snippet2>
            //
            // Method 1. Simple access check using static method. 
            // Expect this to be most common method.
            //
            ClaimsPrincipalPermission.CheckAccess("resource", "action");
// </Snippet2>

// <Snippet3>
            //
            // Method 2. Programmatic check using the permission class
            // Follows model found at http://msdn.microsoft.com/en-us/library/system.security.permissions.principalpermission.aspx
            //
            ClaimsPrincipalPermission cpp = new ClaimsPrincipalPermission("resource", "action");
            cpp.Demand();
// </Snippet3>

            //
            // Method 3. Access check interacting directly with the authorization manager.
            //            
            ClaimsAuthorizationManager am = new ClaimsAuthorizationManager();
            am.CheckAccess(new AuthorizationContext((ClaimsPrincipal)Thread.CurrentPrincipal, "resource", "action"));

            //
            // Method 4. Call a method that is protected using the permission attribute class
            //
            ProtectedMethod();

            Console.WriteLine("Press [Enter] to continue.");
            Console.ReadLine();
        }
// <Snippet4>

        //
        // Declarative access check using the permission class. The caller must satisfy both demands.
        //
        [ClaimsPrincipalPermission(SecurityAction.Demand, Resource = "resource", Operation = "action")]
        [ClaimsPrincipalPermission(SecurityAction.Demand, Resource = "resource1", Operation = "action1")]
        static void ProtectedMethod()
        {
        }
// </Snippet4>
    }
}
// </Snippet1>