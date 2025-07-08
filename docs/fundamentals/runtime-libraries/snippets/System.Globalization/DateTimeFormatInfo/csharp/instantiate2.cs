// <Snippet7>
using System;
using System.Globalization;

public class InstantiateEx1
{
    public static void Main()
    {
        DateTimeFormatInfo current1 = DateTimeFormatInfo.CurrentInfo;
        current1 = (DateTimeFormatInfo)current1.Clone();
        Console.WriteLine(current1.IsReadOnly);

        CultureInfo culture2 = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
        DateTimeFormatInfo current2 = culture2.DateTimeFormat;
        Console.WriteLine(current2.IsReadOnly);
    }
}
// The example displays the following output:
//       False
//       False
// </Snippet7>
