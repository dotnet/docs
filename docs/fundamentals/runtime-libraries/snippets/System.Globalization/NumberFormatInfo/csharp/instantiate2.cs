// <Snippet2>
using System;
using System.Globalization;

public class InstantiateEx2
{
    public static void Main()
    {
        NumberFormatInfo current1 = NumberFormatInfo.CurrentInfo;
        current1 = (NumberFormatInfo)current1.Clone();
        Console.WriteLine(current1.IsReadOnly);

        CultureInfo culture2 = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
        NumberFormatInfo current2 = culture2.NumberFormat;
        Console.WriteLine(current2.IsReadOnly);
    }
}
// The example displays the following output:
//       False
//       False
// </Snippet2>
