/// Class:  System.Runtime.Remoting.Metadata.W3cXsd2001.SoapAnyUri
///    10    class 
///    21    #ctor()
///    22    #ctor(string)
///    13    GetXsdType()
///    11    Parse()
///    12    ToString()
///    14    Value
///    16    XsdType
/// 
///    Bugs in SoapAnyUri: None found.

//<snippet10>
using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Demo
{
    public static void Main(string[] args)
    {
        //<snippet11>
        // Parse an XSD formatted string to create a SoapAnyUri object.
        string xsdAnyUri = "http://localhost:8080/WebService";
        SoapAnyUri anyUri = SoapAnyUri.Parse(xsdAnyUri);
        //</snippet11>

        //<snippet12>
        // Print the value of the SoapAnyUri object in XSD format. 
        Console.WriteLine(
            "The SoapAnyUri object in XSD format is {0}.",
            anyUri.ToString());
        //</snippet12>

        //<snippet13>
        // Print the XSD type string of the SoapAnyUri object.
        Console.WriteLine("The XSD type of the SoapAnyUri " + 
            "object is {0}.", anyUri.GetXsdType());
        //</snippet13>

        //<snippet14>
        // Print the value of the SoapAnyUri object.
        Console.WriteLine(
            "The value of the SoapAnyUri object is {0}.", 
            anyUri.Value);
        //</snippet14>

        //<snippet16>
        // Print the XSD type string of the SoapAnyUri class.
        Console.WriteLine(
            "The XSD type of the SoapAnyUri class " +
            "is {0}.", SoapAnyUri.XsdType);
        //</snippet16>
    }
}
//</snippet10>