using System;

public class Class1
{
    public static void Main()
    {
        ShowSchedule();
        Console.WriteLine("----------");
        ShowStartOfWorkWeek();
        Console.WriteLine("----------");
        ShowShiftStartTimes();
        Console.WriteLine("----------");
        ShowQuarters();
        Console.WriteLine("----------");
        DisplayTimes();
        Console.WriteLine("----------");
        ShowLegalLicenseAge();
        Console.WriteLine("----------");
        CompareForEquality1();
        Console.WriteLine("----------");
        CompareForEquality2();
        Console.WriteLine("----------");
        CompareForEquality3();
        Console.WriteLine("----------");
        CompareExactly();
        Console.WriteLine("----------");
        Subtract1();
        Console.WriteLine("----------");
        Subtract2();
        Console.WriteLine("----------");
        ConvertToLocal();
        Console.WriteLine("----------");
        ConvertToUniversal();
        Console.WriteLine("----------");
    }

    private static void ShowSchedule()
    {
        // <Snippet1>
        DateTimeOffset takeOff = new DateTimeOffset(2007, 6, 1, 7, 55, 0,
                                     new TimeSpan(-5, 0, 0));
        DateTimeOffset currentTime = takeOff;
        TimeSpan[] flightTimes = new TimeSpan[]
                          {new TimeSpan(2, 25, 0), new TimeSpan(1, 48, 0)};
        Console.WriteLine($"Takeoff is scheduled for {takeOff:d} at {takeOff:T}.");
        for (int ctr = flightTimes.GetLowerBound(0);
             ctr <= flightTimes.GetUpperBound(0); ctr++)
        {
            currentTime = currentTime.Add(flightTimes[ctr]);
            Console.WriteLine($"Destination #{ctr + 1} at {currentTime}.");
        }
        // </Snippet1>
    }

    private static void ShowStartOfWorkWeek()
    {
        // <Snippet2>
        DateTimeOffset workDay = new DateTimeOffset(2008, 3, 1, 9, 0, 0,
                           DateTimeOffset.Now.Offset);
        int month = workDay.Month;
        // Start with the first Monday of the month
        if (workDay.DayOfWeek != DayOfWeek.Monday)
        {
            if (workDay.DayOfWeek == DayOfWeek.Sunday)
                workDay = workDay.AddDays(1);
            else
                workDay = workDay.AddDays(8 - (int)workDay.DayOfWeek);
        }
        Console.WriteLine($"Beginning of Work Week In {workDay:MMMM} {workDay:yyyy}:");
        // Add one week to the current date
        do
        {
            Console.WriteLine("   {0:dddd}, {0:MMMM}{0: d}", workDay);
            workDay = workDay.AddDays(7);
        } while (workDay.Month == month);

        // The example produces the following output:
        //    Beginning of Work Week In March 2008:
        //       Monday, March 3
        //       Monday, March 10
        //       Monday, March 17
        //       Monday, March 24
        //       Monday, March 31
        // </Snippet2>
    }

    private static void ShowShiftStartTimes()
    {
        // <Snippet3>
        const int SHIFT_LENGTH = 8;

        DateTimeOffset startTime = new DateTimeOffset(2007, 8, 6, 0, 0, 0,
                             DateTimeOffset.Now.Offset);
        DateTimeOffset startOfShift = startTime.AddHours(SHIFT_LENGTH);

        Console.WriteLine($"Shifts for the week of {startOfShift:D}");
        do
        {
            // Exclude third shift
            if (startOfShift.Hour > 6)
                Console.WriteLine($"   {startOfShift:d} at {startOfShift:T}");

            startOfShift = startOfShift.AddHours(SHIFT_LENGTH);
        } while (startOfShift.DayOfWeek != DayOfWeek.Saturday &
                   startOfShift.DayOfWeek != DayOfWeek.Sunday);

        // The example produces the following output:
        //
        //    Shifts for the week of Monday, August 06, 2007
        //       8/6/2007 at 8:00:00 AM
        //       8/6/2007 at 4:00:00 PM
        //       8/7/2007 at 8:00:00 AM
        //       8/7/2007 at 4:00:00 PM
        //       8/8/2007 at 8:00:00 AM
        //       8/8/2007 at 4:00:00 PM
        //       8/9/2007 at 8:00:00 AM
        //       8/9/2007 at 4:00:00 PM
        //       8/10/2007 at 8:00:00 AM
        //       8/10/2007 at 4:00:00 PM
        // </Snippet3>
    }

