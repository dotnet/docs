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
        // Create a SoapYear object.
        SoapYear year = new SoapYear();
        year.Value = DateTime.Now;
        Console.WriteLine("The year is {0}.", year.ToString());
        //</snippet21>
    }

    static void Ctor2()
    {
        //<snippet22>
        // Create a SoapYear object.
        SoapYear year = new SoapYear(DateTime.Now);
        Console.WriteLine("The year is {0}.", year.ToString());
        //</snippet22>
    }

    static void Ctor3()
    {
        //<snippet23>
        // Create a SoapYear object with a positive sign.
        SoapYear year = new SoapYear(DateTime.Now, 1);
        Console.WriteLine("The year is {0}.", year.ToString());
        //</snippet23>
    }

    public static void Main(string[] args)
    {
        Ctor1();
        Ctor2();
        Ctor3();
    }
}
