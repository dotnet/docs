/// Class:  System.Runtime.Remoting.Metadata.W3cXsd2001.SoapNegativeInteger
///    10    class 
///    21    #ctor()
///    22    #ctor(Decimal)
///    13    GetXsdType()
///    11    Parse()
///    12    ToString()
///    14    Value
///    16    XsdType

///    Bugs in SoapNegativeInteger:
///    No bugs were detected.

//<snippet10>
using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Demo
{
    public static void Main(string[] args)
    {
        //<snippet11>
        // Parse an XSD formatted string to create a SoapNegativeInteger 
        // object.
        string xsdIntegerString = "-13";
        SoapNegativeInteger xsdInteger = 
            SoapNegativeInteger.Parse(xsdIntegerString);
        //</snippet11>

        //<snippet12>
        // Print the value of the SoapNegativeInteger object in XSD format. 
        Console.WriteLine(
            "The SoapNegativeInteger object in XSD format is {0}.",
            xsdInteger.ToString());
        //</snippet12>

        //<snippet13>
        // Print the XSD type string of the SoapNegativeInteger object.
        Console.WriteLine(
            "The XSD type of the SoapNegativeInteger " + 
            "object is {0}.", xsdInteger.GetXsdType());
        //</snippet13>

        //<snippet14>
        // Print the value of the SoapNegativeInteger object.
        Console.WriteLine(
            "The value of the SoapNegativeInteger " +
            "object is {0}.", xsdInteger.Value);
        //</snippet14>

        //<snippet16>
        // Print the XSD type string of the SoapNegativeInteger class.
        Console.WriteLine(
            "The XSD type of the SoapNegativeInteger class " +
            "is {0}.", SoapNegativeInteger.XsdType);
        //</snippet16>
    }
}
//</snippet10>