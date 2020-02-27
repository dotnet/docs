//<snippet1>
using namespace System;
using namespace System::Globalization;

namespace CalendarTypeExample
{
    static void Display(Calendar^ genericCalendar)
    {
        String^ calendarName = 
            genericCalendar->ToString()->PadRight(50, '.');
		Console::WriteLine("{0} {1}", calendarName, genericCalendar->GetType());
    }
}

int main() 
{
    GregorianCalendar^ gregorianCalendar = gcnew GregorianCalendar();
    HijriCalendar^ hijriCalendar = gcnew HijriCalendar();
    JapaneseLunisolarCalendar^ japaneseCalendar = 
        gcnew JapaneseLunisolarCalendar();
    CalendarTypeExample::Display(gregorianCalendar);
    CalendarTypeExample::Display(hijriCalendar);
    CalendarTypeExample::Display(japaneseCalendar);
    return 0;
}

/* This code example produces the following output.

System.Globalization.GregorianCalendar............ System.Globalization.GregorianCalendar
System.Globalization.HijriCalendar................ System.Globalization.HijriCalendar
System.Globalization.JapaneseLunisolarCalendar.... System.Globalization.JapaneseLunisolarCalendar

*/
//</snippet1>
