//<snippet1>
// This code example demonstrates the 
// GetSortKey() and ToString() methods, and the 
// OriginalString and KeyData properties of the 
// System.Globalization.SortKey class.

using System;
using System.Globalization;

class Sample 
{
    public static void Main() 
    {
    CompareInfo cmpi = null;
    SortKey sk1 = null;
    SortKey sk2 = null;
    string s = "ABC";
    string ignoreCase = "Ignore case";
    string useCase    = "Use case   ";

// Get a CompareInfo object for the English-Great Britain culture.
    cmpi = CompareInfo.GetCompareInfo("en-GB");

// Get a sort key that ignores case for the specified string.
    sk1 = cmpi.GetSortKey(s, CompareOptions.IgnoreCase);
// Get a sort key with no compare option for the specified string.
    sk2 = cmpi.GetSortKey(s);

// Display the original string.
    Console.WriteLine("Original string: \"{0}\"", sk1.OriginalString);
    Console.WriteLine();

// Display the the string equivalent of the two sort keys.
    Console.WriteLine("CompareInfo (culture) name: {0}", cmpi.Name);
    Console.WriteLine("ToString - {0}: \"{1}\"", ignoreCase, sk1.ToString());
    Console.WriteLine("ToString - {0}: \"{1}\"", useCase, sk2.ToString());
    Console.WriteLine();

// Display the key data of the two sort keys.
    DisplayKeyData(sk1, ignoreCase);
    DisplayKeyData(sk2, useCase);
    }

    public static void DisplayKeyData(SortKey sk, string title)
    {
    Console.Write("Key Data - {0}: ", title);
    foreach (byte keyDatum in sk.KeyData)
        Console.Write("0x{0} ", (uint)keyDatum);
    Console.WriteLine();
    }
}
/*
This code example produces the following results:

Original string: "ABC"

CompareInfo (culture) name: en-GB
ToString - Ignore case: "SortKey - 2057, IgnoreCase, ABC"
ToString - Use case   : "SortKey - 2057, None, ABC"

Key Data - Ignore case: 0x14 0x2 0x14 0x9 0x14 0x10 0x1 0x1 0x1 0x1 0x0
Key Data - Use case   : 0x14 0x2 0x14 0x9 0x14 0x10 0x1 0x1 0x18 0x18 0x18 0x1 0x1 0x0

*/
//</snippet1>