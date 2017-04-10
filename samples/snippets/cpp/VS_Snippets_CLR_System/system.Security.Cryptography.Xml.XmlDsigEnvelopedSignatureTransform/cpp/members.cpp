//<Snippet2>
#using <System.dll>
#using <System.Xml.dll>
#using <System.Security.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Security::Cryptography;
using namespace System::Security::Cryptography::Xml;
using namespace System::Security::Cryptography::X509Certificates;

public ref class EnvelopedSignatureSample
{
private:
    static String^ Certificate =  "..\\..\\my509.cer";

    // Encrypt the text in the specified XmlDocument.
public:
    static void ShowTransformProperties(XmlDocument^ xmlDoc)
    {
        //<Snippet1>
        XmlDsigEnvelopedSignatureTransform^ xmlTransform =
            gcnew XmlDsigEnvelopedSignatureTransform();
        //</Snippet1>

        // Ensure the transform is using the proper algorithm.
        //<Snippet4>
        xmlTransform->Algorithm =
            SignedXml::XmlDsigEnvelopedSignatureTransformUrl;
        //</Snippet4>

        // Retrieve the XML representation of the current transform.
        //<Snippet10>
        XmlElement^ xmlInTransform = xmlTransform->GetXml();
        //</Snippet10>

        Console::WriteLine("\nXml representation of the current transform: ");
        Console::WriteLine(xmlInTransform->OuterXml);

        // Retrieve the valid input types for the current transform.
        //<Snippet5>
        array<Type^>^ validInTypes = xmlTransform->InputTypes;
        //</Snippet5>

        // Verify the xmlTransform can accept the XMLDocument as an
        // input type.
        for (int i = 0; i < validInTypes->Length; i++)
        {
            if (validInTypes[i] == xmlDoc->GetType())
            {
                // Load the document into the transfrom.
                //<Snippet12>
                xmlTransform->LoadInput(xmlDoc);
                //</Snippet12>

                //<Snippet3>
                bool IncludeComments = true;
                // This transform is created for demonstration purposes.
                XmlDsigEnvelopedSignatureTransform^ secondTransform =
                    gcnew XmlDsigEnvelopedSignatureTransform(IncludeComments);
                //</Snippet3>

                //<Snippet13>
                String^ classDescription = secondTransform->ToString();
                //</Snippet13>

                // This call does not perform as expected.
                //<Snippet11>
                // An enveloped signature has no inner XML elements
                secondTransform->LoadInnerXml(xmlDoc->SelectNodes("//."));
                //</Snippet11>

                break;
            }
        }

        //<Snippet6>
        array<Type^>^ validOutTypes = xmlTransform->OutputTypes;
        //</Snippet6>

        for (int i = validOutTypes->Length-1; i >= 0; i--)
        {
            if (validOutTypes[i] == System::Xml::XmlDocument::typeid)
            {
                //<Snippet9>
                Type^ xmlDocumentType = System::Xml::XmlDocument::typeid;
                XmlDocument^ xmlDocumentOutput = (XmlDocument^)
                    xmlTransform->GetOutput(xmlDocumentType);
                //</Snippet9>

                // Display to the console the Xml before and after
                // encryption.
                Console::WriteLine("Result of the GetOutput method call" +
                    " from the current transform: " +
                    xmlDocumentOutput->OuterXml);

                break;
            }
            else if (validOutTypes[i] == System::Xml::XmlNodeList::typeid)
            {
                Type^ xmlNodeListType = System::Xml::XmlNodeList::typeid;
                XmlNodeList^ xmlNodes = (XmlNodeList^)
                    xmlTransform->GetOutput(xmlNodeListType);

                // Display to the console the Xml before and after
                // encryption.
                Console::WriteLine("Encoding the following message: " +
                    xmlDoc->InnerText);

                Console::WriteLine("Nodes of the XmlNodeList retrieved " +
                    "from GetOutput:");
                for (int j = 0; j < xmlNodes->Count; j++)
                {
                    Console::WriteLine("Node " + j +
                        " has the following name: " +
                        xmlNodes->Item(j)->Name +
                        " and the following InnerXml: " +
                        xmlNodes->Item(j)->InnerXml);
                }

                break;
            }
            else
            {
                //<Snippet8>
                Object^ outputObject = xmlTransform->GetOutput();
                //</Snippet8>
            }
        }
    }

    // Create an XML document describing various products.
public:
    static XmlDocument^ LoadProducts()
    {
        XmlDocument^ xmlDoc = gcnew XmlDocument();

        String^ contosoProducts = "<PRODUCTS>" +
            "<PRODUCT><ID>123</ID><DESCRIPTION>Router" + 
            "</DESCRIPTION></PRODUCT>" +
            "<PRODUCT><ID>456</ID><DESCRIPTION>Keyboard" +
            "</DESCRIPTION></PRODUCT>" +
            "<PRODUCT><ID>789</ID><DESCRIPTION>Monitor" +
            "</DESCRIPTION></PRODUCT>" +
            "</PRODUCTS>";

        xmlDoc->LoadXml(contosoProducts);
        return xmlDoc;
    }

    // Create a signature and add it to the specified document.
public:
    static void SignDocument(XmlDocument^ xmlDoc)
    {
        // Generate a signing key.
        RSACryptoServiceProvider^ key = gcnew RSACryptoServiceProvider();

        // Create a SignedXml object.
        SignedXml^ signedDocument = gcnew SignedXml(xmlDoc);

        // Add the key to the SignedXml document.
        signedDocument->SigningKey = key;

        // Create a reference to be signed.
        Reference^ referenceToBeSigned = gcnew Reference();
        referenceToBeSigned->Uri = "";

        // Add an enveloped transformation to the reference.
        referenceToBeSigned->AddTransform(
            gcnew XmlDsigEnvelopedSignatureTransform());

        // Add the reference to the SignedXml object.
        signedDocument->AddReference(referenceToBeSigned);

        if(File::Exists(Certificate))
        {
            // Create a new KeyInfo object.
            KeyInfo^ info = gcnew KeyInfo();

            // Load the X509 certificate.
            X509Certificate^ certFromFile =
                X509Certificate::CreateFromCertFile(Certificate);

            // Load the certificate into a KeyInfoX509Data object
            // and add it to the KeyInfo object.
            info->AddClause(gcnew KeyInfoX509Data(certFromFile));

            // Add the KeyInfo object to the SignedXml object.
            signedDocument->KeyInfo = info;
        }
        else
        {
            Console::WriteLine("Unable to locate the following file: " +
                Certificate);
        }

        // Compute the signature.
        signedDocument->ComputeSignature();

        // Add the signature branch to the original tree so it is enveloped.
        xmlDoc->DocumentElement->AppendChild(signedDocument->GetXml());
    }

    // Resolve the specified base and relative Uri's .
public:
    static Uri^ ResolveUris(Uri^ baseUri, String^ relativeUri)
    {
        //<Snippet7>
        XmlUrlResolver^ xmlResolver = gcnew XmlUrlResolver();
        xmlResolver->Credentials =
            System::Net::CredentialCache::DefaultCredentials;

        XmlDsigEnvelopedSignatureTransform^ xmlTransform =
            gcnew XmlDsigEnvelopedSignatureTransform();
        xmlTransform->Resolver = xmlResolver;
        //</Snippet7>

        Uri^ absoluteUri = xmlResolver->ResolveUri(baseUri, relativeUri);

        if (absoluteUri != nullptr)
        {
            Console::WriteLine(
                "\nResolved the base Uri and relative Uri to the following:");
            Console::WriteLine(absoluteUri->ToString());
        }
        else
        {
            Console::WriteLine(
                "Unable to resolve the base Uri and relative Uri");
        }
        return absoluteUri;
    }
};

