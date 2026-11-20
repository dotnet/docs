// <ChangeCalendar>
using System.Globalization;

DateTime date1 = new(2011, 6, 20);

Console.OutputEncoding = System.Text.Encoding.UTF8;
DisplayCurrentInfo();
// Display the date using the current culture and calendar.
Console.WriteLine(date1.ToString("d"));
Console.WriteLine();

CultureInfo arSA = CultureInfo.CreateSpecificCulture("ar-SA");

// Change the current culture to Arabic (Saudi Arabia).
CultureInfo.CurrentCulture = arSA;
// Display date and information about the current culture.
DisplayCurrentInfo();
Console.WriteLine(date1.ToString("d"));
Console.WriteLine();

// Change the calendar to Hijri.
Calendar hijri = new HijriCalendar();
if (CalendarExists(arSA, hijri))
{
    arSA.DateTimeFormat.Calendar = hijri;
    // Display date and information about the current culture.
    DisplayCurrentInfo();
    Console.WriteLine(date1.ToString("d"));
}

static void DisplayCurrentInfo()
{
    Console.WriteLine($"Current Culture: {CultureInfo.CurrentCulture.Name}");
    Console.WriteLine($"Current Calendar: {DateTimeFormatInfo.CurrentInfo.Calendar}");
}

static bool CalendarExists(CultureInfo culture, Calendar cal) =>
    culture.OptionalCalendars.Any(optional => optional.ToString() == cal.ToString());
// The example displays the following output:
//    Current Culture: en-US
//    Current Calendar: System.Globalization.GregorianCalendar
//    6/20/2011
//
//    Current Culture: ar-SA
//    Current Calendar: System.Globalization.UmAlQuraCalendar
//    18‏‏/7‏‏/1432 بعد الهجرة
//
//    Current Culture: ar-SA
//    Current Calendar: System.Globalization.HijriCalendar
//    19‏‏/7‏‏/1432 بعد الهجرة
// </ChangeCalendar>
