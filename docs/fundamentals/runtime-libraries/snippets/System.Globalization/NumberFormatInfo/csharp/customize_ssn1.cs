// <Snippet2>
using System;
using System.Globalization;

public class CustomizeSSNEx
{
    public static void Main()
    {
        // Instantiate a read-only NumberFormatInfo object.
        CultureInfo enUS = CultureInfo.CreateSpecificCulture("en-US");
        NumberFormatInfo nfi = enUS.NumberFormat;

        // Modify the relevant properties.
        nfi.NumberGroupSeparator = "-";
        nfi.NumberGroupSizes = new int[] { 3, 2, 4 };
        nfi.NumberDecimalDigits = 0;

        int[] ids = { 111223333, 999776666 };

        // Produce the result string by calling ToString.
        foreach (var id in ids)
            Console.WriteLine(id.ToString("N", enUS));

        Console.WriteLine();

        // Produce the result string using composite formatting.
        foreach (var id in ids)
            Console.WriteLine(String.Format(enUS, "{0:N}", id));
    }
}
// The example displays the following output:
//       1112-23-333
//       9997-76-666
//
//       1112-23-333
//       9997-76-666
// </Snippet2>
