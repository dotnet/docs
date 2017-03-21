using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Demo
{
    public static void Main(string[] args)
    {
        // Parse an XSD dateTime to create a DateTime object.
        string xsdDateTime = "2003-02-04T13:58:59.9999999+03:00";
        DateTime dateTime = SoapDateTime.Parse(xsdDateTime);

        // Serialize a DateTime object as an XSD dateTime string.
        Console.WriteLine("The date in XSD format is {0}.",
            SoapDateTime.ToString(dateTime));

        // Print the XSD type string of the SoapDateTime class.
        Console.WriteLine("The XSD type of SoapDateTime is {0}.",
            SoapDateTime.XsdType);
    }
}