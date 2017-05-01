/// Class: System.Runtime.Remoting.Metadata.W3cXsd2001.SoapYear
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
        // Parse an XSD gYear to create a SoapYear object.
        // The time zone of this object is -08:00.
        string xsdYear = "2003-08:00";
        SoapYear year = SoapYear.Parse(xsdYear);
        //</snippet11>

        //<snippet12>
        // Print the year in XSD format. 
        Console.WriteLine("The year in XSD format is {0}.",
            year.ToString());
        //</snippet12>

        //<snippet13>
        // Print the XSD type string of this particular SoapYear object.
        Console.WriteLine("The XSD type of the SoapYear object is {0}.",
            year.GetXsdType());
        //</snippet13>

        //<snippet14>
        // Print the value of the SoapYear object.
        Console.WriteLine("The value of the SoapYear object is {0}.",
            year.Value);
        //</snippet14>

        //<snippet15>
        // Print the sign of the SoapYear object.
        Console.WriteLine("The sign of the SoapYear object is {0}.",
            year.Sign);
        //</snippet15>

        //<snippet16>
        // Print the XSD type string of the SoapYear class.
        Console.WriteLine("The XSD type of the class SoapYear is {0}.",
            SoapYear.XsdType);
        //</snippet16>
    }
}
//</snippet10>