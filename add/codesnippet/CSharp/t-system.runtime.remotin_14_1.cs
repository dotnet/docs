using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Demo
{
    public static void Main(string[] args)
    {
        // Parse an XSD gMonth to create a SoapMonth object.
        // The time zone of this object is +08:00.
        string xsdMonth = "--02--+08:00";
        SoapMonth month = SoapMonth.Parse(xsdMonth);

        // Print the month in XSD format. 
        Console.WriteLine("The month in XSD format is {0}.",
            month.ToString());

        // Print the XSD type string of this particular SoapMonth object.
        Console.WriteLine("The XSD type of the SoapMonth object is {0}.",
            month.GetXsdType());

        // Print the value of the SoapMonth object.
        Console.WriteLine("The value of the SoapMonth object is {0}.",
            month.Value);

        // Print the XSD type string of the SoapMonth class.
        Console.WriteLine("The XSD type of the class SoapMonth is {0}.",
            SoapMonth.XsdType);
    }
}