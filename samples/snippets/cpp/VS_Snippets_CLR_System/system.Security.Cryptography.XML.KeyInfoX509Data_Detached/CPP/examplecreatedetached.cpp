

// <Snippet1>
//
// This example signs a file specified by a URI 
// using a detached signature. It then verifies  
// the signed XML.
//
#using <System.Security.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Security::Cryptography;
using namespace System::Security::Cryptography::Xml;
using namespace System::Security::Cryptography::X509Certificates;
using namespace System::Text;
using namespace System::Xml;

// <Snippet2>
// Sign an XML file and save the signature in a new file.
void SignDetachedResource( String^ URIString, String^ XmlSigFileName, RSA^ Key, String^ Certificate )
{
   
   // Create a SignedXml object.
   SignedXml^ signedXml = gcnew SignedXml;
   
   // Assign the key to the SignedXml object.
   signedXml->SigningKey = Key;
   
   // Create a reference to be signed.
   Reference^ reference = gcnew Reference;
   
   // Add the passed URI to the reference object.
   reference->Uri = URIString;
   
   // Add the reference to the SignedXml object.
   signedXml->AddReference( reference );
   
   // Create a new KeyInfo object.
   KeyInfo^ keyInfo = gcnew KeyInfo;
   
   // Load the X509 certificate.
   X509Certificate^ MSCert = X509Certificate::CreateFromCertFile( Certificate );
   
   // Load the certificate into a KeyInfoX509Data object
   // and add it to the KeyInfo object.
   keyInfo->AddClause( gcnew KeyInfoX509Data( MSCert ) );
   
   // Add the KeyInfo object to the SignedXml object.
   signedXml->KeyInfo = keyInfo;
   
   // Compute the signature.
   signedXml->ComputeSignature();
   
   // Get the XML representation of the signature and save
   // it to an XmlElement object.
   XmlElement^ xmlDigitalSignature = signedXml->GetXml();
   
   // Save the signed XML document to a file specified
   // using the passed string.
   XmlTextWriter^ xmltw = gcnew XmlTextWriter( XmlSigFileName,gcnew UTF8Encoding( false ) );
   xmlDigitalSignature->WriteTo( xmltw );
   xmltw->Close();
}


// </Snippet2>

[STAThread]
int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   
   // The URI to sign.
   String^ resourceToSign = "http://www.microsoft.com";
   
   // The name of the file to which to save the XML signature.
   String^ XmlFileName = "xmldsig.xml";
   
   // The name of the X509 certificate
   String^ Certificate = "microsoft.cer";
   try
   {
      
      // Generate a signing key. This key should match the certificate.
      RSACryptoServiceProvider^ Key = gcnew RSACryptoServiceProvider;
      Console::WriteLine( "Signing: {0}", resourceToSign );
      
      // Sign the detached resource and save the signature in an XML file.
      SignDetachedResource( resourceToSign, XmlFileName, Key, Certificate );
      Console::WriteLine( "XML signature was succesfully computed and saved to {0}.", XmlFileName );
   }
   catch ( CryptographicException^ e ) 
   {
      Console::WriteLine( e->Message );
   }

}

// </Snippet1>
