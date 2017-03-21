using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Demo
{
    public static void Main(string[] args)
    {
        // Parse an XSD formatted string to create a SoapQName object.
        string xsdQName = "tns:SomeName";
        SoapQName qName = SoapQName.Parse(xsdQName);

        // Print the value of the SoapQName object in XSD format. 
        Console.WriteLine(
            "The SoapQName object in XSD format is {0}.",
            qName.ToString());

        // Print the XSD type string of the SoapQName object.
        Console.WriteLine("The XSD type of the SoapQName " + 
            "object is {0}.", qName.GetXsdType());

        // Print the XSD type string of the SoapQName class.
        Console.WriteLine(
            "The XSD type of the SoapQName class " +
            "is {0}.", SoapQName.XsdType);

        // Create a QName object.
        SoapQName soapQNameInstance = 
            new SoapQName("tns", "SomeName", "http://example.org");

        // Print the key the SoapQName object.
        Console.WriteLine("The key of the SoapQName " + 
            "object is {0}.", soapQNameInstance.Key);

        // Print the name of the SoapQName object.
        Console.WriteLine("The name of the SoapQName " + 
            "object is {0}.", soapQNameInstance.Name);

        // Print the namespace of the SoapQName class.
        Console.WriteLine("The namespace for this instance of SoapQName " +
            "is {0}.", soapQNameInstance.Namespace);

    }
}