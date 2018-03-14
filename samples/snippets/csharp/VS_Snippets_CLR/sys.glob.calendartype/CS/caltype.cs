//<snippet1>
// This example demonstrates the Calendar.AlgorithmType property and
// CalendarAlgorithmType enumeration.

using System;
using System.Globalization;

class Sample 
{
    public static void Main() 
    {
    GregorianCalendar grCal = new GregorianCalendar();
    HijriCalendar     hiCal = new HijriCalendar();
    JapaneseLunisolarCalendar 
                      jaCal = new JapaneseLunisolarCalendar();
    Display(grCal);
    Display(hiCal);
    Display(jaCal);
    }

    static void Display(Calendar c)
    {
    string name = c.ToString().PadRight(50, '.');
    Console.WriteLine("{0} {1}", name, c.AlgorithmType);
    }
}
/*
This code example produces the following results:

System.Globalization.GregorianCalendar............ SolarCalendar
System.Globalization.HijriCalendar................ LunarCalendar
System.Globalization.JapaneseLunisolarCalendar.... LunisolarCalendar

*/
//</snippet1>