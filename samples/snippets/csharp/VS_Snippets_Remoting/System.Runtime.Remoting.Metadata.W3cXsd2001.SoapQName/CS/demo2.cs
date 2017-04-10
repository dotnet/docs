/// Need snippets:
///    21    #ctor()
///    22    #ctor(string)
///    23    #ctor(string,string)
///    24    #ctor(string,string,string)

using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Demo2
{
    static void Ctor1()
    {
        //<snippet21>
        // Create a SoapQName object.
        SoapQName qName = new SoapQName();
        Console.WriteLine(
            "The value of the SoapQName object is \"{0}\".", 
            qName.ToString());
        //</snippet21>
    }

    static void Ctor2()
    {
        //<snippet22>
        // Create a SoapQName object.
        string name = "SomeName";
        SoapQName qName = new SoapQName(name);
        Console.WriteLine(
            "The value of the SoapQName object is \"{0}\".", 
            qName.ToString());
        //</snippet22>
    }

    static void Ctor3()
    {
        //<snippet23>
        // Create a SoapQName object.
        string key = "tns";
        string name = "SomeName";
        SoapQName qName = new SoapQName(key, name);
        Console.WriteLine(
            "The value of the SoapQName object is \"{0}\".", 
            qName.ToString());
        //</snippet23>
    }

    static void Ctor4()
    {
        //<snippet24>
        // Create a SoapQName object.
        string key = "tns";
        string name = "SomeName";
        string namespaceValue = "http://example.org";
        SoapQName qName = new SoapQName(key, name, namespaceValue);
        Console.WriteLine(
            "The value of the SoapQName object is \"{0}\".", 
            qName.ToString());
        //</snippet24>
    }

    public static void Main(string[] args)
    {
        Ctor1();
        Ctor2();
        Ctor3();
        Ctor4();
    }
}
