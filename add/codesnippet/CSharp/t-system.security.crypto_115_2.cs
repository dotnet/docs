using System;
using System.IO;
using System.Xml;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography.X509Certificates;

class Class1
{
    private static string Certificate =  "..\\..\\my509.cer";

    [STAThread]
    static void Main(string[] args)
    {
        // Encrypt an XML message
        XmlDocument productsXml = LoadProducts();
        ShowTransformProperties(productsXml);

        SignDocument(ref productsXml);
        ShowTransformProperties(productsXml);

        // Use XmlDsigEnvelopedSignatureTransform to resolve a Uri.
        Uri baseUri = new Uri("http://www.contoso.com");
        string relativeUri = "xml";
        Uri absoluteUri = ResolveUris(baseUri, relativeUri);

        Console.WriteLine("This sample completed successfully; " +
            "press Enter to exit.");
        Console.ReadLine();
    }

    // Encrypt the text in the specified XmlDocument.
    private static void ShowTransformProperties(XmlDocument xmlDoc)
    {
        XmlDsigEnvelopedSignatureTransform xmlTransform = 
            new XmlDsigEnvelopedSignatureTransform();

        // Ensure the transform is using the proper algorithm.
        xmlTransform.Algorithm =
            SignedXml.XmlDsigEnvelopedSignatureTransformUrl;

        // Retrieve the XML representation of the current transform.
        XmlElement xmlInTransform = xmlTransform.GetXml();

        Console.WriteLine("\nXml representation of the current transform: ");
        Console.WriteLine(xmlInTransform.OuterXml);

        // Retrieve the valid input types for the current transform.
        Type[] validInTypes = xmlTransform.InputTypes;

        // Verify the xmlTransform can accept the XMLDocument as an
        // input type.
        for (int i=0; i<validInTypes.Length; i++)
        {
            if (validInTypes[i] == xmlDoc.GetType())
            {
                // Load the document into the transfrom.
                xmlTransform.LoadInput(xmlDoc);

                bool IncludeComments = true;
                // This transform is created for demonstration purposes.
                XmlDsigEnvelopedSignatureTransform secondTransform =
                    new XmlDsigEnvelopedSignatureTransform(IncludeComments);

                string classDescription = secondTransform.ToString();

                // This call does not perform as expected.
                // An enveloped signature has no inner XML elements
                secondTransform.LoadInnerXml(xmlDoc.SelectNodes("//."));

                break;
            }
        }

        Type[] validOutTypes = xmlTransform.OutputTypes;

        for (int i=validOutTypes.Length-1; i >= 0; i--)
        {
            if (validOutTypes[i] == typeof(System.Xml.XmlDocument))
            {
                try 
                {
                    Type xmlDocumentType = typeof(System.Xml.XmlDocument);
                    XmlDocument xmlDocumentOutput = (XmlDocument) 
                        xmlTransform.GetOutput(xmlDocumentType);

                    // Display to the console the Xml before and after
                    // encryption.
                    Console.WriteLine("Result of the GetOutput method call" +
                        " from the current transform: " + 
                        xmlDocumentOutput.OuterXml);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unexpected exception caught: " +
                        ex.ToString());
                }

                break;
            }
            else if (validOutTypes[i] == typeof(System.Xml.XmlNodeList))
            {
                try 
                {
                    Type xmlNodeListType = typeof(System.Xml.XmlNodeList);
                    XmlNodeList xmlNodes = (XmlNodeList) 
                        xmlTransform.GetOutput(xmlNodeListType);

                    // Display to the console the Xml before and after
                    // encryption.
                    Console.WriteLine("Encoding the following message: " +
                        xmlDoc.InnerText);

                    Console.WriteLine("Nodes of the XmlNodeList retrieved " +
                        "from GetOutput:");
                    for (int j=0; j < xmlNodes.Count; j++)
                    {
                        Console.WriteLine("Node " + j + 
                            " has the following name: " + 
                            xmlNodes.Item(j).Name + 
                            " and the following InnerXml: " + 
                            xmlNodes.Item(j).InnerXml);
                    }
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

    // Create an XML document describing various products.
    private static XmlDocument LoadProducts()
    {
        XmlDocument xmlDoc = new XmlDocument();

        string contosoProducts = "<PRODUCTS>";
        contosoProducts += "<PRODUCT><ID>123</ID>";
        contosoProducts += "<DESCRIPTION>Router</DESCRIPTION></PRODUCT>";
        contosoProducts += "<PRODUCT><ID>456</ID>";
        contosoProducts += "<DESCRIPTION>Keyboard</DESCRIPTION></PRODUCT>";
        contosoProducts += "<PRODUCT><ID>789</ID>";
        contosoProducts += "<DESCRIPTION>Monitor</DESCRIPTION></PRODUCT>";
        contosoProducts += "</PRODUCTS>";

        xmlDoc.LoadXml(contosoProducts);
        return xmlDoc;
    }

    // Create a signature and add it to the specified document.
    private static void SignDocument(ref XmlDocument xmlDoc)
    {
        // Generate a signing key.
        RSACryptoServiceProvider Key = new RSACryptoServiceProvider();

        // Create a SignedXml object.
        SignedXml signedXml = new SignedXml(xmlDoc);

        // Add the key to the SignedXml document. 
        signedXml.SigningKey = Key;

        // Create a reference to be signed.
        Reference reference = new Reference();
        reference.Uri = "";

        // Add an enveloped transformation to the reference.
        reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());

        // Add the reference to the SignedXml object.
        signedXml.AddReference(reference);

        try 
        {
            // Create a new KeyInfo object.
            KeyInfo keyInfo = new KeyInfo();

            // Load the X509 certificate.
            X509Certificate MSCert =
                X509Certificate.CreateFromCertFile(Certificate);

            // Load the certificate into a KeyInfoX509Data object
            // and add it to the KeyInfo object.
            keyInfo.AddClause(new KeyInfoX509Data(MSCert));

            // Add the KeyInfo object to the SignedXml object.
            signedXml.KeyInfo = keyInfo;
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("Unable to locate the following file: " + 
                Certificate);
        }

        // Compute the signature.
        signedXml.ComputeSignature();

        // Add the signature branch to the original tree so it is enveloped.
        xmlDoc.DocumentElement.AppendChild(signedXml.GetXml());
    }

    // Resolve the specified base and relative Uri's .
    private static Uri ResolveUris(Uri baseUri, string relativeUri)
    {
        XmlUrlResolver xmlResolver = new XmlUrlResolver();
        xmlResolver.Credentials = 
            System.Net.CredentialCache.DefaultCredentials;

        XmlDsigEnvelopedSignatureTransform xmlTransform =
            new XmlDsigEnvelopedSignatureTransform();
        xmlTransform.Resolver = xmlResolver;

        Uri absoluteUri = xmlResolver.ResolveUri(baseUri, relativeUri);

        if (absoluteUri != null)
        {
            Console.WriteLine(
                "\nResolved the base Uri and relative Uri to the following:");
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