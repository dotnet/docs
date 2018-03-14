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
        // Create a SoapPositiveInteger object.
        SoapPositiveInteger xsdInteger = 
            new SoapPositiveInteger();
        xsdInteger.Value = 14; 
        Console.WriteLine(
            "The value of the SoapPositiveInteger object is {0}.", 
            xsdInteger.ToString());
        //</snippet21>
    }

    static void Ctor2()
    {
        //<snippet22>
        // Create a SoapPositiveInteger object.
        decimal decimalValue = 14; 
        SoapPositiveInteger xsdInteger = 
            new SoapPositiveInteger(decimalValue);
        Console.WriteLine(
            "The value of the SoapPositiveInteger object is {0}.", 
            xsdInteger.ToString());
        //</snippet22>
    }

    public static void Main(string[] args)
    {
        Ctor1();
        Ctor2();
    }
}
