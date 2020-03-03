

//<Snippet1>
#using <System.dll>
#using <System.Xml.dll>
#using <System.Security.dll>

using namespace System;
using namespace System::IO;
using namespace System::Security::Cryptography;
using namespace System::Security::Cryptography::Xml;
using namespace System::Xml;
int main()
{
   
   // Create example data to sign.
   XmlDocument^ document = gcnew XmlDocument;
   XmlNode^ node = document->CreateNode( XmlNodeType::Element, "", "MyElement", "samples" );
   node->InnerText = "This is some text";
   document->AppendChild( node );
   Console::Error->WriteLine( "Data to sign:\n{0}\n", document->OuterXml );
   
   // Create the SignedXml message.
   SignedXml^ signedXml = gcnew SignedXml;
   RSA^ key = RSA::Create();
   signedXml->SigningKey = key;
   
   // Create a data object to hold the data to sign.
   DataObject^ dataObject = gcnew DataObject;
   dataObject->Data = document->ChildNodes;
   dataObject->Id = "MyObjectId";
   
   // Add the data object to the signature.
   signedXml->AddObject( dataObject );
   
   // Create a reference to be able to package everything into the
   // message.
   Reference^ reference = gcnew Reference;
   reference->Uri = "#MyObjectId";
   
   // Add it to the message.
   signedXml->AddReference( reference );
   
   // Add a KeyInfo.
   KeyInfo^ keyInfo = gcnew KeyInfo;
   keyInfo->AddClause( gcnew RSAKeyValue( key ) );
   signedXml->KeyInfo = keyInfo;
   
   // Compute the signature.
   signedXml->ComputeSignature();
   
   // Get the XML representation of the signature.
   XmlElement^ xmlSignature = signedXml->GetXml();
   Console::WriteLine( xmlSignature->OuterXml );
}

//</Snippet1>
