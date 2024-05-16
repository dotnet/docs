// <Snippet15>
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

public class SortKeyComparer : IComparer<String>
{
    public int Compare(string? str1, string? str2)
    {
        return (str1, str2) switch
        {
            (null, null) => 0,
            (null, _) => -1,
            (_, null) => 1,
            (var s1, var s2) => SortKey.Compare(
                CultureInfo.CurrentCulture.CompareInfo.GetSortKey(s1),
                CultureInfo.CurrentCulture.CompareInfo.GetSortKey(s1))
        };
    }
}

public class Example19
{
    public static void Main19()
    {
        string[] values = { "able", "ångström", "apple", "Æble",
                          "Windows", "Visual Studio" };
        SortKeyComparer comparer = new SortKeyComparer();

        // Change thread to en-US.
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
        // Sort the array and copy it to a new array to preserve the order.
        Array.Sort(values, comparer);
        string[] enValues = (String[])values.Clone();

        // Change culture to Swedish (Sweden).
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("sv-SE");
        Array.Sort(values, comparer);
        string[] svValues = (String[])values.Clone();

        // Compare the sorted arrays.
        Console.WriteLine("{0,-8} {1,-15} {2,-15}\n", "Position", "en-US", "sv-SE");
        for (int ctr = 0; ctr <= values.GetUpperBound(0); ctr++)
            Console.WriteLine("{0,-8} {1,-15} {2,-15}", ctr, enValues[ctr], svValues[ctr]);
    }
}

// The example displays the following output:
//       Position en-US           sv-SE
//
//       0        able            able
//       1        Æble            Æble
//       2        ångström        apple
//       3        apple           Windows
//       4        Visual Studio   Visual Studio
//       5        Windows         ångström
// </Snippet15>
