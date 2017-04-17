/// Class:  System.Runtime.Remoting.Metadata.W3cXsd2001.SoapTime
/// Need snippets:
///    10    class 
///    21    #ctor()
///    22    #ctor(DateTime)
///    13    GetXsdType
///    11    Parse
///    12    ToString
///    14    Value
///    16    XsdType
///    
///    Bugs:
///    
///    Parse should take up to 9 digits in fractional seconds, but only 
///    accepts up to 7. Also it only parses the first three, and ignores 
///    the others (fractional second digits).

//<snippet10>
using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Demo
{
    public static void Main(string[] args)
    {
        //<snippet11>
        // Parse an XSD gTime to create a SoapTime object.
        // The time zone of this object is the current time zone.
        string xsdTime = "12:13:14.123Z";
        SoapTime time = SoapTime.Parse(xsdTime);
        //</snippet11>

        //<snippet12>
        // Display the time in XSD format. 
        Console.WriteLine("The time in XSD format is {0}.",
            time.ToString());
        //</snippet12>

        //<snippet13>
        // Display the XSD type string of this particular SoapTime object.
        Console.WriteLine("The XSD type of the SoapTime object is {0}.",
            time.GetXsdType());
        //</snippet13>

        //<snippet14>
        // Display the value of the SoapTime object.
        Console.WriteLine("The value of the SoapTime object is {0}.",
            time.Value);
        //</snippet14>

        //<snippet16>
        // Display the XSD type string of the SoapTime class.
        Console.WriteLine("The XSD type of the class SoapTime is {0}.",
            SoapTime.XsdType);
        //</snippet16>
    }
}
//</snippet10>