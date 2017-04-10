
// NCLMailPerms

using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;


namespace Examples.SmptExamples.Permissions
{

    public class Test
    {
// <snippet1>
    public static SmtpPermission CreateConnectPermission()
    {
        SmtpPermission connectAccess = new 
            SmtpPermission(SmtpAccess.Connect);
        Console.WriteLine("Access? {0}", connectAccess.Access);
        return connectAccess;
    }
// </snippet1>
// <snippet2>
    public static SmtpPermission CreateUnrestrictedPermission()
    {
        SmtpPermission allAccess = new 
            SmtpPermission(System.Security.Permissions.PermissionState.Unrestricted);
        Console.WriteLine("Is unrestricted? {0}", 
            allAccess.IsUnrestricted());
        return allAccess;
    }
// </snippet2>

//<snippet3>
    public static SmtpPermission CreatePermissionCopy(SmtpPermission p)
    {
        SmtpPermission copy = (SmtpPermission) p.Copy();
        return copy;
    }
//</snippet3>
// <snippet4>
    public static SmtpPermission CreateUnrestrictedPermission2()
    {
        SmtpPermission allAccess = new 
            SmtpPermission(true);
        Console.WriteLine("Is unrestricted? {0}", 
            allAccess.IsUnrestricted());
        return allAccess;
    }
// </snippet4>
// <snippet5>
    public static SmtpPermission GiveFullAccess(SmtpPermission permission)
    {
        permission.AddPermission(SmtpAccess.Connect);
        return permission;
    }
// </snippet5>

// <snippet6>
    public static SmtpPermission IntersectionWithFull(SmtpPermission permission)
    {
        SmtpPermission allAccess = new 
            SmtpPermission(System.Security.Permissions.PermissionState.Unrestricted);
        return (SmtpPermission) permission.Intersect(allAccess);
    }
// </snippet6>

// <snippet7>
    public static bool CheckSubSet(SmtpPermission permission)
    {
        SmtpPermission allAccess = new 
            SmtpPermission(System.Security.Permissions.PermissionState.Unrestricted);
        return permission.IsSubsetOf(allAccess);
    }
// </snippet7>

// <snippet8>
    public static SmtpPermission UnionWithFull(SmtpPermission permission)
    {
        SmtpPermission allAccess = new 
            SmtpPermission(System.Security.Permissions.PermissionState.Unrestricted);
        return  (SmtpPermission)  permission.Union(allAccess);
    }
// </snippet8>
    public static void Main()
    {


    }
    }

}
