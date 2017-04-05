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
        // Create a SoapYearMonth object.
        SoapYearMonth yearMonth = new SoapYearMonth();
        yearMonth.Value = DateTime.Now;
        Console.WriteLine("The yearMonth is {0}.", yearMonth.ToString());
        //</snippet21>
    }

    static void Ctor2()
    {
        //<snippet22>
        // Create a SoapYearMonth object.
        SoapYearMonth yearMonth = new SoapYearMonth(DateTime.Now);
        Console.WriteLine("The yearMonth is {0}.", yearMonth.ToString());
        //</snippet22>
    }

    static void Ctor3()
    {
        //<snippet23>
        // Create a SoapYearMonth object with a positive sign.
        SoapYearMonth yearMonth = new SoapYearMonth(DateTime.Now, 1);
        Console.WriteLine("The yearMonth is {0}.", yearMonth.ToString());
        //</snippet23>
    }

    public static void Main(string[] args)
    {
        Ctor1();
        Ctor2();
        Ctor3();
    }
}
