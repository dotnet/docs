//<SNIPPET1> 
using System;
using System.Security.Cryptography.X509Certificates;


public class X509
{

    public static void Main()
    {

        // The path to the certificate.
        string Certificate = "test.pfx";

        // Load the certificate into an X509Certificate object.
        X509Certificate cert = new X509Certificate(Certificate);


        byte[] certData = cert.Export(X509ContentType.Cert);

        X509Certificate newCert = new X509Certificate(certData);

        // Get the value.
        string resultsTrue = newCert.ToString(true);

        // Display the value to the console.
        Console.WriteLine(resultsTrue);

        // Get the value.
        string resultsFalse = newCert.ToString(false);

        // Display the value to the console.
        Console.WriteLine(resultsFalse);

    }

}
//</SNIPPET1> 