using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Demo
{
    public static void Main(string[] args)
    {
        // Parse an XSD gYear to create a SoapYear object.
        // The time zone of this object is -08:00.
        string xsdYear = "2003-08:00";
        SoapYear year = SoapYear.Parse(xsdYear);

        // Print the year in XSD format. 
        Console.WriteLine("The year in XSD format is {0}.",
            year.ToString());

        // Print the XSD type string of this particular SoapYear object.
        Console.WriteLine("The XSD type of the SoapYear object is {0}.",
            year.GetXsdType());

        // Print the value of the SoapYear object.
        Console.WriteLine("The value of the SoapYear object is {0}.",
            year.Value);

        // Print the sign of the SoapYear object.
        Console.WriteLine("The sign of the SoapYear object is {0}.",
            year.Sign);

        // Print the XSD type string of the SoapYear class.
        Console.WriteLine("The XSD type of the class SoapYear is {0}.",
            SoapYear.XsdType);
    }
}