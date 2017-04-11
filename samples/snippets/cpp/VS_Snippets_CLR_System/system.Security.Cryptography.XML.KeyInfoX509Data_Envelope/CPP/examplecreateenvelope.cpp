

// <Snippet1>
//
// This example signs an XML file using an
// envelope signature. It then verifies the 
// signed XML.
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
void SignXmlFile( String^ FileName, String^ SignedFileName, RSA^ Key, String^ Certificate )
{
   
   // Create a new XML document.
   XmlDocument^ doc = gcnew XmlDocument;
   
   // Format the document to ignore white spaces.
   doc->PreserveWhitespace = false;
   
   // Load the passed XML file using its name.
   doc->Load( gcnew XmlTextReader( FileName ) );
   
   // Create a SignedXml object.
   SignedXml^ signedXml = gcnew SignedXml( doc );
   
   // Add the key to the SignedXml document. 
   signedXml->SigningKey = Key;
   
   // Create a reference to be signed.
   Reference^ reference = gcnew Reference;
   reference->Uri = "";
   
   // Add an enveloped transformation to the reference.
   XmlDsigEnvelopedSignatureTransform^ env = gcnew XmlDsigEnvelopedSignatureTransform;
   reference->AddTransform( env );
   
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
   
   // Append the element to the XML document.
   doc->DocumentElement->AppendChild( doc->ImportNode( xmlDigitalSignature, true ) );
   if ( (doc->FirstChild)->GetType() == XmlDeclaration::typeid )
   {
      doc->RemoveChild( doc->FirstChild );
   }

   
   // Save the signed XML document to a file specified
   // using the passed string.
   XmlTextWriter^ xmltw = gcnew XmlTextWriter( SignedFileName,gcnew UTF8Encoding( false ) );
   doc->WriteTo( xmltw );
   xmltw->Close();
}


// </Snippet2>
// Create example data to sign.
void CreateSomeXml( String^ FileName )
{
   
   // Create a new XmlDocument object.
   XmlDocument^ document = gcnew XmlDocument;
   
   // Create a new XmlNode object.
   XmlNode^ node = document->CreateNode( XmlNodeType::Element, "", "MyElement", "samples" );
   
   // Add some text to the node.
   node->InnerText = "Example text to be signed.";
   
   // Append the node to the document.
   document->AppendChild( node );
   
   // Save the XML document to the file name specified.
   XmlTextWriter^ xmltw = gcnew XmlTextWriter( FileName,gcnew UTF8Encoding( false ) );
   document->WriteTo( xmltw );
   xmltw->Close();
}

int main()
{
   String^ Certificate = "microsoft.cer";
   try
   {
      
      // Generate a signing key.
      RSACryptoServiceProvider^ Key = gcnew RSACryptoServiceProvider;
      
      // Create an XML file to sign.
      CreateSomeXml( "Example.xml" );
      Console::WriteLine( "New XML file created." );
      
      // Sign the XML that was just created and save it in a 
      // new file.
      SignXmlFile( "Example.xml", "SignedExample.xml", Key, Certificate );
      Console::WriteLine( "XML file signed." );
   }
   catch ( CryptographicException^ e ) 
   {
      Console::WriteLine( e->Message );
   }

   return 0;
}

// </Snippet1>
