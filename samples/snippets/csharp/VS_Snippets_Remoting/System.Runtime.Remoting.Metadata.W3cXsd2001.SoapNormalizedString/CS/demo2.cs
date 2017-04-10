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
        // Create a SoapNormalizedString object.
        SoapNormalizedString normalized = new SoapNormalizedString();
        normalized.Value = "one two"; 
        Console.WriteLine(
            "The value of the SoapNormalizedString object is {0}.", 
            normalized.ToString());
        //</snippet21>
    }

    static void Ctor2()
    {
        //<snippet22>
        // Create a SoapNormalizedString object.
        string testString = "one two"; 
        SoapNormalizedString normalized = 
            new SoapNormalizedString(testString);
        Console.WriteLine(
            "The value of the SoapNormalizedString object is {0}.", 
            normalized.ToString());
        //</snippet22>
    }

    public static void Main(string[] args)
    {
        Ctor1();
        Ctor2();
    }
}
