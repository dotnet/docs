using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Demo
{
    public static void Main(string[] args)
    {
        // Parse an XSD date to create a SoapDate object.
        string xsdDate = "2003-02-04";
        SoapDate date = SoapDate.Parse(xsdDate);

        // Serialize a DateTime object as an XSD date string.
        Console.WriteLine("The date in XSD format is {0}.",
            date.ToString());

        // Print the XSD type string of this particular SoapDate object.
        Console.WriteLine("The XSD type of the SoapDate object is {0}.",
            date.GetXsdType());

        // Print the value of the SoapDate object.
        Console.WriteLine("The value of the SoapDate object is {0}.",
            date.Value);

        // Print the sign of the SoapDate object.
        Console.WriteLine("The sign of the SoapDate object is {0}.",
            date.Sign);

        // Print the XSD type string of the SoapDate class.
        Console.WriteLine("The XSD type of SoapDate is {0}.",
            SoapDate.XsdType);
    }
}