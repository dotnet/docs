//<snippet1>
// This example demonstrates the NativeDigits property.

using System;
using System.Globalization;
using System.Threading;

class Sample 
{
    public static void Main() 
    {
    CultureInfo currentCI = Thread.CurrentThread.CurrentCulture;
    NumberFormatInfo nfi = currentCI.NumberFormat;
    string[] nativeDigitList = nfi.NativeDigits;

    Console.WriteLine("The native digits for the {0} culture are:", currentCI.Name);
    foreach (string s in nativeDigitList)
        {
        Console.Write("\"{0}\" ", s);
        }
    Console.WriteLine();
    }
}
/*
This code example produces the following results:

The native digits for the en-US culture are:
"0" "1" "2" "3" "4" "5" "6" "7" "8" "9"

*/
//</snippet1>