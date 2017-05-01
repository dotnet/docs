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
        // Create a SoapDay object.
        SoapDay day = new SoapDay();
        day.Value = DateTime.Now;
        Console.WriteLine("The day is {0}.", day.ToString());
        //</snippet21>
    }

    static void Ctor2()
    {
        //<snippet22>
        // Create a SoapDay object.
        SoapDay day = new SoapDay(DateTime.Now);
        Console.WriteLine("The day is {0}.", day.ToString());
        //</snippet22>
    }

    public static void Main(string[] args)
    {
        Ctor1();
        Ctor2();
    }
}
