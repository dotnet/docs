/// Class:  System.Runtime.Remoting.Metadata.W3cXsd2001.SoapNonPositiveInteger
///    10    class 
///    21    #ctor()
///    22    #ctor(Decimal)
///    13    GetXsdType()
///    11    Parse()
///    12    ToString()
///    14    Value
///    16    XsdType

///    Bugs in SoapNonPositiveInteger:
///    No bugs were detected.

//<snippet10>
using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Demo
{
    public static void Main(string[] args)
    {
        //<snippet11>
        // Parse an XSD formatted string to create a SoapNonPositiveInteger 
        // object.
        string xsdIntegerString = "-13";
        SoapNonPositiveInteger xsdInteger = 
            SoapNonPositiveInteger.Parse(xsdIntegerString);
        //</snippet11>

        //<snippet12>
        // Print the value of the SoapNonPositiveInteger object 
        // in XSD format. 
        Console.WriteLine(
            "The SoapNonPositiveInteger object in XSD format is {0}.",
            xsdInteger.ToString());
        //</snippet12>

        //<snippet13>
        // Print the XSD type string of the SoapNonPositiveInteger object.
        Console.WriteLine(
            "The XSD type of the SoapNonPositiveInteger " + 
            "object is {0}.", xsdInteger.GetXsdType());
        //</snippet13>

        //<snippet14>
        // Print the value of the SoapNonPositiveInteger object.
        Console.WriteLine(
            "The value of the SoapNonPositiveInteger " +
            "object is {0}.", xsdInteger.Value);
        //</snippet14>

        //<snippet16>
        // Print the XSD type string of the SoapNonPositiveInteger class.
        Console.WriteLine(
            "The XSD type of the SoapNonPositiveInteger class " +
            "is {0}.", SoapNonPositiveInteger.XsdType);
        //</snippet16>
    }
}
//</snippet10>