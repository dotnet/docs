/// Need snippets:
///    21    #ctor()
///    22    #ctor(string)

using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Demo2
{
    static void Ctor1()
    {
        //<snippet21>
        // Create a SoapAnyUri object.
        SoapAnyUri anyUri = new SoapAnyUri();
        anyUri.Value = "http://localhost:8080/WebService"; 
        Console.WriteLine(
            "The value of the SoapAnyUri object is {0}.", 
            anyUri.ToString());
        //</snippet21>
    }

    static void Ctor2()
    {
        //<snippet22>
        // Create a SoapAnyUri object.
        string anyUriValue = "http://localhost:8080/WebService"; 
        SoapAnyUri anyUri = new SoapAnyUri(anyUriValue);
        Console.WriteLine(
            "The value of the SoapAnyUri object is {0}.", 
            anyUri.ToString());
        //</snippet22>
    }

    public static void Main(string[] args)
    {
        Ctor1();
        Ctor2();
    }
}
