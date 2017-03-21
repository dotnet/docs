using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Demo
{
    public static void Main(string[] args)
    {
        // Parse an XSD formatted string to create a SoapBase64Binary object.
        // The string "AgMFBws=" is byte[]{ 2, 3, 5, 7, 11 } expressed in 
        // Base 64 format.
        string xsdBase64Binary = "AgMFBws=";
        SoapBase64Binary base64Binary = 
            SoapBase64Binary.Parse(xsdBase64Binary);

        // Print the value of the SoapBase64Binary object in XSD format. 
        Console.WriteLine("The SoapBase64Binary object in XSD format is {0}.",
            base64Binary.ToString());

        // Print the XSD type string of the SoapBase64Binary object.
        Console.WriteLine("The XSD type of the SoapBase64Binary " + 
            "object is {0}.", base64Binary.GetXsdType());

        // Print the value of the SoapBase64Binary object.
        Console.Write("base64Binary.Value contains:");
        for (int i = 0 ; i < base64Binary.Value.Length ; ++i)
        {
            Console.Write(" " + base64Binary.Value[i]);
        }
        Console.WriteLine();

        // Print the XSD type string of the SoapBase64Binary class.
        Console.WriteLine("The XSD type of the class SoapBase64Binary " +
            "is {0}.",
            SoapBase64Binary.XsdType);
    }
}