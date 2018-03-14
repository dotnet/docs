/// Need snippets:
///    21    #ctor()
///    22    #ctor(DateTime)

using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Demo2
{
    static void Ctor1()
    {
        //<snippet21>
        // Create a SoapNonNegativeInteger object.
        SoapNonNegativeInteger xsdInteger = 
            new SoapNonNegativeInteger();
        xsdInteger.Value = +14; 
        Console.WriteLine(
            "The value of the SoapNonNegativeInteger object is {0}.", 
            xsdInteger.ToString());
        //</snippet21>
    }

    static void Ctor2()
    {
        //<snippet22>
        // Create a SoapNonNegativeInteger object.
        decimal decimalValue = +14; 
        SoapNonNegativeInteger xsdInteger = 
            new SoapNonNegativeInteger(decimalValue);
        Console.WriteLine(
            "The value of the SoapNonNegativeInteger object is {0}.", 
            xsdInteger.ToString());
        //</snippet22>
    }

    public static void Main(string[] args)
    {
        Ctor1();
        Ctor2();
    }
}
