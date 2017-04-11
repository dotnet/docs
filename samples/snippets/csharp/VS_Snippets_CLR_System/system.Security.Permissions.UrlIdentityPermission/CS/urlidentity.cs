// <Snippet1>
using System;
using System.Security;
using System.Security.Permissions;

public class UrlIdentityPermissionDemo
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
        UrlIdentityPermission permIdPerm1 = new UrlIdentityPermission("http://www.fourthcoffee.com/process/");
        //</Snippet8>
        UrlIdentityPermission permIdPerm2 = new UrlIdentityPermission("http://www.fourthcoffee.com/*");

        if (permIdPerm1.IsSubsetOf(permIdPerm2))
        {
            Console.WriteLine(permIdPerm1.Url + " is a subset of " + permIdPerm2.Url);
        }
        else
        {
            Console.WriteLine(permIdPerm1.Url + " is not a subset of " + permIdPerm2.Url);

        }
        if (permIdPerm2.IsSubsetOf(permIdPerm1))
        {
            Console.WriteLine(permIdPerm2.Url + " is a subset of " + permIdPerm1.Url);
        }
        else
        {
            Console.WriteLine(permIdPerm2.Url + " is not a subset of " + permIdPerm1.Url);

        }
    }
    // </Snippet2>
    // <Snippet3>
    // Union creates a new permission that is the union of the current permission
    // and the specified permission.
    private static void UnionDemo()
    {
        UrlIdentityPermission permIdPerm1 = new UrlIdentityPermission("http://www.fourthcoffee.com/process/");
        UrlIdentityPermission permIdPerm2 = new UrlIdentityPermission("http://www.fourthcoffee.com/*");
        UrlIdentityPermission p3 = (UrlIdentityPermission)permIdPerm1.Union(permIdPerm2);
        try
        {
            if (p3 != null)
            {
                Console.WriteLine("The union of " + permIdPerm1.Url +
                    " and \n\t" + permIdPerm2.Url + " is \n\t"
                    + p3.Url + "\n");

            }
            else
            {
                Console.WriteLine("The union of " + permIdPerm1.Url +
                    " and \n\t" + permIdPerm2.Url + " is null.\n");
            }
        }
        catch (SystemException e)
        {
            Console.WriteLine("The union of " + permIdPerm1.Url +
                    " and \n\t" + permIdPerm2.Url + " failed.");

            Console.WriteLine(e.Message);
        }

    }
    // </Snippet3>
    // <Snippet4>
    // Intersect creates and returns a new permission that is the intersection of the
    // current permission and the permission specified.
    private static void IntersectDemo()
    {

        UrlIdentityPermission permIdPerm1 = new UrlIdentityPermission("http://www.fourthcoffee.com/process/");
        UrlIdentityPermission permIdPerm2 = new UrlIdentityPermission("http://www.fourthcoffee.com/*");
        UrlIdentityPermission p3 = (UrlIdentityPermission)permIdPerm1.Intersect(permIdPerm2);

        if (p3 != null)
        {
            Console.WriteLine("The intersection of " + permIdPerm1.Url + " and \n\t" +
                permIdPerm2.Url + " is " + p3.Url + "\n");

        }
        else
        {
            Console.WriteLine("The intersection of " + permIdPerm1.Url +
                " and \n\t" + permIdPerm2.Url + " is null.\n");
        }


    }
    //</Snippet4>
    //<Snippet5>
    //Copy creates and returns an identical copy of the current permission.
    private static void CopyDemo()
    {

        UrlIdentityPermission permIdPerm1 = new UrlIdentityPermission("http://www.fourthcoffee.com/process/*");
        //<Snippet7>
        UrlIdentityPermission permIdPerm2 = new UrlIdentityPermission(PermissionState.None);
        //</Snippet7>
        permIdPerm2 = (UrlIdentityPermission)permIdPerm1.Copy();
        if (permIdPerm2 != null)
        {
            Console.WriteLine("The copy succeeded:  " + permIdPerm2.ToString() + " \n");
        }

    }
    //</Snippet5>
    //<Snippet6>
    // ToXml creates an XML encoding of the permission and its current state; FromXml reconstructs a
    // permission with the specified state from the XML encoding.
    private static void ToFromXmlDemo()
    {


        UrlIdentityPermission permIdPerm1 = new UrlIdentityPermission("http://www.fourthcoffee.com/process/*");
        UrlIdentityPermission permIdPerm2 = new UrlIdentityPermission(PermissionState.None);
        permIdPerm2.FromXml(permIdPerm1.ToXml());
        bool result = permIdPerm2.Equals(permIdPerm1);
        if (result)
        {
            Console.WriteLine("Result of ToFromXml = " + permIdPerm2.ToString());
        }
        else
        {
            Console.WriteLine(permIdPerm2.ToString());
            Console.WriteLine(permIdPerm1.ToString());
        }

    }
    //</Snippet6>

}

// </Snippet1>
// This code example creates the following output:

//http://www.fourthcoffee.com/process/ is a subset of http://www.fourthcoffee.com/
//*
//http://www.fourthcoffee.com/* is not a subset of http://www.fourthcoffee.com/pro
//cess/
//The copy succeeded:  <IPermission class="System.Security.Permissions.UrlIdentity
//Permission, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561
//934e089"
//version="1"
//Url="http://www.fourthcoffee.com/process/*"/>


//The union of http://www.fourthcoffee.com/process/ and
//        http://www.fourthcoffee.com/* failed.
//The operation is ambiguous because the permission represents multiple identities
//.
//The intersection of http://www.fourthcoffee.com/process/ and
//        http://www.fourthcoffee.com/* is http://www.fourthcoffee.com/process/

//Result of ToFromXml = <IPermission class="System.Security.Permissions.UrlIdentit
//yPermission, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c56
//1934e089"
//version="1"
//Url="http://www.fourthcoffee.com/process/*"/>