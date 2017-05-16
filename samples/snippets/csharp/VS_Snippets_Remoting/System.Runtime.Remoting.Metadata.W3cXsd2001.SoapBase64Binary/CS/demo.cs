/// Class:  System.Runtime.Remoting.Metadata.W3cXsd2001.SoapBase64Binary
///    10    class 
///    21    #ctor()
///    22    #ctor(byte[])
///    13    GetXsdType()
///    11    Parse()
///    12    ToString()
///    14    Value
///    16    XsdType

///    Bugs in SoapBase64Binary:
///    No bugs were detected.

//<snippet10>
using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Demo
{
    public static void Main(string[] args)
    {
        //<snippet11>
        // Parse an XSD formatted string to create a SoapBase64Binary object.
        // The string "AgMFBws=" is byte[]{ 2, 3, 5, 7, 11 } expressed in 
        // Base 64 format.
        string xsdBase64Binary = "AgMFBws=";
        SoapBase64Binary base64Binary = 
            SoapBase64Binary.Parse(xsdBase64Binary);
        //</snippet11>

        //<snippet12>
        // Print the value of the SoapBase64Binary object in XSD format. 
        Console.WriteLine("The SoapBase64Binary object in XSD format is {0}.",
            base64Binary.ToString());
        //</snippet12>

        //<snippet13>
        // Print the XSD type string of the SoapBase64Binary object.
        Console.WriteLine("The XSD type of the SoapBase64Binary " + 
            "object is {0}.", base64Binary.GetXsdType());
        //</snippet13>

        //<snippet14>
        // Print the value of the SoapBase64Binary object.
        Console.Write("base64Binary.Value contains:");
        for (int i = 0 ; i < base64Binary.Value.Length ; ++i)
        {
            Console.Write(" " + base64Binary.Value[i]);
        }
        Console.WriteLine();
        //</snippet14>

        //<snippet16>
        // Print the XSD type string of the SoapBase64Binary class.
        Console.WriteLine("The XSD type of the class SoapBase64Binary " +
            "is {0}.",
            SoapBase64Binary.XsdType);
        //</snippet16>
    }
}
//</snippet10>