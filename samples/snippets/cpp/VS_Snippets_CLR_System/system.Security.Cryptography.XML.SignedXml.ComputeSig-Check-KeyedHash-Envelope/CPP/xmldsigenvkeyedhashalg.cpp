

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
using namespace System::Security::Cryptography::X509Certificates;
using namespace System::Security::Cryptography::Xml;
using namespace System::Text;
using namespace System::Xml;

// Sign an XML file and save the signature in a new file.
void SignXmlFile( String^ FileName, String^ SignedFileName, KeyedHashAlgorithm^ Key )
{
   
   // Create a new XML document.
   XmlDocument^ doc = gcnew XmlDocument;
   
   // Format the document to ignore white spaces.
   doc->PreserveWhitespace = false;
   
   // Load the passed XML file using its name.
   doc->Load( gcnew XmlTextReader( FileName ) );
   
   // Create a SignedXml object.
   SignedXml^ signedXml = gcnew SignedXml( doc );
   
   // Create a reference to be signed.
   Reference^ reference = gcnew Reference;
   reference->Uri = "";
   
   // Add an enveloped transformation to the reference.
   XmlDsigEnvelopedSignatureTransform^ env = gcnew XmlDsigEnvelopedSignatureTransform;
   reference->AddTransform( env );
   
   // Add the reference to the SignedXML object.
   signedXml->AddReference( reference );
   
   // Compute the signature.
   signedXml->ComputeSignature( Key );
   
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


// Verify the signature of an XML file and return the result.
Boolean VerifyXmlFile( String^ Name, KeyedHashAlgorithm^ Key )
{
   
   // Create a new XML document.
   XmlDocument^ xmlDocument = gcnew XmlDocument;
   
   // Format using whitespaces.
   xmlDocument->PreserveWhitespace = true;
   
   // Load the passed XML file into the document. 
   xmlDocument->Load( Name );
   
   // Create a new SignedXMl object and pass it
   // the XMl document class.
   SignedXml^ signedXml = gcnew SignedXml( xmlDocument );
   
   // Find the "Signature" node and create a new
   // XmlNodeList object.
   XmlNodeList^ nodeList = xmlDocument->GetElementsByTagName( "Signature" );
   
   // Load the signature node.
   signedXml->LoadXml( safe_cast<XmlElement^>(nodeList->Item( 0 )) );
   
   // Check the signature and return the result.
   return signedXml->CheckSignature( Key );
}


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
   
   // Save the XML document to the filename specified.
   XmlTextWriter^ xmltw = gcnew XmlTextWriter( FileName,gcnew UTF8Encoding( false ) );
   document->WriteTo( xmltw );
   xmltw->Close();
}

int main()
{
   try
   {
      
      // Generate a signing key.
      HMACSHA1^ Key = gcnew HMACSHA1;
      
      // Create an XML file to sign.
      CreateSomeXml( "Example.xml" );
      Console::WriteLine( "New XML file created." );
      
      // Sign the XML that was just created and save it in a 
      // new file.
      SignXmlFile( "Example.xml", "SignedExample.xml", Key );
      Console::WriteLine( "XML file signed." );
      
      // Verify the signature of the signed XML.
      Console::WriteLine( "Verifying Signature..." );
      bool result = VerifyXmlFile( "SignedExample.xml", Key );
      
      // Display the results of the signature verification to \
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

   return 0;
}

// </Snippet1>
