

//<SNIPPET1>
#using <System.Xml.dll>
#using <System.Security.dll>
#using <System.dll>

using namespace System;
using namespace System::Security::Cryptography::Xml;
using namespace System::Xml;
using namespace System::IO;

/// This sample used the EncryptedData class to create an encrypted data element
/// and write it to an XML file. It demonstrates the use of CipherReference.

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
   
   // Create a new CipherData object using the CipherReference information.
   // Note that you cannot assign both a CipherReference and a CipherValue
   // to a CipherData object.
   CipherData ^ cd = gcnew CipherData( reference );
   
   // Create a new EncryptedData object.
   EncryptedData^ ed = gcnew EncryptedData;
   
   //Add an encryption method to the object.
   ed->Id = "ED";
   ed->EncryptionMethod = gcnew EncryptionMethod( "http://www.w3.org/2001/04/xmlenc#aes128-cbc" );
   ed->CipherData = cd;
   
   //Add key information to the object.
   KeyInfo^ ki = gcnew KeyInfo;
   ki->AddClause( gcnew KeyInfoRetrievalMethod( "#EK","http://www.w3.org/2001/04/xmlenc#EncryptedKey" ) );
   ed->KeyInfo = ki;
   
   // Create new XML document and put encrypted data into it.
   XmlDocument^ doc = gcnew XmlDocument;
   XmlElement^ encryptionPropertyElement = dynamic_cast<XmlElement^>(doc->CreateElement( "EncryptionProperty", EncryptedXml::XmlEncNamespaceUrl ));
   EncryptionProperty ^ ep = gcnew EncryptionProperty( encryptionPropertyElement );
   ed->AddProperty( ep );
   
   // Output the resulting XML information into a file.
   try
   {
      String^ path = "c:\\test\\MyTest.xml";
      File::WriteAllText( path, ed->GetXml()->OuterXml );
   }
   catch ( IOException^ e ) 
   {
      Console::WriteLine( "File IO error. {0}", e );
   }

}

//</SNIPPET1>
