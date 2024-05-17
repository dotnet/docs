// <Snippet11>
using System;
using System.Globalization;

public class Example4
{
    public static void Main()
    {
        DateTime dateValue = new DateTime(2013, 5, 18, 13, 30, 0);
        String[] formats = { "D", "f", "F" };

        CultureInfo enUS = CultureInfo.CreateSpecificCulture("en-US");
        DateTimeFormatInfo dtfi = enUS.DateTimeFormat;
        String originalLongDatePattern = dtfi.LongDatePattern;

        // Display the default form of three long date formats.
        foreach (var fmt in formats)
            Console.WriteLine(dateValue.ToString(fmt, dtfi));

        Console.WriteLine();

        // Modify the long date pattern.
        dtfi.LongDatePattern = originalLongDatePattern + " g";
        foreach (var fmt in formats)
            Console.WriteLine(dateValue.ToString(fmt, dtfi));

        Console.WriteLine();

        // Change A.D. to C.E. (for Common Era)
        dtfi.LongDatePattern = originalLongDatePattern + @" 'C.E.'";
        foreach (var fmt in formats)
            Console.WriteLine(dateValue.ToString(fmt, dtfi));
    }
}
// The example displays the following output:
//       Saturday, May 18, 2013
//       Saturday, May 18, 2013 1:30 PM
//       Saturday, May 18, 2013 1:30:00 PM
//
//       Saturday, May 18, 2013 A.D.
//       Saturday, May 18, 2013 A.D. 1:30 PM
//       Saturday, May 18, 2013 A.D. 1:30:00 PM
//
//       Saturday, May 18, 2013 C.E.
//       Saturday, May 18, 2013 C.E. 1:30 PM
//       Saturday, May 18, 2013 C.E. 1:30:00 PM
// </Snippet11>
