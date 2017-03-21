using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Demo
{
    public static void Main(string[] args)
    {
        // Parse an XSD gDay to create a SoapDay object.
        // The time zone of this object is +08:00.
        string xsdDay = "---30+08:00";
        SoapDay day = SoapDay.Parse(xsdDay);

        // Display the day in XSD format. 
        Console.WriteLine("The day in XSD format is {0}.",
            day.ToString());

        // Display the XSD type string of this particular SoapDay object.
        Console.WriteLine("The XSD type of the SoapDay object is {0}.",
            day.GetXsdType());

        // Display the value of the SoapDay object.
        Console.WriteLine("The value of the SoapDay object is {0}.",
            day.Value);

        // Display the XSD type string of the SoapDay class.
        Console.WriteLine("The XSD type of the class SoapDay is {0}.",
            SoapDay.XsdType);
    }
}