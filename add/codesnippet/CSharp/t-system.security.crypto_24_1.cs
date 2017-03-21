using System;
using System.IO;
using System.Xml;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;

class Class1
{
    [STAThread]
    static void Main(string[] args)
    {
        // Encrypt an XML message
        EncryptXML(LoadXMLDoc());

        // Using XmlDsigBase64Transform resolving a Uri.
        Uri baseUri = new Uri("http://www.microsoft.com");
        string relativeUri = "msdn";
        Uri absoluteUri = ResolveUris(baseUri, relativeUri);

        Console.WriteLine("This sample completed successfully; " +
            "press Enter to exit.");
        Console.ReadLine();
    }

    // Encrypt the text in the specified XmlDocument.
    private static void EncryptXML(XmlDocument xmlDoc)
    {
        XmlDsigBase64Transform xmlTransform = new XmlDsigBase64Transform();

        // Ensure the transform is using the proper algorithm.
        xmlTransform.Algorithm = SignedXml.XmlDsigBase64TransformUrl;

        // Retrieve the XML representation of the current transform.
        XmlElement xmlInTransform = xmlTransform.GetXml();

        Console.WriteLine("Xml representation of the current transform: ");
        Console.WriteLine(xmlInTransform.OuterXml);

        // Retrieve the valid input types for the current transform.
        Type[] validInTypes = xmlTransform.InputTypes;

        // Verify the xmlTransform can accept the XMLDocument as an
        // input type.
        for (int i=0; i<validInTypes.Length; i++)
        {
            if (validInTypes[i] == xmlDoc.GetType())
            {
                // Demonstrate loading the entire Xml Document.
                xmlTransform.LoadInput(xmlDoc);

                // This transform is created for demonstration purposes.
                XmlDsigBase64Transform secondTransform =
                    new XmlDsigBase64Transform();

                string classDescription = secondTransform.ToString();

                // This call does not perform as expected.
                // LoadInnerXml is overridden by the XmlDsigBase64Transform
                // class, but is stubbed out.
                secondTransform.LoadInnerXml(xmlDoc.SelectNodes("//."));

                break;
            }
        }

        Type[] validOutTypes = xmlTransform.OutputTypes;

        for (int i=0; i<validOutTypes.Length; i++)
        {
            if (validOutTypes[i] == typeof(System.IO.Stream))
            {
                try 
                {
                    Type streamType = typeof(System.IO.Stream);
                    CryptoStream outputStream = (CryptoStream) 
                        xmlTransform.GetOutput(streamType);

                    // Read the CryptoStream into a stream reader.
                    StreamReader streamReader =
                        new StreamReader(outputStream);

                    // Read the stream into a string.
                    string outputMessage = streamReader.ReadToEnd();

                    // Close the streams.
                    outputStream.Close();
                    streamReader.Close();

                    // Display to the console the Xml before and after
                    // encryption.
                    Console.WriteLine("Encoding the following message: " +
                        xmlDoc.InnerText);
                    Console.WriteLine("Message encoded: " + outputMessage);
            }
                catch (Exception ex)
                {
                    Console.WriteLine("Unexpected exception caught: " +
                        ex.ToString());
                }

                break;
            }
            else
            {
                object outputObject = xmlTransform.GetOutput();
            }
        }
    }

    // Create an XML document with Element and Text nodes.
    private static XmlDocument LoadXMLDoc()
    {
        XmlDocument xmlDoc = new XmlDocument();

        XmlNode mainNode = xmlDoc.CreateNode(
            XmlNodeType.Element,
            "ContosoMessages",
            "http://www.contoso.com");

        XmlNode textNode = xmlDoc.CreateTextNode("Some text to encode.");
        mainNode.AppendChild(textNode);
        xmlDoc.AppendChild(mainNode);

        Console.WriteLine("Created the following XML Document for " +
            "transformation: ");
        Console.WriteLine(xmlDoc.InnerXml);
        return xmlDoc;
    }

    // Resolve the specified base and relative Uri's .
    private static Uri ResolveUris(Uri baseUri, string relativeUri)
    {
        XmlUrlResolver xmlResolver = new XmlUrlResolver();
        xmlResolver.Credentials = 
            System.Net.CredentialCache.DefaultCredentials;

        XmlDsigBase64Transform xmlTransform = new XmlDsigBase64Transform();
        xmlTransform.Resolver = xmlResolver;

        Uri absoluteUri = xmlResolver.ResolveUri(baseUri, relativeUri);

        if (absoluteUri != null)
        {
            Console.WriteLine(
                "Resolved the base Uri and relative Uri to the following:");
            Console.WriteLine(absoluteUri.ToString());
        }
        else
        {
            Console.WriteLine(
                "Unable to resolve the base Uri and relative Uri");
        }
        return absoluteUri;
    }
}
//
// This sample produces the following output:
//
// Created the following XML Document for transformation:
// <ContosoMessages xmlns="http://www.contoso.com">Some text to encode.
// </ContosoMessages>
// Xml representation of the current transform:
// <Transform Algorithm="http://www.w3.org/2000/09/xmldsig#base64" xmlns=
// "http://www.w3.org/2000/09/xmldsig#" />
// Encoding the following message: Some text to encode.
// Message encoded: Jmr^
// Resolved the base Uri and relative Uri to the following:
// http://www.microsoft.com/msdn
// This sample completed successfully; press Enter to exit.