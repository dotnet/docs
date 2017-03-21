using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Demo
{
    public static void Main(string[] args)
    {
        // Parse an XSD formatted string to create a SoapInteger object.
        string xsdIntegerString = "-13";
        SoapInteger xsdInteger = SoapInteger.Parse(xsdIntegerString);

        // Print the value of the SoapInteger object in XSD format. 
        Console.WriteLine("The SoapInteger object in XSD format is {0}.",
            xsdInteger.ToString());

        // Print the XSD type string of the SoapInteger object.
        Console.WriteLine("The XSD type of the SoapInteger " + 
            "object is {0}.", xsdInteger.GetXsdType());

        // Print the value of the SoapInteger object.
        Console.WriteLine(
            "The value of the SoapInteger object is {0}.", 
            xsdInteger.Value);

        // Print the XSD type string of the SoapInteger class.
        Console.WriteLine("The XSD type of the SoapInteger class " +
            "is {0}.", SoapInteger.XsdType);
    }
}