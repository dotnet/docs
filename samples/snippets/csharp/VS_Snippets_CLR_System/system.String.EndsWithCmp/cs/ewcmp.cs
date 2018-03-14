//<snippet1>
// This example demonstrates the 
// System.String.EndsWith(String, StringComparison) method.

using System;
using System.Threading;

class Sample 
{
    public static void Main() 
    {
    string intro = "Determine whether a string ends with another string, " +
                   "using\n  different values of StringComparison.";

    StringComparison[] scValues = {
        StringComparison.CurrentCulture,
        StringComparison.CurrentCultureIgnoreCase,
        StringComparison.InvariantCulture,
        StringComparison.InvariantCultureIgnoreCase,
        StringComparison.Ordinal,
        StringComparison.OrdinalIgnoreCase };

//
    Console.Clear();
    Console.WriteLine(intro);

// Display the current culture because the culture-specific comparisons
// can produce different results with different cultures.
    Console.WriteLine("The current culture is {0}.\n", 
                       Thread.CurrentThread.CurrentCulture.Name);

// Determine whether three versions of the letter I are equal to each other. 
    foreach (StringComparison sc in scValues)
        {
        Console.WriteLine("StringComparison.{0}:", sc);
        Test("abcXYZ", "XYZ", sc);
        Test("abcXYZ", "xyz", sc);
        Console.WriteLine();
        }
    }

    protected static void Test(string x, string y, StringComparison comparison)
    {
    string resultFmt = "\"{0}\" {1} with \"{2}\".";
    string result = "does not end";
//
    if (x.EndsWith(y, comparison))
        result = "ends";
    Console.WriteLine(resultFmt, x, result, y);
    }
}

/*
This code example produces the following results:

Determine whether a string ends with another string, using
  different values of StringComparison.
The current culture is en-US.

StringComparison.CurrentCulture:
"abcXYZ" ends with "XYZ".
"abcXYZ" does not end with "xyz".

StringComparison.CurrentCultureIgnoreCase:
"abcXYZ" ends with "XYZ".
"abcXYZ" ends with "xyz".

StringComparison.InvariantCulture:
"abcXYZ" ends with "XYZ".
"abcXYZ" does not end with "xyz".

StringComparison.InvariantCultureIgnoreCase:
"abcXYZ" ends with "XYZ".
"abcXYZ" ends with "xyz".

StringComparison.Ordinal:
"abcXYZ" ends with "XYZ".
"abcXYZ" does not end with "xyz".

StringComparison.OrdinalIgnoreCase:
"abcXYZ" ends with "XYZ".
"abcXYZ" ends with "xyz".

*/
//</snippet1>