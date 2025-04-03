// <Snippet9>
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

public class FormatProviderEx1
{
    public static void Main()
    {
        DateTime dateValue = new DateTime(2013, 5, 28, 13, 30, 0);
        string value = dateValue.ToString("F", new CurrentCultureFormatProvider());
        Console.WriteLine(value);
        Console.WriteLine();
        string composite = String.Format(new CurrentCultureFormatProvider(),
                                         "Date: {0:d}   Amount: {1:C}   Description: {2}",
                                         dateValue, 1264.03m, "Service Charge");
        Console.WriteLine(composite);
        Console.WriteLine();
    }
}
// The example displays output like the following:
//       Requesting an object of type DateTimeFormatInfo
//       Tuesday, May 28, 2013 1:30:00 PM
//
//       Requesting an object of type ICustomFormatter
//       Requesting an object of type DateTimeFormatInfo
//       Requesting an object of type NumberFormatInfo
//       Date: 5/28/2013   Amount: $1,264.03   Description: Service Charge
// </Snippet9>
