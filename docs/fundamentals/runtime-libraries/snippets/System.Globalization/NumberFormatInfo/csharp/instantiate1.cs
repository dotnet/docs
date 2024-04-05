// <Snippet1>
using System;
using System.Globalization;

public class InstantiateEx1
{
    public static void Main()
    {
        NumberFormatInfo current1 = CultureInfo.CurrentCulture.NumberFormat;
        Console.WriteLine(current1.IsReadOnly);

        NumberFormatInfo current2 = NumberFormatInfo.CurrentInfo;
        Console.WriteLine(current2.IsReadOnly);

        NumberFormatInfo current3 = NumberFormatInfo.GetInstance(CultureInfo.CurrentCulture);
        Console.WriteLine(current3.IsReadOnly);
    }
}
// The example displays the following output:
//       True
//       True
//       True
// </Snippet1>
