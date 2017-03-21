using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Demo
{
    public static void Main(string[] args)
    {
        // Parse an XSD formatted string to create a SoapNegativeInteger 
        // object.
        string xsdIntegerString = "-13";
        SoapNegativeInteger xsdInteger = 
            SoapNegativeInteger.Parse(xsdIntegerString);

        // Print the value of the SoapNegativeInteger object in XSD format. 
        Console.WriteLine(
            "The SoapNegativeInteger object in XSD format is {0}.",
            xsdInteger.ToString());

        // Print the XSD type string of the SoapNegativeInteger object.
        Console.WriteLine(
            "The XSD type of the SoapNegativeInteger " + 
            "object is {0}.", xsdInteger.GetXsdType());

        // Print the value of the SoapNegativeInteger object.
        Console.WriteLine(
            "The value of the SoapNegativeInteger " +
            "object is {0}.", xsdInteger.Value);

        // Print the XSD type string of the SoapNegativeInteger class.
        Console.WriteLine(
            "The XSD type of the SoapNegativeInteger class " +
            "is {0}.", SoapNegativeInteger.XsdType);
    }
}