[STAThread]
int main()
{
    // Encrypt an XML message
    XmlDocument^ productsXml = EnvelopedSignatureSample::LoadProducts();
    EnvelopedSignatureSample::ShowTransformProperties(productsXml);

    EnvelopedSignatureSample::SignDocument(productsXml);
    EnvelopedSignatureSample::ShowTransformProperties(productsXml);

    // Use XmlDsigEnvelopedSignatureTransform to resolve a Uri.
    Uri^ baseUri = gcnew Uri("http://www.contoso.com");
    String^ relativeUri = "xml";
    Uri^ absoluteUri = 
        EnvelopedSignatureSample::ResolveUris(baseUri, relativeUri);

    Console::WriteLine("This sample completed successfully; " +
        "press Enter to exit.");
    Console::ReadLine();
}

//
// This sample produces the following output:
//
// Xml representation of the current transform:
// <Transform Algorithm="http://www.w3.org/2000/09/xmldsig#enveloped-
// signature" xmlns="http://www.w3.org/2000/09/xmldsig#" />
// Result of the GetOutput method call from the current transform: <PRODUCTS>
// <PRODUCT><ID>123</ID><DESCRIPTION>Router</DESCRIPTION></PRODUCT><PRODUCT>
// <ID>456</ID><DESCRIPTION>Keyboard</DESCRIPTION></PRODUCT><PRODUCT><ID>789
// </ID><DESCRIPTION>Monitor</DESCRIPTION></PRODUCT></PRODUCTS>
// Unable to load the following file: ..\\my509.cer
//
// Xml representation of the current transform:
// <Transform Algorithm="http://www.w3.org/2000/09/xmldsig#enveloped-
// signature" xmlns="http://www.w3.org/2000/09/xmldsig#" />
// Result of the GetOutput method call from the current transform: <PRODUCTS>
// <PRODUCT><ID>123</ID><DESCRIPTION>Router</DESCRIPTION></PRODUCT><PRODUCT>
// <ID>456</ID><DESCRIPTION>Keyboard</DESCRIPTION></PRODUCT><PRODUCT><ID>789
// </ID><DESCRIPTION>Monitor</DESCRIPTION></PRODUCT><Signature xmlns=
// "http://www.w3.org/2000/09/xmldsig#"><SignedInfo><CanonicalizationMethod
// Algorithm="http://www.w3.org/TR/2001/REC-xml-c14n-20010315" />
// <SignatureMethod Algorithm="http://www.w3.org/2000/09/xmldsig#rsa-sha1" />
// <Reference URI=""><Transforms><Transform Algorithm="http://www.w3.org/2000
// /09/xmldsig#enveloped-signature" /></Transforms><DigestMethod Algorithm=
// "http://www.w3.org/2000/09/xmldsig#sha1" /><DigestValue>KvPW6HUiIUMEDS0YSoT
// gpo2JPbA=</DigestValue></Reference></SignedInfo><SignatureValue>c/njCGDru/a
// WAmWG83I+mWO040xOzxvmNx0b0o8ZyPc9j5VwApdAt103OGBtB1H6EkOvt7Ekw+PVuUo8m5LzLP
// yaTxUDMbb2kZZ5itSkGD4rmMUMUMuzrkAoquJZjxeOydBJ2CMehV2rE3RMPLIwRX176DZVy5JKU
// 6Cb7PR2Rpw=</SignatureValue></Signature></PRODUCTS>
//
// Resolved the base Uri and relative Uri to the following:
// http://www.contoso.com/xml
// This sample completed successfully; press Enter to exit.
//</Snippet2>
