//<snippet1>
// This code example demonstrates the CompareInfo.Compare() and
// SortKey.Compare() methods.

using System;
using System.Globalization;

class Sample 
{
    public static void Main() 
    {
    string lowerABC = "abc";
    string upperABC = "ABC";
    int result = 0;

// Create a CompareInfo object for the en-US culture.
    Console.WriteLine("\nCreate a CompareInfo object for the en-US culture...\n");
    CompareInfo cmpi = CompareInfo.GetCompareInfo("en-US");
// Alternatively:
//  CompareInfo cmpi = new CultureInfo("en-US").CompareInfo;

// Create sort keys for lowercase and uppercase "abc", the en-US culture, and 
// ignore case. 
    SortKey sk1LowerIgnCase = cmpi.GetSortKey(lowerABC, CompareOptions.IgnoreCase);
    SortKey sk2UpperIgnCase = cmpi.GetSortKey(upperABC, CompareOptions.IgnoreCase);

// Create sort keys for lowercase and uppercase "abc", the en-US culture, and 
// use case. 
    SortKey sk1LowerUseCase = cmpi.GetSortKey(lowerABC, CompareOptions.None);
    SortKey sk2UpperUseCase = cmpi.GetSortKey(upperABC, CompareOptions.None);

// Compare lowercase and uppercase "abc", ignoring case and using CompareInfo.
    result = cmpi.Compare(lowerABC, upperABC, CompareOptions.IgnoreCase);
    Display(result, "CompareInfo, Ignore case", lowerABC, upperABC);
// Compare lowercase and uppercase "abc", ignoring case and using SortKey.
    result = SortKey.Compare(sk1LowerIgnCase, sk2UpperIgnCase);
    Display(result, "SortKey, Ignore case", lowerABC, upperABC);
    Console.WriteLine();

// Compare lowercase and uppercase "abc", using case and using CompareInfo.
    result = cmpi.Compare(lowerABC, upperABC, CompareOptions.None);
    Display(result, "CompareInfo, Use case", lowerABC, upperABC);
// Compare lowercase and uppercase "abc", using case and using SortKey.
    result = SortKey.Compare(sk1LowerUseCase, sk2UpperUseCase);
    Display(result, "SortKey, Use case", lowerABC, upperABC);
    }

// Display the results of a comparison.
    private static void Display(int compareResult, string title, 
                                string lower, string upper)
    {
    string lessThan    = "less than ";
    string equalTo     = "equal to ";
    string greaterThan = "greater than ";
    string resultPhrase = null;
    string format = "{0}:\n    \"{1}\" is {2}\"{3}\".";

    if      (compareResult < 0) resultPhrase = lessThan;
    else if (compareResult > 0) resultPhrase = greaterThan;
    else                        resultPhrase = equalTo;
    Console.WriteLine(format, title, lower, resultPhrase, upper);
    }
}
/*
This code example produces the following results:

Create a CompareInfo object for the en-US culture...

CompareInfo, Ignore case:
    "abc" is equal to "ABC".
SortKey, Ignore case:
    "abc" is equal to "ABC".

CompareInfo, Use case:
    "abc" is less than "ABC".
SortKey, Use case:
    "abc" is less than "ABC".

*/
//</snippet1>