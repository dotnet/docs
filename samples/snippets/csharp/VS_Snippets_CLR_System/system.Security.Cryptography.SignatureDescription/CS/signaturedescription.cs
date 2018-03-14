// This sample demonstrates how to use each member of the SignatureDescription
// class.
//<Snippet2>
using System;
using System.Security;
using System.Security.Cryptography;

class SignatureDescriptionImpl
{
    [STAThread]
    static void Main(string[] args)
    {
        // Create a digital signature based on RSA encryption.
        SignatureDescription rsaSignature = CreateRSAPKCS1Signature();
        ShowProperties(rsaSignature);

        // Create a digital signature based on DSA encryption.
        SignatureDescription dsaSignature = CreateDSASignature();
        ShowProperties(dsaSignature);

        // Create a HashAlgorithm using the digest algorithm of the signature.
        //<Snippet10>
        HashAlgorithm hashAlgorithm = dsaSignature.CreateDigest();
        //</Snippet10>
        Console.WriteLine("\nHash algorithm for the DigestAlgorithm property:"
            + " " + hashAlgorithm.ToString());

        // Create an AsymmetricSignatureFormatter instance using the DSA key.
        DSA dsa = DSA.Create();
        AsymmetricSignatureFormatter asymmetricFormatter =
            CreateDSAFormatter(dsa);
        
        // Create an AsymmetricSignatureDeformatter instance using the
        // DSA key.
        AsymmetricSignatureDeformatter asymmetricDeformatter =
            CreateDSADeformatter(dsa);

        Console.WriteLine("This sample completed successfully; " +
            "press Enter to exit.");
        Console.ReadLine();
    }

    // Create a SignatureDescription for RSA encryption.
    private static SignatureDescription CreateRSAPKCS1Signature()
    {
        //<Snippet1>
        SignatureDescription signatureDescription = 
            new SignatureDescription();
        //</Snippet1>

        // Set the key algorithm property for RSA encryption.
        //<Snippet7>
        signatureDescription.KeyAlgorithm =
            "System.Security.Cryptography.RSACryptoServiceProvider";
        //</Snippet7>

        // Set the digest algorithm for RSA encryption using the
        // SHA1 provider.
        //<Snippet6>
        signatureDescription.DigestAlgorithm =
            "System.Security.Cryptography.SHA1CryptoServiceProvider";
        //</Snippet6>

        // Set the formatter algorithm with the RSAPKCS1 formatter.
        //<Snippet9>
        signatureDescription.FormatterAlgorithm =
            "System.Security.Cryptography.RSAPKCS1SignatureFormatter";
        //</Snippet9>

        // Set the formatter algorithm with the RSAPKCS1 deformatter.
        //<Snippet8>
        signatureDescription.DeformatterAlgorithm =
            "System.Security.Cryptography.RSAPKCS1SignatureDeformatter";
        //</Snippet8>

        return signatureDescription;
    }

    // Create a SignatureDescription using a constructed SecurityElement for 
    // DSA encryption.
    private static SignatureDescription CreateDSASignature()
    {
        //<Snippet3>
        SecurityElement securityElement = new SecurityElement("DSASignature");

        // Create new security elements for the four algorithms.
        securityElement.AddChild(new SecurityElement(
            "Key",
            "System.Security.Cryptography.DSACryptoServiceProvider"));
        securityElement.AddChild(new SecurityElement(
            "Digest",
            "System.Security.Cryptography.SHA1CryptoServiceProvider")); 
        securityElement.AddChild(new SecurityElement(
            "Formatter",
            "System.Security.Cryptography.DSASignatureFormatter"));
        securityElement.AddChild(new SecurityElement(
            "Deformatter",
            "System.Security.Cryptography.DSASignatureDeformatter"));

        SignatureDescription signatureDescription = 
            new SignatureDescription(securityElement);
        //</Snippet3>

        return signatureDescription;
    }

    // Create a signature formatter for DSA encryption.
    private static AsymmetricSignatureFormatter CreateDSAFormatter(DSA dsa)
    {
        // Create a DSA signature formatter for encryption.
        //<Snippet5>
        SignatureDescription signatureDescription = 
            new SignatureDescription();
        signatureDescription.FormatterAlgorithm =
            "System.Security.Cryptography.DSASignatureFormatter";

        AsymmetricSignatureFormatter asymmetricFormatter =
            signatureDescription.CreateFormatter(dsa);
        //</Snippet5>

        Console.WriteLine("\nCreated formatter : " + 
            asymmetricFormatter.ToString());
        return asymmetricFormatter;
    }

    // Create a signature deformatter for DSA decryption.
    private static AsymmetricSignatureDeformatter CreateDSADeformatter(
        DSA dsa)
    {
        // Create a DSA signature deformatter to verify the signature.
        //<Snippet4>
        SignatureDescription signatureDescription = 
            new SignatureDescription();
        signatureDescription.DeformatterAlgorithm =
            "System.Security.Cryptography.DSASignatureDeformatter";

        AsymmetricSignatureDeformatter asymmetricDeformatter =
            signatureDescription.CreateDeformatter(dsa);
        //</Snippet4>

        Console.WriteLine("\nCreated deformatter : " + 
            asymmetricDeformatter.ToString());
        return asymmetricDeformatter;
    }

    // Display to the console the properties of the specified
    // SignatureDescription.
    private static void ShowProperties(
        SignatureDescription signatureDescription)
    {
        // Retrieve the class path for the specified SignatureDescription.
        //<Snippet11>
        string classDescription = signatureDescription.ToString();
        //</Snippet11>

        string deformatterAlgorithm = 
            signatureDescription.DeformatterAlgorithm;
        string formatterAlgorithm = signatureDescription.FormatterAlgorithm;
        string digestAlgorithm = signatureDescription.DigestAlgorithm;
        string keyAlgorithm = signatureDescription.KeyAlgorithm;

        Console.WriteLine("\n** " + classDescription + " **");
        Console.WriteLine("DeformatterAlgorithm : " + deformatterAlgorithm);
        Console.WriteLine("FormatterAlgorithm : " + formatterAlgorithm);
        Console.WriteLine("DigestAlgorithm : " + digestAlgorithm);
        Console.WriteLine("KeyAlgorithm : " + keyAlgorithm);
    }
}
//
// This sample produces the following output:
// 
// ** System.Security.Cryptography.SignatureDescription **
// DeformatterAlgorithm : System.Security.Cryptography.
// RSAPKCS1SignatureDeformatter
// 
// FormatterAlgorithm : System.Security.Cryptography.
// RSAPKCS1SignatureFormatter
// DigestAlgorithm : System.Security.Cryptography.SHA1CryptoServiceProvider
// KeyAlgorithm : System.Security.Cryptography.RSACryptoServiceProvider
// 
// ** System.Security.Cryptography.SignatureDescription **
// DeformatterAlgorithm : System.Security.Cryptography.DSASignatureDeformatter
// FormatterAlgorithm : System.Security.Cryptography.DSASignatureFormatter
// DigestAlgorithm : System.Security.Cryptography.SHA1CryptoServiceProvider
// KeyAlgorithm : System.Security.Cryptography.DSACryptoServiceProvider
// 
// Hash algorithm for the DigestAlgorithm property: 
// System.Security.Cryptography.SH
// A1CryptoServiceProvider
// 
// Created formatter : System.Security.Cryptography.DSASignatureFormatter
// 
// Created deformatter : System.Security.Cryptography.DSASignatureDeformatter
// This sample completed successfully; press Enter to exit.
//</Snippet2>