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
        // Create a SoapBase64Binary object.
        SoapBase64Binary base64Binary = new SoapBase64Binary();
        base64Binary.Value = new byte[]{ 2, 3, 5, 7, 11, 0, 5 };
        Console.WriteLine("The SoapBase64Binary object is {0}.", 
            base64Binary.ToString());
        //</snippet21>
    }

    static void Ctor2()
    {
        //<snippet22>
        // Create a SoapBase64Binary object.
        byte[] bytes = new byte[]{ 2, 3, 5, 7, 11 };
        SoapBase64Binary base64Binary = new SoapBase64Binary(bytes);
        Console.WriteLine("The SoapBase64Binary object is {0}.", 
            base64Binary.ToString());
        //</snippet22>
    }

    public static void Main(string[] args)
    {
        Ctor1();
        Ctor2();
    }
}
