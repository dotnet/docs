
//<SNIPPET1> 
//
// This example signs an XML file using an
// envelope signature. It then verifies the 
// signed XML.
//
#using <System.Xml.dll>
#using <System.Security.dll>
#using <System.dll>

using namespace System;
using namespace System::Security::Cryptography;
using namespace System::Security::Cryptography::X509Certificates;
using namespace System::Security::Cryptography::Xml;
using namespace System::Text;
using namespace System::Xml;

// Create the XML that represents the transform.
static XmlDsigXPathTransform^ CreateXPathTransform( String^ XPathString )
{
   
   // Create a new XMLDocument object.
   XmlDocument^ doc = gcnew XmlDocument;
   
   // Create a new XmlElement.
   XmlElement^ xPathElem = doc->CreateElement( L"XPath" );
   
   // Set the element text to the value
   // of the XPath string.
   xPathElem->InnerText = XPathString;
   
   // Create a new XmlDsigXPathTransform object.
   XmlDsigXPathTransform^ xForm = gcnew XmlDsigXPathTransform;
   
   // Load the XPath XML from the element. 
   xForm->LoadInnerXml( xPathElem->SelectNodes( L"." ) );
   
   // Return the XML that represents the transform.
   return xForm;
}


// Sign an XML file and save the signature in a new file.
static void SignXmlFile( String^ FileName, String^ SignedFileName, RSA^ Key, String^ XPathString )
{
   
   // Create a new XML document.
   XmlDocument^ doc = gcnew XmlDocument;
   
   // Format the document to ignore white spaces.
   doc->PreserveWhitespace = false;
   
   // Load the passed XML file using it's name.
   doc->Load( gcnew XmlTextReader( FileName ) );
   
   // Create a SignedXml object.
   SignedXml^ signedXml = gcnew SignedXml( doc );
   
   // Add the key to the SignedXml document. 
   signedXml->SigningKey = Key;
   
   // Create a reference to be signed.
   Reference^ reference = gcnew Reference;
   reference->Uri = L"";
   
   // Create an XmlDsigXPathTransform object using 
   // the helper method 'CreateXPathTransform' defined
   // later in this sample.
   XmlDsigXPathTransform^ XPathTransform = CreateXPathTransform( XPathString );
   
   // Add the transform to the reference.
   reference->AddTransform( XPathTransform );
   
   // Add the reference to the SignedXml object.
   signedXml->AddReference( reference );
   
   // Add an RSAKeyValue KeyInfo (optional; helps recipient find key to validate).
   KeyInfo^ keyInfo = gcnew KeyInfo;
   keyInfo->AddClause( gcnew RSAKeyValue( dynamic_cast<RSA^>(Key) ) );
   signedXml->KeyInfo = keyInfo;
   
   // Compute the signature.
   signedXml->ComputeSignature();
   
   // Get the XML representation of the signature and save
   // it to an XmlElement object.
   XmlElement^ xmlDigitalSignature = signedXml->GetXml();
   
   // Append the element to the XML document.
   doc->DocumentElement->AppendChild( doc->ImportNode( xmlDigitalSignature, true ) );
   
   // Save the signed XML document to a file specified
   // using the passed string.
   XmlTextWriter^ xmltw = gcnew XmlTextWriter( SignedFileName,gcnew UTF8Encoding( false ) );
   doc->WriteTo( xmltw );
   xmltw->Close();
}


// Verify the signature of an XML file and return the result.
static Boolean VerifyXmlFile( String^ Name )
{
   
   // Create a new XML document.
   XmlDocument^ xmlDocument = gcnew XmlDocument;
   
   // Format using white spaces.
   xmlDocument->PreserveWhitespace = true;
   
   // Load the passed XML file into the document. 
   xmlDocument->Load( Name );
   
   // Create a new SignedXml object and pass it
   // the XML document class.
   SignedXml^ signedXml = gcnew SignedXml( xmlDocument );
   
   // Find the "Signature" node and create a new
   // XmlNodeList object.
   XmlNodeList^ nodeList = xmlDocument->GetElementsByTagName( L"Signature" );
   
   // Load the signature node.
   signedXml->LoadXml( dynamic_cast<XmlElement^>(nodeList->Item( 0 )) );
   
   // Check the signature and return the result.
   return signedXml->CheckSignature();
}


// Create example data to sign.
static void CreateSomeXml( String^ FileName )
{
   
   // Create a new XmlDocument object.
   XmlDocument^ document = gcnew XmlDocument;
   
   // Create a new XmlNode object.
   XmlNode^ node = document->CreateNode( XmlNodeType::Element, L"", L"MyXML", L"Don't_Sign" );
   
   // Append the node to the document.
   document->AppendChild( node );
   
   // Create a new XmlNode object.
   XmlNode^ subnode = document->CreateNode( XmlNodeType::Element, L"", L"TempElement", L"Sign" );
   
   // Add some text to the node.
   subnode->InnerText = L"Here is some data to sign.";
   
   // Append the node to the document.
   document->DocumentElement->AppendChild( subnode );
   
   // Save the XML document to the file name specified.
   XmlTextWriter^ xmltw = gcnew XmlTextWriter( FileName,gcnew UTF8Encoding( false ) );
   document->WriteTo( xmltw );
   xmltw->Close();
}

int main()
{
   
   // Generate a signing key.
   RSACryptoServiceProvider^ Key = gcnew RSACryptoServiceProvider;
   try
   {
      
      // Create an XML file to sign.
      CreateSomeXml( L"Example.xml" );
      Console::WriteLine( L"New XML file created." );
      
      // Sign the XML that was just created and save it in a 
      // new file.
      SignXmlFile( L"Example.xml", L"SignedExample.xml", Key, L"ancestor-or-self::TempElement" );
      Console::WriteLine( L"XML file signed." );
      
      // Verify the signature of the signed XML.
      Console::WriteLine( L"Verifying signature..." );
      bool result = VerifyXmlFile( L"SignedExample.xml" );
      
      // Display the results of the signature verification to \
      // the console.
      if ( result )
      {
         Console::WriteLine( L"The XML signature is valid." );
      }
      else
      {
         Console::WriteLine( L"The XML signature is not valid." );
      }
   }
   catch ( CryptographicException^ e ) 
   {
      Console::WriteLine( e->Message );
   }
   finally
   {
      Key->Clear();
   }

   return 1;
}

//</SNIPPET1>
