/// Class: System.Runtime.Remoting.Metadata.W3cXsd2001.SoapDateTime
///    10    class 
///    11    Parse
///    12    ToString
///    13    XsdType

///    !    #ctor

///    
///    Bug report:
///    Constructor unusable since all methods are static.

//<snippet10>
using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Demo
{
    public static void Main(string[] args)
    {
        //<snippet11>
        // Parse an XSD dateTime to create a DateTime object.
        string xsdDateTime = "2003-02-04T13:58:59.9999999+03:00";
        DateTime dateTime = SoapDateTime.Parse(xsdDateTime);
        //</snippet11>

        //<snippet12>
        // Serialize a DateTime object as an XSD dateTime string.
        Console.WriteLine("The date in XSD format is {0}.",
            SoapDateTime.ToString(dateTime));
        //</snippet12>

        //<snippet13>
        // Print the XSD type string of the SoapDateTime class.
        Console.WriteLine("The XSD type of SoapDateTime is {0}.",
            SoapDateTime.XsdType);
        //</snippet13>
    }
}
//</snippet10>
