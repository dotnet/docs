//<SNIPPET1>
#using <System.Xml.dll>
#using <System.Security.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Security::Cryptography;
using namespace System::Security::Cryptography::Xml;
using namespace System::IO;

/// This sample used the EncryptedData class to create a EncryptedData element
/// and write it to an XML file.
int main()
{
    //<SNIPPET2>
    // Create a new CipherData object.
    CipherData^ cipher = gcnew CipherData();
    // Assign a byte array to be the CipherValue. This is a
    // byte array representing encrypted data.
    cipher->CipherValue = gcnew array<Byte>(8);
    //</SNIPPET2>
    //<SNIPPET3>
    // Create a new EncryptedData object.
    EncryptedData^ encryptionRoot = gcnew EncryptedData();
    //</SNIPPET3>
    //Add an encryption method to the object.
    encryptionRoot->Id = "ED";
    encryptionRoot->EncryptionMethod = gcnew EncryptionMethod(
        "http://www.w3.org/2001/04/xmlenc#aes128-cbc");
    encryptionRoot->CipherData = cipher;

    //Add key information to the object.
    KeyInfo^ keyDetails = gcnew KeyInfo();
    keyDetails->AddClause(gcnew KeyInfoRetrievalMethod("#EK",
        "http://www.w3.org/2001/04/xmlenc#EncryptedKey"));
    encryptionRoot->KeyInfo = keyDetails;

    // Create new XML document and put encrypted data into it.
    XmlDocument^ doc = gcnew XmlDocument();
    XmlElement^ encryptionPropertyElement =
        doc->CreateElement("EncryptionProperty", 
        EncryptedXml::XmlEncNamespaceUrl);
    EncryptionProperty^ property = gcnew EncryptionProperty(
        encryptionPropertyElement);
    encryptionRoot->AddProperty(property);

    // Output the resulting XML information into a file.
    String^ path = "test.xml";
    try
    {
        File::WriteAllText(path, encryptionRoot->GetXml()->OuterXml);
    }
    catch (IOException^ ex)
    {
        Console::WriteLine("There was an error writing to {0}", path);
        Console::WriteLine(ex->Message);
    }
    //Console.WriteLine(ed.GetXml().OuterXml);
}

//</SNIPPET1>
