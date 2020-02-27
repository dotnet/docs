//<Snippet2>
#using <System.dll>
#using <System.Xml.dll>
#using <System.Security.dll>

using namespace System;
using namespace System::IO;
using namespace System::Xml;
using namespace System::Security::Cryptography;
using namespace System::Security::Cryptography::Xml;

namespace CryptographyXmlDsigBase64Transform
{
    ref class Example
    {
    public:
        static void Produce()
        {
            
            // Encrypt an XML message
            EncryptXML(LoadXMLDoc());
            
            // Using XmlDsigBase64Transform resolving a Uri.
            Uri^ baseUri = gcnew Uri("http://www.microsoft.com");
            String^ relativeUri = "msdn";
            Uri^ absoluteUri = ResolveUris(baseUri, relativeUri);
            Console::WriteLine("This sample completed successfully; "
                "press Enter to exit.");
            Console::ReadLine();
        }


    private:

        // Encrypt the text in the specified XmlDocument.
        static void EncryptXML(XmlDocument^ xmlDoc)
        {
            
            //<Snippet1>
            XmlDsigBase64Transform^ xmlTransform = 
                gcnew XmlDsigBase64Transform;
            //</Snippet1>
            // Ensure the transform is using the proper algorithm.
            //<Snippet3>
            xmlTransform->Algorithm = 
                SignedXml::XmlDsigBase64TransformUrl;
            //</Snippet3>
            // Retrieve the XML representation of the current 
            // transform.
            //<Snippet9>
            XmlElement^ xmlInTransform = xmlTransform->GetXml();
            //</Snippet9>
            Console::WriteLine("Xml representation of the " 
                "current transform: ");
            Console::WriteLine(xmlInTransform->OuterXml);
            
            // Retrieve the valid input types for the current 
            // transform.
            //<Snippet4>
            array<Type^>^ validInTypes = xmlTransform->InputTypes;
            //</Snippet4>
            // Verify the xmlTransform can accept the XMLDocument
            // as an input type.
            for each (Type^ validInType in validInTypes)
            {
                if (validInType == xmlDoc->GetType())
                {
                    
                    // Demonstrate loading the entire Xml Document.
                    //<Snippet11>
                    xmlTransform->LoadInput(xmlDoc);
                    //</Snippet11>
                    // This transform is created for demonstration 
                    // purposes.
                    XmlDsigBase64Transform^ secondTransform = 
                        gcnew XmlDsigBase64Transform;
                    //<Snippet12>
                    String^ classDescription = 
                        secondTransform->ToString();
                    //</Snippet12>
                    // This call does not perform as expected.
                    // LoadInnerXml is overridden by the 
                    // XmlDsigBase64Transform class, but is 
                    // stubbed out.
                    //<Snippet10>
                    secondTransform->LoadInnerXml(
                        xmlDoc->SelectNodes("//."));
                    //</Snippet10>
                    break;
                }

            }
            
            //<Snippet5>
            array<Type^>^ validOutTypes = xmlTransform->OutputTypes;
            //</Snippet5>
            for each (Type^ validOutType in validOutTypes)
            {
                if (validOutType == Stream::typeid)
                {
                    try
                    {
                        
                        //<Snippet8>
                        Type^ streamType = Stream::typeid;
                        CryptoStream^ outputStream = 
                            (CryptoStream^)(xmlTransform->GetOutput(
							streamType));
                        //</Snippet8>
                        // Read the CryptoStream into a stream reader.
                        StreamReader^ streamReader = 
                            gcnew StreamReader(outputStream);
                        
                        // Read the stream into a string.
                        String^ outputMessage = 
                            streamReader->ReadToEnd();
                        
                        // Close the streams.
                        outputStream->Close();
                        streamReader->Close();
                        
                        // Display to the console the Xml before and
                        // after encryption.
                        Console::WriteLine("Encoding the following "
                            "message: {0}", xmlDoc->InnerText);
                        Console::WriteLine("Message encoded: {0}", 
                            outputMessage);
                    }
                    catch (CryptographicException^ ex) 
                    {
                        Console::WriteLine("Cryptographic exception "
                            "caught: {0}", ex);
                    }

                    break;
                }
                else
                {
                    
                    //<Snippet7>
                    Object^ outputObject = xmlTransform->GetOutput();
                    //</Snippet7>
                }

            }
        }


        // Create an XML document with Element and Text nodes.
        static XmlDocument^ LoadXMLDoc()
        {
            XmlDocument^ xmlDoc = gcnew XmlDocument;
            XmlNode^ mainNode = 
                xmlDoc->CreateNode(XmlNodeType::Element, 
                "ContosoMessages", "http://www.contoso.com");
            XmlNode^ textNode = xmlDoc->CreateTextNode("Some text "
                "to encode.");
            mainNode->AppendChild(textNode);
            xmlDoc->AppendChild(mainNode);
            Console::WriteLine("Created the following XML Document "
                "for transformation: ");
            Console::WriteLine(xmlDoc->InnerXml);
            return xmlDoc;
        }


        // Resolve the specified base and relative Uri's.
        static Uri^ ResolveUris(Uri^ baseUri, String^ relativeUri)
        {
            
            //<Snippet6>
            XmlUrlResolver^ xmlResolver = gcnew XmlUrlResolver;
            xmlResolver->Credentials = 
                System::Net::CredentialCache::DefaultCredentials;
            XmlDsigBase64Transform^ xmlTransform = 
                gcnew XmlDsigBase64Transform;
            xmlTransform->Resolver = xmlResolver;
            //</Snippet6>
            Uri^ absoluteUri = xmlResolver->ResolveUri(baseUri, 
                relativeUri);
            if (absoluteUri != nullptr)
            {
                Console::WriteLine("Resolved the base Uri and "
                    "relative Uri to the following:");
                Console::WriteLine(absoluteUri);
            }
            else
            {
                Console::WriteLine("Unable to resolve the base "
                    "Uri and relative Uri");
            }

            return absoluteUri;
        }

    };

}

int main()
{
    CryptographyXmlDsigBase64Transform::Example::Produce();
}

//
// This sample produces the following output:
//
// Created the following XML Document for transformation:
// <ContosoMessages xmlns="http://www.contoso.com">Some text to encode.
// </ContosoMessages>
// Xml representation of the current transform:
// <Transform Algorithm="http://www.w3.org/2000/09/xmldsig#base64"
// xmlns="http://www.w3.org/2000/09/xmldsig#" />
// Encoding the following message: Some text to encode.
// Message encoded: Jmr^
// Resolved the base Uri and relative Uri to the following:
// http://www.microsoft.com/msdn
// This sample completed successfully; press Enter to exit.
//</Snippet2>
