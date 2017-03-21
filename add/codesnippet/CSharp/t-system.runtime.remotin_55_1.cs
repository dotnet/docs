using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Demo
{
    public static void Main(string[] args)
    {
        // Parse an XSD formatted string to create a SoapPositiveInteger 
        // object.
        string xsdIntegerString = "+13";
        SoapPositiveInteger xsdInteger = 
            SoapPositiveInteger.Parse(xsdIntegerString);

        // Print the value of the SoapPositiveInteger object in XSD format. 
        Console.WriteLine(
            "The SoapPositiveInteger object in XSD format is {0}.",
            xsdInteger.ToString());

        // Print the XSD type string of the SoapPositiveInteger object.
        Console.WriteLine("The XSD type of the SoapPositiveInteger " + 
            "object is {0}.", xsdInteger.GetXsdType());

        // Print the value of the SoapPositiveInteger object.
        Console.WriteLine(
            "The value of the SoapPositiveInteger object is {0}.", 
            xsdInteger.Value);

        // Print the XSD type string of the SoapPositiveInteger class.
        Console.WriteLine(
            "The XSD type of the SoapPositiveInteger class " +
            "is {0}.", SoapPositiveInteger.XsdType);
    }
}