/// Class:  System.Runtime.Remoting.Metadata.W3cXsd2001.SoapInteger
///    10    class 
///    21    #ctor()
///    22    #ctor(decimal)
///    13    GetXsdType()
///    11    Parse()
///    12    ToString()
///    14    Value
///    16    XsdType

///    Bugs in SoapInteger:
///    No bugs were detected.

//<snippet10>
using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Demo
{
    public static void Main(string[] args)
    {
        //<snippet11>
        // Parse an XSD formatted string to create a SoapInteger object.
        string xsdIntegerString = "-13";
        SoapInteger xsdInteger = SoapInteger.Parse(xsdIntegerString);
        //</snippet11>

        //<snippet12>
        // Print the value of the SoapInteger object in XSD format. 
        Console.WriteLine("The SoapInteger object in XSD format is {0}.",
            xsdInteger.ToString());
        //</snippet12>

        //<snippet13>
        // Print the XSD type string of the SoapInteger object.
        Console.WriteLine("The XSD type of the SoapInteger " + 
            "object is {0}.", xsdInteger.GetXsdType());
        //</snippet13>

        //<snippet14>
        // Print the value of the SoapInteger object.
        Console.WriteLine(
            "The value of the SoapInteger object is {0}.", 
            xsdInteger.Value);
        //</snippet14>

        //<snippet16>
        // Print the XSD type string of the SoapInteger class.
        Console.WriteLine("The XSD type of the SoapInteger class " +
            "is {0}.", SoapInteger.XsdType);
        //</snippet16>
    }
}
//</snippet10>