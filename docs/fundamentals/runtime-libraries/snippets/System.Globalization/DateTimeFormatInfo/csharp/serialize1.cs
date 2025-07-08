// <Snippet17>
using System;
using System.Globalization;
using System.IO;

public class SerializeEx1
{
    public static void Main()
    {
        StreamWriter sw = new StreamWriter(@".\DateData.dat");
        // Define a date and time to serialize.
        DateTime originalDate = new DateTime(2014, 08, 18, 08, 16, 35);
        // Display information on the date and time.
        Console.WriteLine($"Date to serialize: {originalDate:F}");
        Console.WriteLine($"Current Culture:   {CultureInfo.CurrentCulture.Name}");
        Console.WriteLine($"Time Zone:         {TimeZoneInfo.Local.DisplayName}");
        // Convert the date value to UTC.
        DateTime utcDate = originalDate.ToUniversalTime();
        // Serialize the UTC value.
        sw.Write(utcDate.ToString("o", DateTimeFormatInfo.InvariantInfo));
        sw.Close();
    }
}
// The example displays the following output:
//       Date to serialize: Monday, August 18, 2014 8:16:35 AM
//       Current Culture:   en-US
//       Time Zone:         (UTC-08:00) Pacific Time (US & Canada)
// </Snippet17>
