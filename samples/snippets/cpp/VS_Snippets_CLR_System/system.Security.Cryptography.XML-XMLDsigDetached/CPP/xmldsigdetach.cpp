

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
using namespace System::Text;
using namespace System::Xml;

// <Snippet2>
// Sign an XML file and save the signature in a new file.
void SignDetachedResource( String^ URIString, String^ XmlSigFileName, RSA^ Key )
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
   
   // Add an RSAKeyValue KeyInfo (optional; helps recipient find key to validate).
   KeyInfo^ keyInfo = gcnew KeyInfo;
   keyInfo->AddClause( gcnew RSAKeyValue( safe_cast<RSA^>(Key) ) );
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
// <Snippet3>
// Verify the signature of an XML file and return the result.
Boolean VerifyDetachedSignature( String^ XmlSigFileName )
{
   
   // Create a new XML document.
   XmlDocument^ xmlDocument = gcnew XmlDocument;
   
   // Load the passed XML file into the document.
   xmlDocument->Load( XmlSigFileName );
   
   // Create a new SignedXMl object.
   SignedXml^ signedXml = gcnew SignedXml;
   
   // Find the "Signature" node and create a new
   // XmlNodeList object.
   XmlNodeList^ nodeList = xmlDocument->GetElementsByTagName( "Signature" );
   
   // Load the signature node.
   signedXml->LoadXml( safe_cast<XmlElement^>(nodeList->Item( 0 )) );
   
   // Check the signature and return the result.
   return signedXml->CheckSignature();
}


// </Snippet3>

[STAThread]
int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   
   // The URI to sign.
   String^ resourceToSign = "http://www.microsoft.com";
   
   // The name of the file to which to save the XML signature.
   String^ XmlFileName = "xmldsig.xml";
   try
   {
      
      // Generate a signing key.
      RSACryptoServiceProvider^ Key = gcnew RSACryptoServiceProvider;
      Console::WriteLine( "Signing: {0}", resourceToSign );
      
      // Sign the detached resourceand save the signature in an XML file.
      SignDetachedResource( resourceToSign, XmlFileName, Key );
      Console::WriteLine( "XML signature was succesfully computed and saved to {0}.", XmlFileName );
      
      // Verify the signature of the signed XML.
      Console::WriteLine( "Verifying signature..." );
      
      //Verify the XML signature in the XML file.
      bool result = VerifyDetachedSignature( XmlFileName );
      
      // Display the results of the signature verification to 
      // the console.
      if ( result )
      {
         Console::WriteLine( "The XML signature is valid." );
      }
      else
      {
         Console::WriteLine( "The XML signature is not valid." );
      }
   }
   catch ( CryptographicException^ e ) 
   {
      Console::WriteLine( e->Message );
   }

}

// </Snippet1>
