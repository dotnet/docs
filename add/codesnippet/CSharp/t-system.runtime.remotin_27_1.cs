using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Demo
{
    public static void Main(string[] args)
    {
        // Parse an XSD formatted string to create a SoapNonPositiveInteger 
        // object.
        string xsdIntegerString = "-13";
        SoapNonPositiveInteger xsdInteger = 
            SoapNonPositiveInteger.Parse(xsdIntegerString);

        // Print the value of the SoapNonPositiveInteger object 
        // in XSD format. 
        Console.WriteLine(
            "The SoapNonPositiveInteger object in XSD format is {0}.",
            xsdInteger.ToString());

        // Print the XSD type string of the SoapNonPositiveInteger object.
        Console.WriteLine(
            "The XSD type of the SoapNonPositiveInteger " + 
            "object is {0}.", xsdInteger.GetXsdType());

        // Print the value of the SoapNonPositiveInteger object.
        Console.WriteLine(
            "The value of the SoapNonPositiveInteger " +
            "object is {0}.", xsdInteger.Value);

        // Print the XSD type string of the SoapNonPositiveInteger class.
        Console.WriteLine(
            "The XSD type of the SoapNonPositiveInteger class " +
            "is {0}.", SoapNonPositiveInteger.XsdType);
    }
}