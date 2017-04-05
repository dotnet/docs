/// Need snippets:
///    21    #ctor()
///    22    #ctor(DateTime)
///    23    #ctor(DateTime,int)

using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public class Demo2
{
    static void Ctor1()
    {
        //<snippet21>
        // Create a SoapDate object.
        SoapDate date = new SoapDate();
        date.Value = DateTime.Now;
        Console.WriteLine("The date is {0}.", date.ToString());
        //</snippet21>
    }

    static void Ctor2()
    {
        //<snippet22>
        // Create a SoapDate object.
        SoapDate date = new SoapDate(DateTime.Now);
        Console.WriteLine("The date is {0}.", date.ToString());
        //</snippet22>
    }

    static void Ctor3()
    {
        //<snippet23>
        // Create a SoapDate object with a positive sign.
        SoapDate date = new SoapDate(DateTime.Now, -1);
        Console.WriteLine("The date is {0}.", date.ToString());
        //</snippet23>
    }

    public static void Main(string[] args)
    {
        Ctor1();
        Ctor2();
        Ctor3();
    }
}
