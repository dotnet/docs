using System;
using System.Security.Cryptography;

class Members
{
    static void Main(string[] args)
    {
        // Create a CryptoConfig object to store configuration information.
        CryptoConfig cryptoConfig = new CryptoConfig();

        // Retrieve the class path for CryptoConfig.
        string classDescription = cryptoConfig.ToString();

        // Create a new SHA1 provider.
        SHA1CryptoServiceProvider SHA1alg = 
            (SHA1CryptoServiceProvider)CryptoConfig.CreateFromName("SHA1");

        // Create an RSAParameters with the TestContainer key container.
        CspParameters parameters = new CspParameters();
        parameters.KeyContainerName = "TestContainer";
        Object[] argsArray = new Object[] {parameters};

        // Instantiate the RSA provider instance accessing the TestContainer
        // key container.
        RSACryptoServiceProvider rsaProvider = (RSACryptoServiceProvider) 
            CryptoConfig.CreateFromName("RSA",argsArray);

        // Use the MapNameToOID method to get an object identifier  
        // (OID) from the string name of the SHA1 algorithm.
        string sha1Oid = CryptoConfig.MapNameToOID("SHA1");

        // Encode the specified object identifier.
        byte[] encodedMessage = CryptoConfig.EncodeOID(sha1Oid);

        // Display the results to the console.
        Console.WriteLine("** " + classDescription + " **");
        Console.WriteLine("Created an RSA provider " + 
            "with a KeyContainerName called " + parameters.KeyContainerName +
            ".");
        Console.WriteLine("Object identifier from the SHA1 name:" + sha1Oid);
        Console.WriteLine("The object identifier encoded: " + 
            System.Text.Encoding.ASCII.GetString(encodedMessage));
        Console.WriteLine("This sample completed successfully; " +
            "press Enter to exit.");
        Console.ReadLine();
    }
}
//
// This sample produces the following output:
//
// ** System.Security.Cryptography.CryptoConfig **
// Created an RSA provider with a KeyContainerName called TestContainer.
// Object identifier from the SHA1 name:1.3.14.3.2.26
// The object identifier encoded: HH*((*H9
// This sample completed successfully; press Enter to exit.