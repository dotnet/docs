// <Snippet18>
using System;
using System.Globalization;
using System.IO;

public class SerializeEx2
{
    public static void Main()
    {
        // Open the file and retrieve the date string.
        StreamReader sr = new StreamReader(@".\DateData.dat");
        String dateValue = sr.ReadToEnd();

        // Parse the date.
        DateTime parsedDate = DateTime.ParseExact(dateValue, "o",
                              DateTimeFormatInfo.InvariantInfo);
        // Convert it to local time.
        DateTime restoredDate = parsedDate.ToLocalTime();
        // Display information on the date and time.
        Console.WriteLine($"Deserialized date: {restoredDate:F}");
        Console.WriteLine($"Current Culture:   {CultureInfo.CurrentCulture.Name}");
        Console.WriteLine($"Time Zone:         {TimeZoneInfo.Local.DisplayName}");
    }
}
// The example displays the following output:
//    Deserialized date: lundi 18 août 2014 17:16:35
//    Current Culture:   fr-FR
//    Time Zone:         (UTC+01:00) Brussels, Copenhagen, Madrid, Paris
// </Snippet18>
