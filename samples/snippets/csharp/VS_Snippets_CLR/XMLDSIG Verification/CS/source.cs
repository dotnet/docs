//<Snippet1>
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.IO;
using System.Xml;

public class Verify {

    public static void Main(String[] args) 
    {

        Console.WriteLine("Verifying " + args[0] + "...");

    	// Create a SignedXml.
        SignedXml signedXml = new SignedXml();

        // Load the XML.
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.PreserveWhitespace = true;
        xmlDocument.Load(new XmlTextReader(args[0]));

        XmlNodeList nodeList = xmlDocument.GetElementsByTagName("Signature");
        signedXml.LoadXml((XmlElement)nodeList[0]);

        if (signedXml.CheckSignature()) {
            Console.WriteLine("Signature check OK");
        } else {
            Console.WriteLine("Signature check FAILED");
        }

    }
}
//</Snippet1>
