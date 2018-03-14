/// Class: System.Runtime.Remoting.Metadata.W3cXsd2001.SoapHexBinary
///    10    class 
///    21    #ctor()
///    22    #ctor(byte[])
///    13    GetXsdType()
///    11    Parse()
///    12    ToString()
///    14    Value
///    16    XsdType

///    Bugs in SoapHexBinary:
///    No bugs were detected.

//<snippet10>
using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Demo
{
    public static void Main(string[] args)
    {
        //<snippet11>
        // Parse an XSD formatted string to create a SoapHexBinary object.
        string xsdHexBinary = "3f789ABC";
        SoapHexBinary hexBinary = SoapHexBinary.Parse(xsdHexBinary);
        //</snippet11>

        //<snippet12>
        // Print the value of the SoapHexBinary object in XSD format. 
        Console.WriteLine("The SoapHexBinary object in XSD format is {0}.",
            hexBinary.ToString());
        //</snippet12>

        //<snippet13>
        // Print the XSD type string of this particular SoapHexBinary object.
        Console.WriteLine(
            "The XSD type of the SoapHexBinary object is {0}.",
            hexBinary.GetXsdType());
        //</snippet13>

        //<snippet14>
        // Print the value of the SoapHexBinary object.
        Console.Write("hexBinary.Value contains:");
        for (int i = 0 ; i < hexBinary.Value.Length ; ++i)
        {
            Console.Write(" " + hexBinary.Value[i]);
        }
        Console.WriteLine();
        //</snippet14>

        //<snippet16>
        // Print the XSD type string of the SoapHexBinary class.
        Console.WriteLine("The XSD type of the class SoapHexBinary is {0}.",
            SoapHexBinary.XsdType);
        //</snippet16>
    }
}
//</snippet10>