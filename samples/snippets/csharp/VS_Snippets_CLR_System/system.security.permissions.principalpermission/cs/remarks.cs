using System;
using System.Security;
using System.Security.Policy;
using System.Security.Permissions;

public class PrincipalPermTest
{
    public static void Main()
    {
        Dummy1();
    }
    private static void Dummy1()
    {
// <Snippet1>
        PrincipalPermission ppBob = new PrincipalPermission("Bob", "Administrator");
        PrincipalPermission ppLouise = new PrincipalPermission("Louise", "Administrator");
        IPermission pp1 = ppBob.Intersect(ppLouise);
// </Snippet1>
    }
    private static void Dummy2()
    {
// <Snippet2>
        IPermission pp1 = new PrincipalPermission("", "Administrator");
// </Snippet2>
    }
    private static void Dummy3()
    {
// <Snippet3>
        PrincipalPermission ppBob = new PrincipalPermission("Bob", "Administrator");
        PrincipalPermission ppLouise = new PrincipalPermission("Louise", "Administrator");
// </Snippet3>
    }

}
