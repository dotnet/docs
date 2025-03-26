using System;
using System.Globalization;
using System.IO;

public class Class1
{
    public static void Main()
    {
        RoundTripDateTime();
        Console.WriteLine();
        RoundTripDateTimeOffset();
        Console.WriteLine();
    }

    private static void RoundTripDateTime()
    {
        // <Snippet1>
        const string fileName = @".\DateFile.txt";

        StreamWriter outFile = new StreamWriter(fileName);

        // Save DateTime value.
        DateTime dateToSave = DateTime.SpecifyKind(new DateTime(2008, 6, 12, 18, 45, 15),
                                                   DateTimeKind.Local);
        string? dateString = dateToSave.ToString("o");
        Console.WriteLine($"Converted {dateToSave.ToString()} ({dateToSave.Kind.ToString()}) to {dateString}.");
        outFile.WriteLine(dateString);
        Console.WriteLine($"Wrote {dateString} to {fileName}.");
        outFile.Close();

        // Restore DateTime value.
        DateTime restoredDate;

        using StreamReader inFile = new StreamReader(fileName);
        dateString = inFile.ReadLine();

        if (dateString is not null)
        {
            restoredDate = DateTime.Parse(dateString, null, DateTimeStyles.RoundtripKind);
            Console.WriteLine($"Read {restoredDate.ToString()} ({restoredDate.Kind.ToString()}) from {fileName}.");
        }

        // The example displays the following output:
        //    Converted 6/12/2008 6:45:15 PM (Local) to 2008-06-12T18:45:15.0000000-05:00.
        //    Wrote 2008-06-12T18:45:15.0000000-05:00 to .\DateFile.txt.
        //    Read 6/12/2008 6:45:15 PM (Local) from .\DateFile.txt.
        // </Snippet1>
    }

    private static void RoundTripDateTimeOffset()
    {
        // <Snippet2>
        const string fileName = @".\DateOff.txt";

        StreamWriter outFile = new StreamWriter(fileName);

        // Save DateTime value.
        DateTimeOffset dateToSave = new DateTimeOffset(2008, 6, 12, 18, 45, 15,
                                                       new TimeSpan(7, 0, 0));
        string? dateString = dateToSave.ToString("o");
        Console.WriteLine($"Converted {dateToSave.ToString()} to {dateString}.");
        outFile.WriteLine(dateString);
        Console.WriteLine($"Wrote {dateString} to {fileName}.");
        outFile.Close();

        // Restore DateTime value.
        DateTimeOffset restoredDateOff;

        using StreamReader inFile = new StreamReader(fileName);
        dateString = inFile.ReadLine();

        if (dateString is not null)
        {
            restoredDateOff = DateTimeOffset.Parse(dateString, null,
                                                   DateTimeStyles.RoundtripKind);
            Console.WriteLine($"Read {restoredDateOff.ToString()} from {fileName}.");
        }

        // The example displays the following output:
        //    Converted 6/12/2008 6:45:15 PM +07:00 to 2008-06-12T18:45:15.0000000+07:00.
        //    Wrote 2008-06-12T18:45:15.0000000+07:00 to .\DateOff.txt.
        //    Read 6/12/2008 6:45:15 PM +07:00 from .\DateOff.txt.
        // </Snippet2>
    }
}

// <Snippet3>
[Serializable]
public class DateInTimeZone
{
    private TimeZoneInfo? tz;
    private DateTimeOffset thisDate;

    public DateInTimeZone() { }

    public DateInTimeZone(DateTimeOffset date, TimeZoneInfo timeZone)
    {
        if (timeZone is null)
            throw new ArgumentNullException("timeZone", "The time zone cannot be null.");

        this.thisDate = date;
        this.tz = timeZone;
    }

    public DateTimeOffset DateAndTime
    {
        get
        {
            return thisDate;
        }
        set
        {
            if ((tz is not null) && (value.Offset != tz.GetUtcOffset(value)))
                thisDate = TimeZoneInfo.ConvertTime(value, tz);
            else
                thisDate = value;
        }
    }

    public TimeZoneInfo? TimeZone => tz;
}
// </Snippet3>
