// This sample demonstrates the IsSubsetOf, Union, Intersect, Copy, ToXml and FromXml methods
// of the ReflectionPermission class.
//<Snippet1>
using System;
using System.Security;
using System.Security.Permissions;

public class ReflectionPermissionDemo
{
    // Demonstrate all methods.
    public static void Main(String[] args)
    {
        IsSubsetOfDemo();
        CopyDemo();
        UnionDemo();
        IntersectDemo();
        ToFromXmlDemo();
        Console.WriteLine("Press the Enter key to exit.");
        Console.ReadLine();
    }
    // IsSubsetOf determines whether the current permission is a subset of the specified permission.
    //<Snippet2>
    private static void IsSubsetOfDemo()
    {
        ReflectionPermission memberAccessPerm = new ReflectionPermission(ReflectionPermissionFlag.MemberAccess);
        //<Snippet8>
        ReflectionPermission restrictedMemberAccessPerm = new ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess);
        //</Snippet8>

        if (restrictedMemberAccessPerm.IsSubsetOf(memberAccessPerm))
        {
            Console.WriteLine(restrictedMemberAccessPerm.Flags + " is a subset of " +
                memberAccessPerm.Flags);
        }
        else
        {
            Console.WriteLine(restrictedMemberAccessPerm.Flags + " is not a subset of " +
                memberAccessPerm.Flags);
        }
    }
    //</Snippet2>
    // Union creates a new permission that is the union of the current permission and the specified permission.
    //<Snippet3>
    private static void UnionDemo()
    {
        ReflectionPermission memberAccessPerm = new ReflectionPermission(ReflectionPermissionFlag.MemberAccess);
        ReflectionPermission restrictedMemberAccessPerm = new ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess);
        ReflectionPermission reflectionPerm3 = (ReflectionPermission)memberAccessPerm.Union(restrictedMemberAccessPerm);
        if (reflectionPerm3 == null)
        {
            Console.WriteLine("The union of " + memberAccessPerm.Flags + " and " +
                restrictedMemberAccessPerm.Flags + " is null.");
        }
        else
        {
            Console.WriteLine("The union of " + memberAccessPerm.Flags + " and " +
                restrictedMemberAccessPerm.Flags + " = " +
                ((ReflectionPermission)reflectionPerm3).Flags.ToString());
        }

    }
    //</Snippet3>
    // Intersect creates and returns a new permission that is the intersection of the current
    // permission and the permission specified.
    //<Snippet4>
    private static void IntersectDemo()
    {
        ReflectionPermission memberAccessPerm = new ReflectionPermission(ReflectionPermissionFlag.MemberAccess);
        ReflectionPermission restrictedMemberAccessPerm = new ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess);
        ReflectionPermission reflectionPerm3 = (ReflectionPermission)memberAccessPerm.Intersect(restrictedMemberAccessPerm);
        if (reflectionPerm3 != null)
        {
            Console.WriteLine("The intersection of " + memberAccessPerm.Flags +
                " and " + restrictedMemberAccessPerm.Flags + " = " +
                ((ReflectionPermission)reflectionPerm3).Flags.ToString());
        }
        else
        {
            Console.WriteLine("The intersection of " + memberAccessPerm.Flags + " and " +
                restrictedMemberAccessPerm.Flags + " is null.");
        }

    }
    //</Snippet4>
    //Copy creates and returns an identical copy of the current permission.
    //<Snippet5>
    private static void CopyDemo()
    {
        ReflectionPermission memberAccessPerm = new ReflectionPermission(ReflectionPermissionFlag.MemberAccess);
        ReflectionPermission restrictedMemberAccessPerm = (ReflectionPermission)memberAccessPerm.Copy();
        Console.WriteLine("Result of copy = " + restrictedMemberAccessPerm.ToString());
    }
    //</Snippet5>
    // ToXml creates an XML encoding of the permission and its current state;
    // FromXml reconstructs a permission with the specified state from the XML encoding.
    //<Snippet6>
    private static void ToFromXmlDemo()
    {
        ReflectionPermission memberAccessPerm = new ReflectionPermission(ReflectionPermissionFlag.MemberAccess);
        //<Snippet7>
        ReflectionPermission restrictedMemberAccessPerm = new ReflectionPermission(PermissionState.None);
        //</Snippet7>
        restrictedMemberAccessPerm.FromXml(memberAccessPerm.ToXml());
        Console.WriteLine("Result of ToFromXml = " +
            restrictedMemberAccessPerm.ToString());
    }
    //</Snippet6>
}

// This code example creates the following output:

//RestrictedMemberAccess is not a subset of MemberAccess
//Result of copy = <IPermission class="System.Security.Permissions.ReflectionPermi
//ssion, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0
//89"
//version="1"
//Flags="MemberAccess"/>

//The union of MemberAccess and RestrictedMemberAccess = MemberAccess, RestrictedM
//emberAccess
//The intersection of MemberAccess and RestrictedMemberAccess is null.
//Result of ToFromXml = <IPermission class="System.Security.Permissions.Reflection
//Permission, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561
//934e089"
//version="1"
//Flags="MemberAccess"/>

//Press the Enter key to exit.

//</Snippet1>


