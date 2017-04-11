

//<SNIPPET4>
#using <System.Xml.dll>
#using <System.Security.dll>
#using <System.dll>

using namespace System;
using namespace System::Security::Cryptography::Xml;
using namespace System::Xml;
using namespace System::IO;

/// This sample used the EncryptedData class to create a EncryptedData element
/// and write it to an XML file.

[STAThread]
int main()
{
   
   //<SNIPPET3>
   //<SNIPPET1>
   // Create a new CipherData object using a byte array to represent encrypted data.
   array<Byte>^sampledata = gcnew array<Byte>(8);
   CipherData ^ cd = gcnew CipherData( sampledata );
   
   //</SNIPPET1>
   // Create a new EncryptedData object.
   EncryptedData^ ed = gcnew EncryptedData;
   
   //Add an encryption method to the object.
   ed->Id = "ED";
   ed->EncryptionMethod = gcnew EncryptionMethod( "http://www.w3.org/2001/04/xmlenc#aes128-cbc" );
   ed->CipherData = cd;
   
   //</SNIPPET3>
   //<SNIPPET2>
   //Add key information to the object.
   KeyInfo^ ki = gcnew KeyInfo;
   ki->AddClause( gcnew KeyInfoRetrievalMethod( "#EK","http://www.w3.org/2001/04/xmlenc#EncryptedKey" ) );
   ed->KeyInfo = ki;
   
   //</SNIPPET2>
   // Create new XML document and put encrypted data into it.
   XmlDocument^ doc = gcnew XmlDocument;
   XmlElement^ encryptionPropertyElement = dynamic_cast<XmlElement^>(doc->CreateElement( "EncryptionProperty", EncryptedXml::XmlEncNamespaceUrl ));
   EncryptionProperty ^ ep = gcnew EncryptionProperty( encryptionPropertyElement );
   ed->AddProperty( ep );
   
   // Output the resulting XML information into a file. Change the path variable to point to a directory where
   // the XML file should be written.
   String^ path = "c:\\test\\MyTest.xml";
   File::WriteAllText( path, ed->GetXml()->OuterXml );
}

//</SNIPPET4>
