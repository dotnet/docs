/// Class:  System.Runtime.Remoting.Metadata.W3cXsd2001.SoapYearMonth
/// Need snippets:
///    10    class 
///    21    #ctor()
///    22    #ctor(DateTime)
///    23    #ctor(DateTime,int)
///    13    GetXsdType
///    11    Parse
///    15    Sign
///    12    ToString
///    14    Value
///    16    XsdType

//<snippet10>
using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Demo
{
    public static void Main(string[] args)
    {
        //<snippet11>
        // Parse an XSD gYearMonth to create a SoapYearMonth object.
        // The time zone of this object is -08:00.
        string xsdYearMonth = "2003-11-08:00";
        SoapYearMonth yearMonth = SoapYearMonth.Parse(xsdYearMonth);
        //</snippet11>

        //<snippet12>
        // Display the yearMonth in XSD format. 
        Console.WriteLine("The yearMonth in XSD format is {0}.",
            yearMonth.ToString());
        //</snippet12>

        //<snippet13>
        // Display the XSD type string of this SoapYearMonth object.
        Console.WriteLine(
            "The XSD type of the SoapYearMonth object is {0}.",
            yearMonth.GetXsdType());
        //</snippet13>

        //<snippet14>
        // Display the value of the SoapYearMonth object.
        Console.WriteLine("The value of the SoapYearMonth object is {0}.",
            yearMonth.Value);
        //</snippet14>

        //<snippet15>
        // Display the sign of the SoapYearMonth object.
        Console.WriteLine("The sign of the SoapYearMonth object is {0}.",
            yearMonth.Sign);
        //</snippet15>

        //<snippet16>
        // Display the XSD type string of the SoapYearMonth class.
        Console.WriteLine("The XSD type of the class SoapYearMonth is {0}.",
            SoapYearMonth.XsdType);
        //</snippet16>
    }
}
//</snippet10>