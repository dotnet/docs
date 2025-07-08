// <Snippet4>
using System;
using System.Globalization;

public class InstantiateEx4
{
    public static void Main()
    {
        NumberFormatInfo nfi;

        nfi = System.Globalization.NumberFormatInfo.InvariantInfo;
        Console.WriteLine(nfi.IsReadOnly);

        nfi = CultureInfo.InvariantCulture.NumberFormat;
        Console.WriteLine(nfi.IsReadOnly);

        nfi = new NumberFormatInfo();
        Console.WriteLine(nfi.IsReadOnly);
    }
}
// The example displays the following output:
//       True
//       True
//       False
// </Snippet4>
