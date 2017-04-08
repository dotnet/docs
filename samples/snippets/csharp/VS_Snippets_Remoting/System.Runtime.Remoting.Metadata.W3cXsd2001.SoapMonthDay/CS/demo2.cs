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
        // Create a SoapMonthDay object.
        SoapMonthDay monthDay = new SoapMonthDay();
        monthDay.Value = DateTime.Now;
        Console.WriteLine("The SoapMonthDay object is {0}.", 
            monthDay.ToString());
        //</snippet21>
    }

    static void Ctor2()
    {
        //<snippet22>
        // Create a SoapMonthDay object.
        SoapMonthDay monthDay = new SoapMonthDay(DateTime.Now);
        Console.WriteLine("The SoapMonthDay object is {0}.", 
            monthDay.ToString());
        //</snippet22>
    }

    public static void Main(string[] args)
    {
        Ctor1();
        Ctor2();
    }
}