    private static void ShowQuarters()
    {
        // <Snippet4>
        DateTimeOffset quarterDate = new DateTimeOffset(2007, 1, 1, 0, 0, 0,
                                         DateTimeOffset.Now.Offset);
        for (int ctr = 1; ctr <= 4; ctr++)
        {
            Console.WriteLine($"Quarter {ctr}: {quarterDate:MMMM d}");
            quarterDate = quarterDate.AddMonths(3);
        }

        // This example produces the following output:
        //       Quarter 1: January 1
        //       Quarter 2: April 1
        //       Quarter 3: July 1
        //       Quarter 4: October 1
        // </Snippet4>
    }

    private static void DisplayTimes()
    {
        // <Snippet5>
        double[] lapTimes = { 1.308, 1.283, 1.325, 1.3625, 1.317, 1.267 };
        DateTimeOffset currentTime = new DateTimeOffset(1, 1, 1, 1, 30, 0,
                                     DateTimeOffset.Now.Offset);
        Console.WriteLine($"Start:    {currentTime:T}");
        for (int ctr = lapTimes.GetLowerBound(0); ctr <= lapTimes.GetUpperBound(0); ctr++)
        {
            currentTime = currentTime.AddMinutes(lapTimes[ctr]);
            Console.WriteLine($"Lap {ctr + 1}:    {currentTime:T}");
        }

        // The example produces the following output:
        //       Start:    1:30:00 PM
        //       Lap 1:    1:31:18 PM
        //       Lap 2:    1:32:35 PM
        //       Lap 3:    1:33:54 PM
        //       Lap 4:    1:35:16 PM
        //       Lap 5:    1:36:35 PM
        //       Lap 6:    1:37:51 PM
        // </Snippet5>
    }

    private static void ShowLegalLicenseAge()
    {
        // <Snippet6>
        const int minimumAge = 16;
        DateTimeOffset dateToday = DateTimeOffset.Now;
        DateTimeOffset latestBirthday = dateToday.AddYears(-1 * minimumAge);
        Console.WriteLine("To possess a driver's license, you must have been born on or before {0:d}.",
                          latestBirthday);
        // </Snippet6>
    }

    // <Snippet9>
    private static void CompareForEquality1()
    {
        DateTimeOffset firstTime = new DateTimeOffset(2007, 9, 1, 6, 45, 0,
                                   new TimeSpan(-7, 0, 0));

        DateTimeOffset secondTime = firstTime;
        Console.WriteLine($"{firstTime} = {secondTime}: {firstTime.Equals(secondTime)}");

        secondTime = new DateTimeOffset(2007, 9, 1, 6, 45, 0,
                         new TimeSpan(-6, 0, 0));
        Console.WriteLine($"{firstTime} = {secondTime}: {firstTime.Equals(secondTime)}");

        secondTime = new DateTimeOffset(2007, 9, 1, 8, 45, 0,
                         new TimeSpan(-5, 0, 0));
        Console.WriteLine($"{firstTime} = {secondTime}: {firstTime.Equals(secondTime)}");

        // The example displays the following output to the console:
        //      9/1/2007 6:45:00 AM -07:00 = 9/1/2007 6:45:00 AM -07:00: True
        //      9/1/2007 6:45:00 AM -07:00 = 9/1/2007 6:45:00 AM -06:00: False
        //      9/1/2007 6:45:00 AM -07:00 = 9/1/2007 8:45:00 AM -05:00: True
        // </Snippet9>
    }

    // <Snippet10>
    private static void CompareForEquality2()
    {
        DateTimeOffset firstTime = new DateTimeOffset(2007, 9, 1, 6, 45, 0,
                                   new TimeSpan(-7, 0, 0));

        object secondTime = firstTime;
        Console.WriteLine($"{firstTime} = {secondTime}: {firstTime.Equals(secondTime)}");

        secondTime = new DateTimeOffset(2007, 9, 1, 6, 45, 0,
                         new TimeSpan(-6, 0, 0));
        Console.WriteLine($"{firstTime} = {secondTime}: {firstTime.Equals(secondTime)}");

        secondTime = new DateTimeOffset(2007, 9, 1, 8, 45, 0,
                         new TimeSpan(-5, 0, 0));
        Console.WriteLine($"{firstTime} = {secondTime}: {firstTime.Equals(secondTime)}");

        secondTime = null;
        Console.WriteLine($"{firstTime} = {secondTime}: {firstTime.Equals(secondTime)}");

        secondTime = new DateTime(2007, 9, 1, 6, 45, 00);
        Console.WriteLine($"{firstTime} = {secondTime}: {firstTime.Equals(secondTime)}");

        // The example displays the following output to the console:
        //       9/1/2007 6:45:00 AM -07:00 = 9/1/2007 6:45:00 AM -07:00: True
        //       9/1/2007 6:45:00 AM -07:00 = 9/1/2007 6:45:00 AM -06:00: False
        //       9/1/2007 6:45:00 AM -07:00 = 9/1/2007 8:45:00 AM -05:00: True
        //       9/1/2007 6:45:00 AM -07:00 = : False
        //       9/1/2007 6:45:00 AM -07:00 = 9/1/2007 6:45:00 AM: False
        // </Snippet10>
    }

