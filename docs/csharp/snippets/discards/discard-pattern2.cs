using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

public class DiscardPatternMatching
{
    public static void DiscardSwitchExample()
    {
        // <DiscardSwitchExample>
        object[] objects = { CultureInfo.CurrentCulture,
                           CultureInfo.CurrentCulture.DateTimeFormat,
                           CultureInfo.CurrentCulture.NumberFormat,
                           new ArgumentException(), null };
        foreach (var obj in objects)
            ProvidesFormatInfo(obj);

        static void ProvidesFormatInfo(object obj) =>
            Console.WriteLine(obj switch
            {
                IFormatProvider fmt => $"{fmt.GetType()} object",
                null => "A null object reference: Its use could result in a NullReferenceException",
                _ => "Some object type without format information"
            });
        // The example displays the following output:
        //    System.Globalization.CultureInfo object
        //    System.Globalization.DateTimeFormatInfo object
        //    System.Globalization.NumberFormatInfo object
        //    Some object type without format information
        //    A null object reference: Its use could result in a NullReferenceException
        // </DiscardSwitchExample>
    }
}
