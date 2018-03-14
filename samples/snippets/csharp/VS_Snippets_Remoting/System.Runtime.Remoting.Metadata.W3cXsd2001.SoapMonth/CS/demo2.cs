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
        // Create a SoapMonth object.
        SoapMonth month = new SoapMonth();
        month.Value = DateTime.Now;
        Console.WriteLine("The month is {0}.", month.ToString());
        //</snippet21>
    }

    static void Ctor2()
    {
        //<snippet22>
        // Create a SoapMonth object.
        SoapMonth month = new SoapMonth(DateTime.Now);
        Console.WriteLine("The month is {0}.", month.ToString());
        //</snippet22>
    }

    public static void Main(string[] args)
    {
        Ctor1();
        Ctor2();
    }
}
