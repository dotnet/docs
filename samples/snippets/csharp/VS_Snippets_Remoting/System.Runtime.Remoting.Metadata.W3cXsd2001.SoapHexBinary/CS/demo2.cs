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
        // Create a SoapHexBinary object.
        SoapHexBinary hexBinary = new SoapHexBinary();
        hexBinary.Value = new byte[]{ 2, 3, 5, 7, 11 };
        Console.WriteLine("The SoapHexBinary object is {0}.", 
            hexBinary.ToString());
        //</snippet21>
    }

    static void Ctor2()
    {
        //<snippet22>
        // Create a SoapHexBinary object.
        byte[] bytes = new byte[]{ 2, 3, 5, 7, 11 };
        SoapHexBinary hexBinary = new SoapHexBinary(bytes);
        Console.WriteLine("The SoapHexBinary object is {0}.", 
            hexBinary.ToString());
        //</snippet22>
    }

    public static void Main(string[] args)
    {
        Ctor1();
        Ctor2();
    }
}
