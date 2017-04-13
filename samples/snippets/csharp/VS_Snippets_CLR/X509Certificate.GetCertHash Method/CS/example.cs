// <Snippet1>

using System;
using System.Security.Cryptography.X509Certificates;


public class X509
{

    public static void Main()
    {

        // The path to the certificate.
        string Certificate =  "Certificate.cer";

        // Load the certificate into an X509Certificate object.
        X509Certificate cert = X509Certificate.CreateFromCertFile(Certificate);

        // Get the value.
        byte[] results = cert.GetCertHash();
      
    }

}
// </Snippet1>