//<Snippet1>
// To execute this sample you will need two certification files, MyCert1.cer and MyCert2.cer.
// The certification files can be created using the Certification Creation Tool, MakeCert.exe.
using System;
using System.Security;
using System.Security.Permissions;
using System.Security.Cryptography.X509Certificates;
using System.IO;

public class PublisherIdentityPermissionDemo
{
    private static X509Certificate[] publisherCertificate = new X509Certificate[2];
    private static PublisherIdentityPermission publisherPerm1;
    private static PublisherIdentityPermission publisherPerm2;
    // Demonstrate all methods.
    public static void Main(String[] args)
    {
        // Initialize the PublisherIdentityPermissions for use in the sample
        //<Snippet8>
        FileStream fs1 = new FileStream("..\\..\\..\\MyCert1.cer", FileMode.Open);
        Byte[] certSBytes1 = new Byte[(int)fs1.Length];
        fs1.Read(certSBytes1, 0, (int)fs1.Length);
        publisherCertificate[0] = new X509Certificate(certSBytes1);
        fs1.Close();
        FileStream fs2 = new FileStream("..\\..\\..\\MyCert2.cer", FileMode.Open);
        Byte[] certSBytes2 = new Byte[(int)fs2.Length];
        fs2.Read(certSBytes2, 0, (int)fs2.Length);
        publisherCertificate[1] = new X509Certificate(certSBytes2);
        fs2.Close();

        publisherPerm1 = new PublisherIdentityPermission(publisherCertificate[0]);
        publisherPerm2 = new PublisherIdentityPermission(publisherCertificate[1]);
        //</Snippet8>

        IsSubsetOfDemo();
        CopyDemo();
        UnionDemo();
        IntersectDemo();
        ToFromXmlDemo();

    }
    // IsSubsetOf determines whether the current permission is a subset of the specified permission.
    //<Snippet2>
    private static void IsSubsetOfDemo()
    {

        if (publisherPerm2.IsSubsetOf(publisherPerm1))
        {
            Console.WriteLine(publisherPerm2.Certificate.Subject + " is a subset of " +
                publisherPerm1.Certificate.Subject);
        }
        else
        {
            Console.WriteLine(publisherPerm2.Certificate.Subject + " is not a subset of " +
                publisherPerm1.Certificate.Subject);
        }
    }
    //</Snippet2>
    // Union creates a new permission that is the union of the current permission and the specified permission.
    //<Snippet3>
    private static void UnionDemo()
    {
        PublisherIdentityPermission publisherPerm3 = (PublisherIdentityPermission)publisherPerm1.Union(publisherPerm2);
        if (publisherPerm3 == null)
        {
            Console.WriteLine("The union of " + publisherPerm1 + " and " +
                publisherPerm2.Certificate.Subject + " is null.");
        }
        else
        {
            Console.WriteLine("The union of " + publisherPerm1.Certificate.Subject + " and " +
                publisherPerm2.Certificate.Subject + " = " +
                ((PublisherIdentityPermission)publisherPerm3).Certificate.Subject.ToString());
        }

    }
    //</Snippet3>
    // Intersect creates and returns a new permission that is the intersection of the current
    // permission and the permission specified.
    //<Snippet4>
    private static void IntersectDemo()
    {
        PublisherIdentityPermission publisherPerm3 = (PublisherIdentityPermission)publisherPerm1.Union(publisherPerm2);
        if (publisherPerm3 != null)
        {
            Console.WriteLine("The intersection of " + publisherPerm1.Certificate.Subject +
                " and " + publisherPerm2.Certificate.Subject + " = " +
                ((PublisherIdentityPermission)publisherPerm3).Certificate.Subject.ToString());
        }
        else
        {
            Console.WriteLine("The intersection of " + publisherPerm1.Certificate.Subject + " and " +
                publisherPerm2.Certificate.Subject + " is null.");
        }

    }
    //</Snippet4>
    //Copy creates and returns an identical copy of the current permission.
    //<Snippet5>
    private static void CopyDemo()
    {
        //<Snippet7>
        // Create an empty PublisherIdentityPermission to serve as the target of the copy.
        publisherPerm2 = new PublisherIdentityPermission(PermissionState.None);
        publisherPerm2 = (PublisherIdentityPermission)publisherPerm1.Copy();
        Console.WriteLine("Result of copy = " + publisherPerm2.ToString());
        //</Snippet7>
    }
    //</Snippet5>
    // ToXml creates an XML encoding of the permission and its current state;
    // FromXml reconstructs a permission with the specified state from the XML encoding.
    //<Snippet6>
    private static void ToFromXmlDemo()
    {
        publisherPerm2 = new PublisherIdentityPermission(PermissionState.None);
        publisherPerm2.FromXml(publisherPerm1.ToXml());
        Console.WriteLine("Result of ToFromXml = " +
            publisherPerm2.ToString());
    }
    //</Snippet6>
}

//</Snippet1>



