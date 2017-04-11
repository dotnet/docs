

//<SNIPPET1>
#using <System.Xml.dll>
#using <System.Security.dll>
#using <System.dll>

using namespace System;
using namespace System::Security::Cryptography::Xml;
using namespace System::Xml;
using namespace System::IO;

/// This sample used the GetXml method in the CipherReference class to 
/// write the XML values for the CipherReference to the console.

[STAThread]
int main()
{
   
   //Create a URI string.
   String^ uri = "http://www.woodgrovebank.com/document.xml";
   
   // Create a Base64 transform. The input content retrieved from the
   // URI should be Base64-decoded before other processing.
   Transform^ base64 = gcnew XmlDsigBase64Transform;
   
   //Create a transform chain and add the transform to it.
   TransformChain^ tc = gcnew TransformChain;
   tc->Add( base64 );
   
   //Create <CipherReference> information.
   CipherReference ^ reference = gcnew CipherReference( uri,tc );
   
   // Write the CipherReference value to the console.
   Console::WriteLine( "Cipher Reference data: {0}", reference->GetXml()->OuterXml );
}

//</SNIPPET1>
