/// Class:  System.Runtime.Remoting.Metadata.W3cXsd2001.SoapPositiveInteger
///    10    class 
///    21    #ctor()
///    22    #ctor(Decimal)
///    13    GetXsdType()
///    11    Parse()
///    12    ToString()
///    14    Value
///    16    XsdType

///    Bugs in SoapPositiveInteger:
///    No bugs were detected.

//<snippet10>
using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Demo
{
    public static void Main(string[] args)
    {
        //<snippet11>
        // Parse an XSD formatted string to create a SoapPositiveInteger 
        // object.
        string xsdIntegerString = "+13";
        SoapPositiveInteger xsdInteger = 
            SoapPositiveInteger.Parse(xsdIntegerString);
        //</snippet11>

        //<snippet12>
        // Print the value of the SoapPositiveInteger object in XSD format. 
        Console.WriteLine(
            "The SoapPositiveInteger object in XSD format is {0}.",
            xsdInteger.ToString());
        //</snippet12>

        //<snippet13>
        // Print the XSD type string of the SoapPositiveInteger object.
        Console.WriteLine("The XSD type of the SoapPositiveInteger " + 
            "object is {0}.", xsdInteger.GetXsdType());
        //</snippet13>

        //<snippet14>
        // Print the value of the SoapPositiveInteger object.
        Console.WriteLine(
            "The value of the SoapPositiveInteger object is {0}.", 
            xsdInteger.Value);
        //</snippet14>

        //<snippet16>
        // Print the XSD type string of the SoapPositiveInteger class.
        Console.WriteLine(
            "The XSD type of the SoapPositiveInteger class " +
            "is {0}.", SoapPositiveInteger.XsdType);
        //</snippet16>
    }
}
//</snippet10>