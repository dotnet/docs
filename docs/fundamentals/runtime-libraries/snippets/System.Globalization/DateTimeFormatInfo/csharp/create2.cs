using System;
using System.Globalization;

public class Create2Ex
{
    public static void Main()
    {
        // <Snippet4>
        DateTimeFormatInfo dtfi;

        dtfi = DateTimeFormatInfo.CurrentInfo;
        Console.WriteLine(dtfi.IsReadOnly);

        dtfi = CultureInfo.CurrentCulture.DateTimeFormat;
        Console.WriteLine(dtfi.IsReadOnly);

        dtfi = DateTimeFormatInfo.GetInstance(CultureInfo.CurrentCulture);
        Console.WriteLine(dtfi.IsReadOnly);
        // The example displays the following output:
        //     True
        //     True
        //     True
        // </Snippet4>
    }
}
