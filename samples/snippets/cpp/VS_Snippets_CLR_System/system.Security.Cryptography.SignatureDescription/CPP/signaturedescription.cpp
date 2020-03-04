// This sample demonstrates how to use each member of the SignatureDescription
// class.
//<Snippet2>
using namespace System;
using namespace System::Security;
using namespace System::Security::Cryptography;

ref class SignatureDescriptionImpl
{
public:
   [STAThread]
   static void Main()
   {
      // Create a digital signature based on RSA encryption.
      SignatureDescription^ rsaSignature = CreateRSAPKCS1Signature();
      ShowProperties( rsaSignature );
      
      // Create a digital signature based on DSA encryption.
      SignatureDescription^ dsaSignature = CreateDSASignature();
      ShowProperties( dsaSignature );
      
      // Create a HashAlgorithm using the digest algorithm of the signature.
      //<Snippet10>
      HashAlgorithm^ hashAlgorithm = dsaSignature->CreateDigest();
      //</Snippet10>

      Console::WriteLine( L"\nHash algorithm for the DigestAlgorithm property:"
         L" {0}", hashAlgorithm );
      
      // Create an AsymmetricSignatureFormatter instance using the DSA key.
      DSA^ dsa = DSA::Create();
      AsymmetricSignatureFormatter^ asymmetricFormatter = CreateDSAFormatter( dsa );
      
      // Create an AsymmetricSignatureDeformatter instance using the
      // DSA key.
      AsymmetricSignatureDeformatter^ asymmetricDeformatter =
         CreateDSADeformatter( dsa );
      Console::WriteLine( L"This sample completed successfully; "
         L"press Enter to exit." );
      Console::ReadLine();
   }

private:
   // Create a SignatureDescription for RSA encryption.
   static SignatureDescription^ CreateRSAPKCS1Signature()
   {
      //<Snippet1>
      SignatureDescription^ signatureDescription = gcnew SignatureDescription;
      //</Snippet1>

      // Set the key algorithm property for RSA encryption.
      //<Snippet7>
      signatureDescription->KeyAlgorithm = L"System.Security.Cryptography.RSACryptoServiceProvider";
      //</Snippet7>

      // Set the digest algorithm for RSA encryption using the
      // SHA1 provider.
      //<Snippet6>
      signatureDescription->DigestAlgorithm = L"System.Security.Cryptography.SHA1CryptoServiceProvider";
      //</Snippet6>

      // Set the formatter algorithm with the RSAPKCS1 formatter.
      //<Snippet9>
      signatureDescription->FormatterAlgorithm = L"System.Security.Cryptography.RSAPKCS1SignatureFormatter";
      //</Snippet9>

      // Set the formatter algorithm with the RSAPKCS1 deformatter.
      //<Snippet8>
      signatureDescription->DeformatterAlgorithm = L"System.Security.Cryptography.RSAPKCS1SignatureDeformatter";
      //</Snippet8>

      return signatureDescription;
   }

   // Create a SignatureDescription using a constructed SecurityElement for
   // DSA encryption.
   static SignatureDescription^ CreateDSASignature()
   {
      //<Snippet3>
      SecurityElement^ securityElement = gcnew SecurityElement( L"DSASignature" );
      // Create new security elements for the four algorithms.
      securityElement->AddChild( gcnew SecurityElement(
         L"Key",L"System.Security.Cryptography.DSACryptoServiceProvider" ) );
      securityElement->AddChild( gcnew SecurityElement(
         L"Digest",L"System.Security.Cryptography.SHA1CryptoServiceProvider" ) );
      securityElement->AddChild( gcnew SecurityElement(
         L"Formatter",L"System.Security.Cryptography.DSASignatureFormatter" ) );
      securityElement->AddChild( gcnew SecurityElement(
         L"Deformatter",L"System.Security.Cryptography.DSASignatureDeformatter" ) );
      SignatureDescription^ signatureDescription =
         gcnew SignatureDescription( securityElement );
      //</Snippet3>

      return signatureDescription;
   }

   // Create a signature formatter for DSA encryption.
   static AsymmetricSignatureFormatter^ CreateDSAFormatter( DSA^ dsa )
   {
      // Create a DSA signature formatter for encryption.
      //<Snippet5>
      SignatureDescription^ signatureDescription =
         gcnew SignatureDescription;
      signatureDescription->FormatterAlgorithm =
         L"System.Security.Cryptography.DSASignatureFormatter";
      AsymmetricSignatureFormatter^ asymmetricFormatter =
         signatureDescription->CreateFormatter( dsa );
      //</Snippet5>

      Console::WriteLine( L"\nCreated formatter : {0}",
         asymmetricFormatter );
      return asymmetricFormatter;
   }

   // Create a signature deformatter for DSA decryption.
   static AsymmetricSignatureDeformatter^ CreateDSADeformatter( DSA^ dsa )
   {
      // Create a DSA signature deformatter to verify the signature.
      //<Snippet4>
      SignatureDescription^ signatureDescription =
         gcnew SignatureDescription;
      signatureDescription->DeformatterAlgorithm =
         L"System.Security.Cryptography.DSASignatureDeformatter";
      AsymmetricSignatureDeformatter^ asymmetricDeformatter =
         signatureDescription->CreateDeformatter( dsa );
      //</Snippet4>

      Console::WriteLine( L"\nCreated deformatter : {0}",
         asymmetricDeformatter );
      return asymmetricDeformatter;
   }

   // Display to the console the properties of the specified
   // SignatureDescription.
   static void ShowProperties( SignatureDescription^ signatureDescription )
   {
      // Retrieve the class path for the specified SignatureDescription.
      //<Snippet11>
      String^ classDescription = signatureDescription->ToString();
      //</Snippet11>

      String^ deformatterAlgorithm = signatureDescription->DeformatterAlgorithm;
      String^ formatterAlgorithm = signatureDescription->FormatterAlgorithm;
      String^ digestAlgorithm = signatureDescription->DigestAlgorithm;
      String^ keyAlgorithm = signatureDescription->KeyAlgorithm;
      Console::WriteLine( L"\n** {0} **", classDescription );
      Console::WriteLine( L"DeformatterAlgorithm : {0}", deformatterAlgorithm );
      Console::WriteLine( L"FormatterAlgorithm : {0}", formatterAlgorithm );
      Console::WriteLine( L"DigestAlgorithm : {0}", digestAlgorithm );
      Console::WriteLine( L"KeyAlgorithm : {0}", keyAlgorithm );
   }
};

int main()
{
   SignatureDescriptionImpl::Main();
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
