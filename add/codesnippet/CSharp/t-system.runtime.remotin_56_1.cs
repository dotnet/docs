using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Demo
{
    public static void Main(string[] args)
    {
        // Parse an XSD gYearMonth to create a SoapYearMonth object.
        // The time zone of this object is -08:00.
        string xsdYearMonth = "2003-11-08:00";
        SoapYearMonth yearMonth = SoapYearMonth.Parse(xsdYearMonth);

        // Display the yearMonth in XSD format. 
        Console.WriteLine("The yearMonth in XSD format is {0}.",
            yearMonth.ToString());

        // Display the XSD type string of this SoapYearMonth object.
        Console.WriteLine(
            "The XSD type of the SoapYearMonth object is {0}.",
            yearMonth.GetXsdType());

        // Display the value of the SoapYearMonth object.
        Console.WriteLine("The value of the SoapYearMonth object is {0}.",
            yearMonth.Value);

        // Display the sign of the SoapYearMonth object.
        Console.WriteLine("The sign of the SoapYearMonth object is {0}.",
            yearMonth.Sign);

        // Display the XSD type string of the SoapYearMonth class.
        Console.WriteLine("The XSD type of the class SoapYearMonth is {0}.",
            SoapYearMonth.XsdType);
    }
}