// <snippet1>
using System;
using System.Xml;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create an XmlDocument object.
            // <snippet2>
            XmlDocument xmlDoc = new XmlDocument();
            // </snippet2>

            // Load an XML file into the XmlDocument object.
            xmlDoc.PreserveWhitespace = true;
            xmlDoc.Load("test.xml");

            // Decrypt the document.
            Decrypt(xmlDoc);

            // Save the XML document.
            // <snippet5>
            xmlDoc.Save("test.xml");
            // </snippet5>

            // Display the decrypted XML to the console.
            Console.WriteLine("Decrypted XML:");
            Console.WriteLine();
            Console.WriteLine(xmlDoc.OuterXml);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public static void Decrypt(XmlDocument Doc)
    {
        // Check the arguments.
        if (Doc == null)
            throw new ArgumentNullException("Doc");

        // Create a new EncryptedXml object.
        // <snippet3>
        EncryptedXml exml = new EncryptedXml(Doc);
        // </snippet3>

        // Decrypt the XML document.
        // <snippet4>
        exml.DecryptDocument();
        // </snippet4>
    }
}
// </snippet1>