    private static void CompareForEquality3()
    {
        // <Snippet11>
        DateTimeOffset firstTime = new DateTimeOffset(2007, 11, 15, 11, 35, 00,
                                            DateTimeOffset.Now.Offset);
        DateTimeOffset secondTime = firstTime;
        Console.WriteLine($"{firstTime} = {secondTime}: {DateTimeOffset.Equals(firstTime, secondTime)}");

        // The value of firstTime remains unchanged
        secondTime = new DateTimeOffset(firstTime.DateTime,
                     TimeSpan.FromHours(firstTime.Offset.Hours + 1));
        Console.WriteLine($"{firstTime} = {secondTime}: {DateTimeOffset.Equals(firstTime, secondTime)}");

        // value of firstTime remains unchanged
        secondTime = new DateTimeOffset(firstTime.DateTime + TimeSpan.FromHours(1),
                                        TimeSpan.FromHours(firstTime.Offset.Hours + 1));
        Console.WriteLine($"{firstTime} = {secondTime}: {DateTimeOffset.Equals(firstTime, secondTime)}");

        // The example produces the following output:
        //       11/15/2007 11:35:00 AM -07:00 = 11/15/2007 11:35:00 AM -07:00: True
        //       11/15/2007 11:35:00 AM -07:00 = 11/15/2007 11:35:00 AM -06:00: False
        //       11/15/2007 11:35:00 AM -07:00 = 11/15/2007 12:35:00 PM -06:00: True
        // </Snippet11>
    }

    private static void CompareExactly()
    {
        // <Snippet12>
        DateTimeOffset instanceTime = new DateTimeOffset(2007, 10, 31, 0, 0, 0,
                                      DateTimeOffset.Now.Offset);

        DateTimeOffset otherTime = instanceTime;
        Console.WriteLine($"{instanceTime} = {otherTime}: {instanceTime.EqualsExact(otherTime)}");

        otherTime = new DateTimeOffset(instanceTime.DateTime,
                    TimeSpan.FromHours(instanceTime.Offset.Hours + 1));
        Console.WriteLine($"{instanceTime} = {otherTime}: {instanceTime.EqualsExact(otherTime)}");

        otherTime = new DateTimeOffset(instanceTime.DateTime + TimeSpan.FromHours(1),
                        TimeSpan.FromHours(instanceTime.Offset.Hours + 1));
        Console.WriteLine($"{instanceTime} = {otherTime}: {instanceTime.EqualsExact(otherTime)}");

        // The example produces the following output:
        //       10/31/2007 12:00:00 AM -07:00 = 10/31/2007 12:00:00 AM -07:00: True
        //       10/31/2007 12:00:00 AM -07:00 = 10/31/2007 12:00:00 AM -06:00: False
        //       10/31/2007 12:00:00 AM -07:00 = 10/31/2007 1:00:00 AM -06:00: False
        // </Snippet12>
    }

    private static void Subtract1()
    {
        // <Snippet13>
        DateTimeOffset firstDate = new DateTimeOffset(2018, 10, 25, 18, 0, 0,
                                                      new TimeSpan(-7, 0, 0));
        DateTimeOffset secondDate = new DateTimeOffset(2018, 10, 25, 18, 0, 0,
                                                       new TimeSpan(-5, 0, 0));
        DateTimeOffset thirdDate = new DateTimeOffset(2018, 9, 28, 9, 0, 0,
                                                      new TimeSpan(-7, 0, 0));
        TimeSpan difference;

        difference = firstDate.Subtract(secondDate);
        Console.WriteLine($"({firstDate}) - ({secondDate}): {difference.Days} days, {difference.Hours}:{difference.Minutes:d2}");

        difference = firstDate.Subtract(thirdDate);
        Console.WriteLine($"({firstDate}) - ({thirdDate}): {difference.Days} days, {difference.Hours}:{difference.Minutes:d2}");

        // The example produces the following output:
        //    (10/25/2018 6:00:00 PM -07:00) - (10/25/2018 6:00:00 PM -05:00): 0 days, 2:00
        //    (10/25/2018 6:00:00 PM -07:00) - (9/28/2018 9:00:00 AM -07:00): 27 days, 9:00
        // </Snippet13>
    }

