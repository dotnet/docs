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
        // Create a SoapNonPositiveInteger object.
        SoapNonPositiveInteger xsdInteger = 
            new SoapNonPositiveInteger();
        xsdInteger.Value = -14; 
        Console.WriteLine(
            "The value of the SoapNonPositiveInteger object is {0}.", 
            xsdInteger.ToString());
        //</snippet21>
    }

    static void Ctor2()
    {
        //<snippet22>
        // Create a SoapNonPositiveInteger object.
        decimal decimalValue = -14; 
        SoapNonPositiveInteger xsdInteger = 
            new SoapNonPositiveInteger(decimalValue);
        Console.WriteLine(
            "The value of the SoapNonPositiveInteger object is {0}.", 
            xsdInteger.ToString());
        //</snippet22>
    }

    public static void Main(string[] args)
    {
        Ctor1();
        Ctor2();
    }
}
