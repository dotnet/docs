//<SNIPPET1> 
using System;
using System.Security.Cryptography.X509Certificates;


class X509
{

    static void Main()
    {

        // The path to the certificate.
        string Certificate = "Certificate.cer";

        // Load the certificate into an X509Certificate object.
        X509Certificate cert = new X509Certificate();

        cert.Import(Certificate);

        // Get the value.
        string resultsTrue = cert.ToString(true);

        // Display the value to the console.
        Console.WriteLine(resultsTrue);

        // Get the value.
        string resultsFalse = cert.ToString(false);

        // Display the value to the console.
        Console.WriteLine(resultsFalse);

    }

}
//</SNIPPET1> 