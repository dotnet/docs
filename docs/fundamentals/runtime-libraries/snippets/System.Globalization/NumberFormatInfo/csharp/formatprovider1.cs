// <Snippet1>
using System;
using System.Globalization;

public class CurrentCultureFormatProvider : IFormatProvider
{
    public Object GetFormat(Type formatType)
    {
        Console.WriteLine($"Requesting an object of type {formatType.Name}");
        if (formatType == typeof(NumberFormatInfo))
            return NumberFormatInfo.CurrentInfo;
        else if (formatType == typeof(DateTimeFormatInfo))
            return DateTimeFormatInfo.CurrentInfo;
        else
            return null;
    }
}

public class FormatProviderEx
{
    public static void Main()
    {
        Decimal amount = 1203.541m;
        string value = amount.ToString("C2", new CurrentCultureFormatProvider());
        Console.WriteLine(value);
        Console.WriteLine();
        string composite = String.Format(new CurrentCultureFormatProvider(),
                                         "Date: {0}   Amount: {1}   Description: {2}",
                                         DateTime.Now, 1264.03m, "Service Charge");
        Console.WriteLine(composite);
        Console.WriteLine();
    }
}
// The example displays output like the following:
//    Requesting an object of type NumberFormatInfo
//    $1,203.54
//
//    Requesting an object of type ICustomFormatter
//    Requesting an object of type DateTimeFormatInfo
//    Requesting an object of type NumberFormatInfo
//    Date: 11/15/2012 2:00:01 PM   Amount: 1264.03   Description: Service Charge
// </Snippet1>