    private static void Subtract2()
    {
        // <Snippet14>
        DateTimeOffset offsetDate = new DateTimeOffset(2007, 12, 3, 11, 30, 0,
                                       new TimeSpan(-8, 0, 0));
        TimeSpan duration = new TimeSpan(7, 18, 0, 0);
        Console.WriteLine(offsetDate.Subtract(duration).ToString());  // Displays 11/25/2007 5:30:00 PM -08:00
                                                                      // </Snippet14>
    }

    private static void ConvertToLocal()
    {
        // <Snippet15>
        // Local time changes on 3/11/2007 at 2:00 AM
        DateTimeOffset originalTime, localTime;

        originalTime = new DateTimeOffset(2007, 3, 11, 3, 0, 0,
                                          new TimeSpan(-6, 0, 0));
        localTime = originalTime.ToLocalTime();
        Console.WriteLine($"Converted {originalTime.ToString()} to {localTime.ToString()}.");

        originalTime = new DateTimeOffset(2007, 3, 11, 4, 0, 0,
                                          new TimeSpan(-6, 0, 0));
        localTime = originalTime.ToLocalTime();
        Console.WriteLine($"Converted {originalTime.ToString()} to {localTime.ToString()}.");

        // Define a summer UTC time
        originalTime = new DateTimeOffset(2007, 6, 15, 8, 0, 0,
                                          TimeSpan.Zero);
        localTime = originalTime.ToLocalTime();
        Console.WriteLine($"Converted {originalTime.ToString()} to {localTime.ToString()}.");

        // Define a winter time
        originalTime = new DateTimeOffset(2007, 11, 30, 14, 0, 0,
                                          new TimeSpan(3, 0, 0));
        localTime = originalTime.ToLocalTime();
        Console.WriteLine($"Converted {originalTime.ToString()} to {localTime.ToString()}.");

        // The example produces the following output:
        //    Converted 3/11/2007 3:00:00 AM -06:00 to 3/11/2007 1:00:00 AM -08:00.
        //    Converted 3/11/2007 4:00:00 AM -06:00 to 3/11/2007 3:00:00 AM -07:00.
        //    Converted 6/15/2007 8:00:00 AM +00:00 to 6/15/2007 1:00:00 AM -07:00.
        //    Converted 11/30/2007 2:00:00 PM +03:00 to 11/30/2007 3:00:00 AM -08:00.
        // </Snippet15>
    }

    private static void ConvertToUniversal()
    {
        // <Snippet16>
        DateTimeOffset localTime, otherTime, universalTime;

        // Define local time in local time zone
        localTime = new DateTimeOffset(new DateTime(2007, 6, 15, 12, 0, 0));
        Console.WriteLine($"Local time: {localTime}");
        Console.WriteLine();

        // Convert local time to offset 0 and assign to otherTime
        otherTime = localTime.ToOffset(TimeSpan.Zero);
        Console.WriteLine($"Other time: {otherTime}");
        Console.WriteLine($"{localTime} = {otherTime}: {localTime.Equals(otherTime)}");
        Console.WriteLine($"{localTime} exactly equals {otherTime}: {localTime.EqualsExact(otherTime)}");
        Console.WriteLine();

        // Convert other time to UTC
        universalTime = localTime.ToUniversalTime();
        Console.WriteLine($"Universal time: {universalTime}");
        Console.WriteLine($"{otherTime} = {universalTime}: {universalTime.Equals(otherTime)}");
        Console.WriteLine($"{otherTime} exactly equals {universalTime}: {universalTime.EqualsExact(otherTime)}");
        Console.WriteLine();

        // The example produces the following output to the console:
        //    Local time: 6/15/2007 12:00:00 PM -07:00
        //
        //    Other time: 6/15/2007 7:00:00 PM +00:00
        //    6/15/2007 12:00:00 PM -07:00 = 6/15/2007 7:00:00 PM +00:00: True
        //    6/15/2007 12:00:00 PM -07:00 exactly equals 6/15/2007 7:00:00 PM +00:00: False
        //
        //    Universal time: 6/15/2007 7:00:00 PM +00:00
        //    6/15/2007 7:00:00 PM +00:00 = 6/15/2007 7:00:00 PM +00:00: True
        //    6/15/2007 7:00:00 PM +00:00 exactly equals 6/15/2007 7:00:00 PM +00:00: True
        // </Snippet16>
    }
}
