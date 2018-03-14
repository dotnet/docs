//<SNIPPET1>
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.IO;

public class X509store2
{
    public static void Main(string[] args)
    {
        //Opens the personal certificates store.
        X509Store store = new X509Store(StoreName.My);
        store.Open(OpenFlags.ReadWrite);
        X509Certificate2 certificate = new X509Certificate2();

        //Create certificates from certificate files.
        //You must put in a valid path to three certificates in the following constructors.
        X509Certificate2 certificate1 = new X509Certificate2("c:\\mycerts\\*****.cer");
        X509Certificate2 certificate2 = new X509Certificate2("c:\\mycerts\\*****.cer");
        X509Certificate2 certificate5 = new X509Certificate2("c:\\mycerts\\*****.cer");

        //Create a collection and add two of the certificates.
        X509Certificate2Collection collection = new X509Certificate2Collection();
        collection.Add(certificate2);
        collection.Add(certificate5);

        //Add certificates to the store.
        store.Add(certificate1);
        store.AddRange(collection);

        X509Certificate2Collection storecollection = (X509Certificate2Collection)store.Certificates;
        Console.WriteLine("Store name: {0}", store.Name);
        Console.WriteLine("Store location: {0}", store.Location);
        foreach (X509Certificate2 x509 in storecollection)
        {
            Console.WriteLine("certificate name: {0}", x509.Subject);
        }

        //Remove a certificate.
        store.Remove(certificate1);
        X509Certificate2Collection storecollection2 = (X509Certificate2Collection)store.Certificates;
        Console.WriteLine("{1}Store name: {0}", store.Name, Environment.NewLine);
        foreach (X509Certificate2 x509 in storecollection2)
        {
            Console.WriteLine("certificate name: {0}", x509.Subject);
        }

        //Remove a range of certificates.
        store.RemoveRange(collection);
        X509Certificate2Collection storecollection3 = (X509Certificate2Collection)store.Certificates;
        Console.WriteLine("{1}Store name: {0}", store.Name, Environment.NewLine);
        if (storecollection3.Count == 0)
        {
            Console.WriteLine("Store contains no certificates.");
        }
        else
        {
            foreach (X509Certificate2 x509 in storecollection3)
            {
                Console.WriteLine("certificate name: {0}", x509.Subject);
            }
        }

        //Close the store.
        store.Close();
    }
}
//</SNIPPET1>
