using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Demo
{
    public static void Main(string[] args)
    {
        // Parse an XSD formatted string to create a SoapHexBinary object.
        string xsdHexBinary = "3f789ABC";
        SoapHexBinary hexBinary = SoapHexBinary.Parse(xsdHexBinary);

        // Print the value of the SoapHexBinary object in XSD format. 
        Console.WriteLine("The SoapHexBinary object in XSD format is {0}.",
            hexBinary.ToString());

        // Print the XSD type string of this particular SoapHexBinary object.
        Console.WriteLine(
            "The XSD type of the SoapHexBinary object is {0}.",
            hexBinary.GetXsdType());

        // Print the value of the SoapHexBinary object.
        Console.Write("hexBinary.Value contains:");
        for (int i = 0 ; i < hexBinary.Value.Length ; ++i)
        {
            Console.Write(" " + hexBinary.Value[i]);
        }
        Console.WriteLine();

        // Print the XSD type string of the SoapHexBinary class.
        Console.WriteLine("The XSD type of the class SoapHexBinary is {0}.",
            SoapHexBinary.XsdType);
    }
}