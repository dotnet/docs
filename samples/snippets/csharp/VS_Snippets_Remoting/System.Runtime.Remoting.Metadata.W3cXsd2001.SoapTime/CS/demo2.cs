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
        // Create a SoapTime object.
        SoapTime time = new SoapTime();
        time.Value = DateTime.Now;
        Console.WriteLine("The time is {0}.", time.ToString());
        //</snippet21>
    }

    static void Ctor2()
    {
        //<snippet22>
        // Create a SoapTime object.
        SoapTime time = new SoapTime(DateTime.Now);
        Console.WriteLine("The time is {0}.", time.ToString());
        //</snippet22>
    }

    public static void Main(string[] args)
    {
        Ctor1();
        Ctor2();
    }
}
