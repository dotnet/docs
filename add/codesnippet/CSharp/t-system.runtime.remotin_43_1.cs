using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Demo
{
    public static void Main(string[] args)
    {
        // Parse an XSD formatted string to create a SoapNonNegativeInteger 
        // object.
        string xsdIntegerString = "+13";
        SoapNonNegativeInteger xsdInteger = 
            SoapNonNegativeInteger.Parse(xsdIntegerString);

        // Print the value of the SoapNonNegativeInteger object 
        // in XSD format. 
        Console.WriteLine(
            "The SoapNonNegativeInteger object in XSD format is {0}.",
            xsdInteger.ToString());

        // Print the XSD type string of the SoapNonNegativeInteger object.
        Console.WriteLine(
            "The XSD type of the SoapNonNegativeInteger " + 
            "object is {0}.", xsdInteger.GetXsdType());

        // Print the value of the SoapNonNegativeInteger object.
        Console.WriteLine(
            "The value of the SoapNonNegativeInteger " +
            "object is {0}.", xsdInteger.Value);

        // Print the XSD type string of the SoapNonNegativeInteger class.
        Console.WriteLine(
            "The XSD type of the SoapNonNegativeInteger class " +
            "is {0}.", SoapNonNegativeInteger.XsdType);
    }
}