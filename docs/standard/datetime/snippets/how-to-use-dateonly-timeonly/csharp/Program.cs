using System.Globalization;

Console.WriteLine("---------- Date Hebrew Calendar");
Date_HebrewCalendar();
Console.WriteLine("\n---------- Date Today");
Date_Today();
Console.WriteLine("\n---------- Date Adjust");
Date_ChangeDays();
Console.WriteLine("\n---------- Date Leap Year");
Date_ChangeLeapYear();
Console.WriteLine("\n---------- Date Parsing");
Date_Parse();
Console.WriteLine("\n---------- Date Compare");
Date_Compare();

Console.WriteLine("\n---------- Time Adjust");
Time_ChangeTime();
Console.WriteLine("\n---------- Time Parsing");
Time_Parse();
Console.WriteLine("\n---------- Time Now");
Time_Now();
Console.WriteLine("\n---------- Time Between");
Time_Between();
Console.WriteLine("\n---------- Time Convert DateTime");
Time_DateTime();
Console.WriteLine("\n---------- Time Use TimeSpan");
Time_TimeSpan();


void Date_HebrewCalendar()
{
    //<hebrew>
    var hebrewCalendar = new System.Globalization.HebrewCalendar();
    var theDate = new DateOnly(5776, 2, 8, hebrewCalendar); // 8 Cheshvan 5776

    Console.WriteLine(theDate);

    /* This example produces the following output:
     *
     * 10/21/2015
    */
    //</hebrew>
}

void Date_Today()
{
    //<today>
    var today = DateOnly.FromDateTime(DateTime.Now);
    Console.WriteLine($"Today is {today}");

    /* This example produces output similar to the following:
     * 
     * Today is 12/28/2022
    */
    //</today>
}

void Date_ChangeDays()
{
    //<date_adjust>
    var theDate = new DateOnly(2015, 10, 21);

    var nextDay = theDate.AddDays(1);
    var previousDay = theDate.AddDays(-1);
    var decadeLater = theDate.AddYears(10);
    var lastMonth = theDate.AddMonths(-1);

    Console.WriteLine($"Date: {theDate}");
    Console.WriteLine($" Next day: {nextDay}");
    Console.WriteLine($" Previous day: {previousDay}");
    Console.WriteLine($" Decade later: {decadeLater}");
    Console.WriteLine($" Last month: {lastMonth}");

    /* This example produces the following output:
     * 
     * Date: 10/21/2015
     *  Next day: 10/22/2015
     *  Previous day: 10/20/2015
     *  Decade later: 10/21/2025
     *  Last month: 9/21/2015
    */
    //</date_adjust>
}

void Date_ChangeLeapYear()
{
    //<change_leapyear>
    var theDate = new DateOnly(2024, 02, 29);
    Console.WriteLine(theDate);
    Console.WriteLine(theDate.AddYears(-1));

    /* This example produces the following output:
     * 
     * 2/29/2024
     * 2/28/2023
    */
    //</change_leapyear>
}

void Date_Parse()
{
    //<parse>
    var theDate = DateOnly.ParseExact("21 Oct 2015", "dd MMM yyyy", CultureInfo.InvariantCulture);  // Custom format
    var theDate2 = DateOnly.Parse("October 21, 2015", CultureInfo.InvariantCulture);

    Console.WriteLine(theDate.ToString("m", CultureInfo.InvariantCulture));     // Month day pattern
    Console.WriteLine(theDate2.ToString("o", CultureInfo.InvariantCulture));    // ISO 8601 format
    Console.WriteLine(theDate2.ToLongDateString());

    /* This example produces the following output:
     * 
     * October 21
     * 2015-10-21
     * Wednesday, October 21, 2015
    */
    //</parse>
}

void Date_Compare()
{
    //<date_compare>
    var theDate = DateOnly.ParseExact("21 Oct 2015", "dd MMM yyyy", CultureInfo.InvariantCulture);  // Custom format
    var theDate2 = DateOnly.Parse("October 21, 2015", CultureInfo.InvariantCulture);
    var dateLater = theDate.AddMonths(6);
    var dateBefore = theDate.AddDays(-10);

    Console.WriteLine($"Consider {theDate}...");
    Console.WriteLine($" Is '{nameof(theDate2)}' equal? {theDate == theDate2}");
    Console.WriteLine($" Is {dateLater} after? {dateLater > theDate} ");
    Console.WriteLine($" Is {dateLater} before? {dateLater < theDate} ");
    Console.WriteLine($" Is {dateBefore} after? {dateBefore > theDate} ");
    Console.WriteLine($" Is {dateBefore} before? {dateBefore < theDate} ");

    /* This example produces the following output:
     * 
     * Consider 10/21/2015
     *  Is 'theDate2' equal? True
     *  Is 4/21/2016 after? True
     *  Is 4/21/2016 before? False
     *  Is 10/11/2015 after? False
     *  Is 10/11/2015 before? True
    */
    //</date_compare>
}

