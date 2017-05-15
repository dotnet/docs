//<snippet1>
// This example demonstrates the 
// System.String.Compare(String, String, StringComparison) method.

using System;
using System.Threading;

class Sample 
{
    public static void Main() 
    {
    string intro = "Compare three versions of the letter I using different " + 
                   "values of StringComparison.";

// Define an array of strings where each element contains a version of the 
// letter I. (An array of strings is used so you can easily modify this 
// code example to test additional or different combinations of strings.)  

    string[] threeIs = new string[3];
// LATIN SMALL LETTER I (U+0069)
    threeIs[0] = "\u0069";
// LATIN SMALL LETTER DOTLESS I (U+0131)
    threeIs[1] = "\u0131";
// LATIN CAPITAL LETTER I (U+0049)
    threeIs[2] = "\u0049";

    string[] unicodeNames = 
             {
             "LATIN SMALL LETTER I (U+0069)", 
             "LATIN SMALL LETTER DOTLESS I (U+0131)", 
             "LATIN CAPITAL LETTER I (U+0049)"
             };

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

// Determine the relative sort order of three versions of the letter I. 
    foreach (StringComparison sc in scValues)
        {
        Console.WriteLine("StringComparison.{0}:", sc);

// LATIN SMALL LETTER I (U+0069) : LATIN SMALL LETTER DOTLESS I (U+0131)
        Test(0, 1, sc, threeIs, unicodeNames);

// LATIN SMALL LETTER I (U+0069) : LATIN CAPITAL LETTER I (U+0049)
        Test(0, 2, sc, threeIs, unicodeNames);

// LATIN SMALL LETTER DOTLESS I (U+0131) : LATIN CAPITAL LETTER I (U+0049)
        Test(1, 2, sc, threeIs, unicodeNames);

        Console.WriteLine();
        }
    }

    protected static void Test(int x, int y, 
                               StringComparison comparison, 
                               string[] testI, string[] testNames)
    {
    string resultFmt = "{0} is {1} {2}";
    string result = "equal to";
    int cmpValue = 0;
//
    cmpValue = String.Compare(testI[x], testI[y], comparison);
    if      (cmpValue < 0) 
        result = "less than";
    else if (cmpValue > 0)
        result = "greater than";
    Console.WriteLine(resultFmt, testNames[x], result, testNames[y]);
    }
}

/*
This code example produces the following results:

Compare three versions of the letter I using different values of StringComparison.
The current culture is en-US.

StringComparison.CurrentCulture:
LATIN SMALL LETTER I (U+0069) is less than LATIN SMALL LETTER DOTLESS I (U+0131)
LATIN SMALL LETTER I (U+0069) is less than LATIN CAPITAL LETTER I (U+0049)
LATIN SMALL LETTER DOTLESS I (U+0131) is greater than LATIN CAPITAL LETTER I (U+0049)

StringComparison.CurrentCultureIgnoreCase:
LATIN SMALL LETTER I (U+0069) is less than LATIN SMALL LETTER DOTLESS I (U+0131)
LATIN SMALL LETTER I (U+0069) is equal to LATIN CAPITAL LETTER I (U+0049)
LATIN SMALL LETTER DOTLESS I (U+0131) is greater than LATIN CAPITAL LETTER I (U+0049)

StringComparison.InvariantCulture:
LATIN SMALL LETTER I (U+0069) is less than LATIN SMALL LETTER DOTLESS I (U+0131)
LATIN SMALL LETTER I (U+0069) is less than LATIN CAPITAL LETTER I (U+0049)
LATIN SMALL LETTER DOTLESS I (U+0131) is greater than LATIN CAPITAL LETTER I (U+0049)

StringComparison.InvariantCultureIgnoreCase:
LATIN SMALL LETTER I (U+0069) is less than LATIN SMALL LETTER DOTLESS I (U+0131)
LATIN SMALL LETTER I (U+0069) is equal to LATIN CAPITAL LETTER I (U+0049)
LATIN SMALL LETTER DOTLESS I (U+0131) is greater than LATIN CAPITAL LETTER I (U+0049)

StringComparison.Ordinal:
LATIN SMALL LETTER I (U+0069) is less than LATIN SMALL LETTER DOTLESS I (U+0131)
LATIN SMALL LETTER I (U+0069) is greater than LATIN CAPITAL LETTER I (U+0049)
LATIN SMALL LETTER DOTLESS I (U+0131) is greater than LATIN CAPITAL LETTER I (U+0049)

StringComparison.OrdinalIgnoreCase:
LATIN SMALL LETTER I (U+0069) is less than LATIN SMALL LETTER DOTLESS I (U+0131)
LATIN SMALL LETTER I (U+0069) is equal to LATIN CAPITAL LETTER I (U+0049)
LATIN SMALL LETTER DOTLESS I (U+0131) is greater than LATIN CAPITAL LETTER I (U+0049)

*/
//</snippet1>