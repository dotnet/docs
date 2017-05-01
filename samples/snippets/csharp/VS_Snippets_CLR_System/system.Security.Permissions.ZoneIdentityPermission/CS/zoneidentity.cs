// <Snippet1>
using System;
using System.Security;
using System.Security.Permissions;

public class ZoneIdentityPermissionDemo
{
    public static void Main(String[] args)
    {
        IsSubsetOfDemo();
        CopyDemo();
        UnionDemo();
        IntersectDemo();
        ToFromXmlDemo();
    }

    // <Snippet2>
    // IsSubsetOf determines whether the current permission is a subset of the specified permission.
    private static void IsSubsetOfDemo()
    {
        //<Snippet8>
        ZoneIdentityPermission zoneIdPerm1 = new ZoneIdentityPermission(SecurityZone.Intranet);
        //</Snippet8>
        ZoneIdentityPermission zoneIdPerm2 = new ZoneIdentityPermission(SecurityZone.MyComputer);

        if (zoneIdPerm1.IsSubsetOf(zoneIdPerm2))
        {
            Console.WriteLine(zoneIdPerm1.SecurityZone.ToString() + " is a subset of " +
                zoneIdPerm2.SecurityZone.ToString());
        }
        else
        {
            Console.WriteLine(zoneIdPerm1.SecurityZone.ToString() + " is not a subset of " +
                zoneIdPerm2.SecurityZone.ToString());

        }
        if (zoneIdPerm2.IsSubsetOf(zoneIdPerm1))
        {
            Console.WriteLine(zoneIdPerm2.SecurityZone.ToString() + " is a subset of " +
                zoneIdPerm1.SecurityZone.ToString());
        }
        else
        {
            Console.WriteLine(zoneIdPerm2.SecurityZone.ToString() + " is not a subset of " +
                zoneIdPerm1.SecurityZone.ToString());

        }
    }
    // </Snippet2>
    // <Snippet3>
    // Union creates a new permission that is the union of the current permission
    // and the specified permission.
    private static void UnionDemo()
    {
        ZoneIdentityPermission zoneIdPerm1 = new ZoneIdentityPermission(SecurityZone.Intranet);
        ZoneIdentityPermission zoneIdPerm2 = new ZoneIdentityPermission(SecurityZone.MyComputer);
        ZoneIdentityPermission p3 = (ZoneIdentityPermission)zoneIdPerm1.Union(zoneIdPerm2);
        try
        {
            if (p3 != null)
            {
                Console.WriteLine("The union of " + zoneIdPerm1.SecurityZone.ToString() +
                    " and \n\t" + zoneIdPerm2.SecurityZone.ToString() + " is \n\t"
                    + p3.SecurityZone.ToString() + "\n");

            }
            else
            {
                Console.WriteLine("The union of " + zoneIdPerm1.SecurityZone.ToString() +
                    " and \n\t" + zoneIdPerm2.SecurityZone.ToString() + " is null.\n");
            }
        }
        catch (SystemException e)
        {
            Console.WriteLine("The union of " + zoneIdPerm1.SecurityZone.ToString() +
                    " and \n\t" + zoneIdPerm2.SecurityZone.ToString() + " failed.");

            Console.WriteLine(e.Message);
        }

    }
    // </Snippet3>
    // <Snippet4>
    // Intersect creates and returns a new permission that is the intersection of the
    // current permission and the permission specified.
    private static void IntersectDemo()
    {

        ZoneIdentityPermission zoneIdPerm1 = new ZoneIdentityPermission(SecurityZone.Intranet);
        ZoneIdentityPermission zoneIdPerm2 = new ZoneIdentityPermission(SecurityZone.MyComputer);
        ZoneIdentityPermission p3 = (ZoneIdentityPermission)zoneIdPerm1.Intersect(zoneIdPerm2);

        if (p3 != null)
        {
            Console.WriteLine("The intersection of " + zoneIdPerm1.SecurityZone.ToString() + " and \n\t" +
                zoneIdPerm2.SecurityZone.ToString() + " is " + p3.SecurityZone.ToString() + "\n");

        }
        else
        {
            Console.WriteLine("The intersection of " + zoneIdPerm1.SecurityZone.ToString() +
                " and \n\t" + zoneIdPerm2.SecurityZone.ToString() + " is null.\n");
        }


    }
    //</Snippet4>
    //<Snippet5>
    //Copy creates and returns an identical copy of the current permission.
    private static void CopyDemo()
    {

        ZoneIdentityPermission zoneIdPerm1 = new ZoneIdentityPermission(SecurityZone.Intranet);
        //<Snippet7>
        ZoneIdentityPermission zoneIdPerm2 = new ZoneIdentityPermission(PermissionState.None);
        //</Snippet7>
        zoneIdPerm2 = (ZoneIdentityPermission)zoneIdPerm1.Copy();
        if (zoneIdPerm2 != null)
        {
            Console.WriteLine("The copy succeeded:  " + zoneIdPerm2.ToString() + " \n");
        }

    }
    //</Snippet5>
    //<Snippet6>
    // ToXml creates an XML encoding of the permission and its current state; FromXml reconstructs a
    // permission with the specified state from the XML encoding.
    private static void ToFromXmlDemo()
    {


        ZoneIdentityPermission zoneIdPerm1 = new ZoneIdentityPermission(SecurityZone.Intranet);
        ZoneIdentityPermission zoneIdPerm2 = new ZoneIdentityPermission(PermissionState.None);
        zoneIdPerm2.FromXml(zoneIdPerm1.ToXml());
        bool result = zoneIdPerm2.Equals(zoneIdPerm1);
        if (result)
        {
            Console.WriteLine("Result of ToFromXml = " + zoneIdPerm2.ToString());
        }
        else
        {
            Console.WriteLine(zoneIdPerm2.ToString());
            Console.WriteLine(zoneIdPerm1.ToString());
        }

    }
    //</Snippet6>
}

// </Snippet1>
// This code example creates the following output:

//Intranet is not a subset of MyComputer
//MyComputer is not a subset of Intranet
//The copy succeeded:  <IPermission class="System.Security.Permissions.ZoneIdentit
//yPermission, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c56
//1934e089"
//version="1"
//Zone="Intranet"/>


//The union of Intranet and
//        MyComputer is
//        NoZone

//The intersection of Intranet and
//        MyComputer is null.

//Result of ToFromXml = <IPermission class="System.Security.Permissions.ZoneIdenti
//tyPermission, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c5
//61934e089"
//version="1"
//Zone="Intranet"/>