void Time_ChangeTime()
{
    //<time_adjust>
    var theTime = new TimeOnly(7, 23, 11);

    var hourLater = theTime.AddHours(1);
    var minutesBefore = theTime.AddMinutes(-12);
    var secondsAfter = theTime.Add(TimeSpan.FromSeconds(10));
    var daysLater = theTime.Add(new TimeSpan(hours: 21, minutes: 200, seconds: 83), out int wrappedDays);
    var daysBehind = theTime.AddHours(-222, out int wrappedDaysFromHours);

    Console.WriteLine($"Time: {theTime}");
    Console.WriteLine($" Hours later: {hourLater}");
    Console.WriteLine($" Minutes before: {minutesBefore}");
    Console.WriteLine($" Seconds after: {secondsAfter}");
    Console.WriteLine($" {daysLater} is the time, which is {wrappedDays} days later");
    Console.WriteLine($" {daysBehind} is the time, which is {wrappedDaysFromHours} days prior");

    /* This example produces the following output:
     * 
     * Time: 7:23 AM
     *  Hours later: 8:23 AM
     *  Minutes before: 7:11 AM
     *  Seconds after: 7:23 AM
     *  7:44 AM is the time, which is 1 days later 
     *  1:23 AM is the time, which is -9 days prior
    */
    //</time_adjust>
}

void Time_Parse()
{
    //<time_parse>
    var theTime = TimeOnly.ParseExact("5:00 pm", "h:mm tt", CultureInfo.InvariantCulture);  // Custom format
    var theTime2 = TimeOnly.Parse("17:30:25", CultureInfo.InvariantCulture);

    Console.WriteLine(theTime.ToString("o", CultureInfo.InvariantCulture));     // Round-trip pattern.
    Console.WriteLine(theTime2.ToString("t", CultureInfo.InvariantCulture));    // Long time format
    Console.WriteLine(theTime2.ToLongTimeString());

    /* This example produces the following output:
     * 
     * 17:00:00.0000000
     * 17:30
     * 5:30:25 PM
    */
    //</time_parse>
}

void Time_Now()
{
    //<time_now>
    var now = TimeOnly.FromDateTime(DateTime.Now);
    Console.WriteLine($"It is {now} right now");

    /* This example produces output similar to the following:
     * 
     * It is 2:01 PM right now
    */
    //</time_now>
}

void Time_Between()
{
    //<time_between>
    var start = new TimeOnly(10, 12, 01); // 10:12:01 AM
    var end = new TimeOnly(14, 00, 53); // 02:00:53 PM

    var outside = start.AddMinutes(-3);
    var inside = start.AddMinutes(120);

    Console.WriteLine($"Time starts at {start} and ends at {end}");
    Console.WriteLine($" Is {outside} between the start and end? {outside.IsBetween(start, end)}");
    Console.WriteLine($" Is {inside} between the start and end? {inside.IsBetween(start, end)}");
    Console.WriteLine($" Is {start} less than {end}? {start < end}");
    Console.WriteLine($" Is {start} greater than {end}? {start > end}");
    Console.WriteLine($" Does {start} equal {end}? {start == end}");
    Console.WriteLine($" The time between {start} and {end} is {end - start}");

    /* This example produces the following output:
     * 
     * Time starts at 10:12 AM and ends at 2:00 PM
     *  Is 10:09 AM between the start and end? False
     *  Is 12:12 PM between the start and end? True
     *  Is 10:12 AM less than 2:00 PM? True
     *  Is 10:12 AM greater than 2:00 PM? False
     *  Does 10:12 AM equal 2:00 PM? False
     *  The time between 10:12 AM and 2:00 PM is 03:48:52
    */
    //</time_between>
}

void Time_TimeSpan()
{
    //<time_timespan>
    // TimeSpan must in the range of 00:00:00.0000000 to 23:59:59.9999999
    var theTime = TimeOnly.FromTimeSpan(new TimeSpan(23, 59, 59));
    var theTimeSpan = theTime.ToTimeSpan();

    Console.WriteLine($"Variable '{nameof(theTime)}' is {theTime}");
    Console.WriteLine($"Variable '{nameof(theTimeSpan)}' is {theTimeSpan}");

    /* This example produces the following output:
     * 
     * Variable 'theTime' is 11:59 PM
     * Variable 'theTimeSpan' is 23:59:59
    */
    //</time_timespan>
}

void Time_DateTime()
{
    //<time_datetime>
    var theTime = new TimeOnly(11, 25, 46);   // 11:25 PM and 46 seconds
    var theDate = new DateOnly(2015, 10, 21); // October 21, 2015
    var theDateTime = theDate.ToDateTime(theTime);
    var reverseTime = TimeOnly.FromDateTime(theDateTime);

    Console.WriteLine($"Date only is {theDate}");
    Console.WriteLine($"Time only is {theTime}");
    Console.WriteLine();
    Console.WriteLine($"Combined to a DateTime type, the value is {theDateTime}");
    Console.WriteLine($"Converted back from DateTime, the time is {reverseTime}");

    /* This example produces the following output:
     * 
     * Date only is 10/21/2015
     * Time only is 11:25 AM
     * 
     * Combined to a DateTime type, the value is 10/21/2015 11:25:46 AM
     * Converted back from DateTime, the time is 11:25 AM
    */
    //</time_datetime>
}
