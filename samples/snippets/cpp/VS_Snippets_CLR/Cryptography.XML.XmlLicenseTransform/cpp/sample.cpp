//<SNIPPET1>
#using <System.Xml.dll>
#using <System.Security.dll>
using namespace System;
using namespace System::Xml;
using namespace System::Security::Cryptography;
using namespace System::Security::Cryptography::Xml;

//<SNIPPET2>
void CheckSignatureWithEncryptedGrant(
    String^ fileName, IRelDecryptor^ decryptor)
{
    // Create a new XML document.
    XmlDocument^ sourceDocument = gcnew XmlDocument();
    XmlNamespaceManager^ namespaceManager =
        gcnew XmlNamespaceManager(sourceDocument->NameTable);

    // Format using whitespaces.
    sourceDocument->PreserveWhitespace = true;

    // Load the passed XML file into the document.
    sourceDocument->Load(fileName);
    namespaceManager->AddNamespace("dsig",
        SignedXml::XmlDsigNamespaceUrl);

    // Find the "Signature" node and create a new
    // XmlNodeList object.
    XmlNodeList^ nodeList = 
        sourceDocument->SelectNodes("//dsig:Signature", namespaceManager);

    for (int i = 0, count = nodeList->Count; i < count; i++)
    {
        XmlDocument^ clone = (XmlDocument^) sourceDocument->Clone();
        XmlNodeList^ signatures =
            clone->SelectNodes("//dsig:Signature", namespaceManager);

        // Create a new SignedXml object and pass into it the
        // XML document clone.
        SignedXml^ signedDocument = gcnew SignedXml(clone);

        // Load the signature node.
        signedDocument->LoadXml((XmlElement^)signatures[i]);

        // Set the context for license transform
        Transform^ licenseTransform = ((Reference^)signedDocument->
            SignedInfo->References[0])->TransformChain[0];

        if ((licenseTransform::typeid == XmlLicenseTransform::typeid) 
            && (decryptor != nullptr))
        {
            // Decryptor is used to decrypt encryptedGrant
            // elements.
            ((XmlLicenseTransform^) licenseTransform)->Decryptor = decryptor;
        }

        // Check the signature and display the result.
        if (signedDocument->CheckSignature())
        {
            Console::WriteLine("SUCCESS: " +
                "CheckSignatureWithEncryptedGrant - issuer index #" + i);
        }
        else
        {
            Console::WriteLine("FAILURE: " +
                "CheckSignatureWithEncryptedGrant - issuer index #" + i);
        }
    }
}
//</SNIPPET2>

int main()
{
}

//</SNIPPET1>
