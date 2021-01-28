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

        static void ProvidesFormatInfo(object obj)
        {
            switch (obj)
            {
                case IFormatProvider fmt:
                    Console.WriteLine($"{fmt} object");
                    break;
                case null:
                    Console.Write("A null object reference: ");
                    Console.WriteLine("Its use could result in a NullReferenceException");
                    break;
                case object _:
                    Console.WriteLine("Some object type without format information");
                    break;
            }
        }
        // The example displays the following output:
        //    en-US object
        //    System.Globalization.DateTimeFormatInfo object
        //    System.Globalization.NumberFormatInfo object
        //    Some object type without format information
        //    A null object reference: Its use could result in a NullReferenceException
        // </DiscardSwitchExample>
    }
}
