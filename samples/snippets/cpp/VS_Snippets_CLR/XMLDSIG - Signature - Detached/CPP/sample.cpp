//<SNIPPET1>
//
// This example signs a URL using an
// envelope signature. It then verifies the 
// signed XML.
//
#using <System.dll>
#using <System.Xml.dll>
#using <System.Security.dll>

using namespace System;
using namespace System::Security::Cryptography;
using namespace System::Security::Cryptography::Xml;
using namespace System::Text;
using namespace System::Xml;


namespace Sample
{
    public ref class SignVerifyEnvelope
    {
    public:
        static void Work()
        {
            // Generate a signing key.
            RSACryptoServiceProvider^ key = 
                gcnew RSACryptoServiceProvider();

            try
            {

                // Sign the detached resource and save the 
                // signature in an XML file.
                SignDetachedResource("http://www.microsoft.com",
                    "SignedExample.xml", key);

                Console::WriteLine("XML file signed.");

                // Verify the signature of the signed XML.
                Console::WriteLine("Verifying signature...");

                bool result = VerifyXmlFile("SignedExample.xml");

                // Display the results of the signature verification 
                // to the console.
                if (result)
                {
                    Console::WriteLine("The XML signature"
                        " is valid.");
                }
                else
                {
                    Console::WriteLine("The XML signature"
                        " is not valid.");
                }
                Console::ReadLine();
            }

            catch (CryptographicException^ ex)
            {
                Console::WriteLine(ex->Message);
            }
            finally
            {
                // Clear resources associated with the 
                // RSACryptoServiceProvider.
                key->Clear();
            }
        }


        // Sign an XML file and save the signature in a new file.
        static void SignDetachedResource(String^ uri, 
            String^ xmlFileName, RSA^ key)
        {
            // Check the arguments.  
            if (uri->Length == 0)
            {
                throw gcnew ArgumentException("uri");
            }
            if (xmlFileName->Length == 0)
            {
                throw gcnew ArgumentException("xmlFileName");
            } 
            if (key->KeySize == 0)
            {
                throw gcnew ArgumentException("key");
            }
            // Create a SignedXml object.
            SignedXml^ signedXml = gcnew SignedXml();

            // Assign the key to the SignedXml object.
            signedXml->SigningKey = key;

            // Get the signature object from the SignedXml object.
            Signature^ xmlSignature = signedXml->Signature;

            // Create a reference to be signed.
            Reference^ reference = gcnew Reference();

            // Add the passed URI to the reference object.
            reference->Uri = uri;

            // Add the Reference object to the Signature object.
            xmlSignature->SignedInfo->AddReference(reference);

            // Add an RSAKeyValue KeyInfo (optional; helps recipient
            // find key to validate).
            KeyInfo^ keyInfo = gcnew KeyInfo();
            keyInfo->AddClause(
                gcnew RSAKeyValue(key));

            // Add the KeyInfo object to the Reference object.
            xmlSignature->KeyInfo = keyInfo;

            // Compute the signature.
            signedXml->ComputeSignature();

            // Get the XML representation of the signature and save
            // it to an XmlElement object.
            XmlElement^ xmlDigitalSignature = signedXml->GetXml();

            // Save the signed XML document to a file specified
            // using the passed string.
            XmlTextWriter^ xmlTextWriter = gcnew XmlTextWriter(
                xmlFileName, gcnew UTF8Encoding(false));

            xmlDigitalSignature->WriteTo(xmlTextWriter);
            xmlTextWriter->Close();
        }


        // Verify the signature of an XML file and return the result.
        static Boolean VerifyXmlFile(String^ documentName)
        {
            // Check the arguments.  
            if (documentName->Length == 0)
            {
                throw gcnew ArgumentException("documentName");
            }
            // Create a new XML document.
            XmlDocument^ xmlDocument = gcnew XmlDocument();

            // Format using white spaces.
            xmlDocument->PreserveWhitespace = true;

            // Load the passed XML file into the document. 
            xmlDocument->Load(documentName);

            // Create a new SignedXml object and pass it
            // the XML document class.
            SignedXml^ signedXml = gcnew SignedXml(xmlDocument);

            // Find the "Signature" node and create a new
            // XmlNodeList object.
            XmlNodeList^ nodeList = 
                xmlDocument->GetElementsByTagName("Signature");

            // Load the signature node.
            signedXml->LoadXml(
                (XmlElement^) nodeList->Item(0));

            // Check the signature and return the result.
            return signedXml->CheckSignature();
        }
    };
}


int main()
{
    Sample::SignVerifyEnvelope::Work();
}
//</SNIPPET1>