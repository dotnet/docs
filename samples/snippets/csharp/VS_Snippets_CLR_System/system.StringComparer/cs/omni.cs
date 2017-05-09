//<snippet1>
// This example demonstrates members of the 
// System.StringComparer class.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

class Sample 
{
    public static void Main() 
    {
// Create a list of string.
    List<string> list = new List<string>();

// Get the tr-TR (Turkish-Turkey) culture.
    CultureInfo turkish = new CultureInfo("tr-TR");

// Get the culture that is associated with the current thread.
    CultureInfo thisCulture = Thread.CurrentThread.CurrentCulture;

// Get the standard StringComparers.
    StringComparer invCmp =   StringComparer.InvariantCulture;
    StringComparer invICCmp = StringComparer.InvariantCultureIgnoreCase;
    StringComparer currCmp = StringComparer.CurrentCulture;
    StringComparer currICCmp = StringComparer.CurrentCultureIgnoreCase;
    StringComparer ordCmp = StringComparer.Ordinal;
    StringComparer ordICCmp = StringComparer.OrdinalIgnoreCase;

// Create a StringComparer that uses the Turkish culture and ignores case.
    StringComparer turkICComp = StringComparer.Create(turkish, true);

// Define three strings consisting of different versions of the letter I.
// LATIN CAPITAL LETTER I (U+0049)
    string capitalLetterI = "I";  

// LATIN SMALL LETTER I (U+0069)
    string smallLetterI   = "i";

// LATIN SMALL LETTER DOTLESS I (U+0131)
    string smallLetterDotlessI = "\u0131";

// Add the three strings to the list.
    list.Add(capitalLetterI);
    list.Add(smallLetterI);
    list.Add(smallLetterDotlessI);

// Display the original list order.
    Display(list, "The original order of the list entries...");

// Sort the list using the invariant culture.
    list.Sort(invCmp);
    Display(list, "Invariant culture...");
    list.Sort(invICCmp);
    Display(list, "Invariant culture, ignore case...");

// Sort the list using the current culture.
    Console.WriteLine("The current culture is \"{0}\".", thisCulture.Name);
    list.Sort(currCmp);
    Display(list, "Current culture...");
    list.Sort(currICCmp);
    Display(list, "Current culture, ignore case...");

// Sort the list using the ordinal value of the character code points.
    list.Sort(ordCmp);
    Display(list, "Ordinal...");
    list.Sort(ordICCmp);
    Display(list, "Ordinal, ignore case...");

// Sort the list using the Turkish culture, which treats LATIN SMALL LETTER 
// DOTLESS I differently than LATIN SMALL LETTER I.
    list.Sort(turkICComp);
    Display(list, "Turkish culture, ignore case...");
    }

    public static void Display(List<string> lst, string title)
    {
    Char c;
    int  codePoint;
    Console.WriteLine(title);
    foreach (string s in lst)
        {
        c = s[0];
        codePoint = Convert.ToInt32(c);
        Console.WriteLine("0x{0:x}", codePoint); 
        }
    Console.WriteLine();
    }
}
/*
This code example produces the following results:

The original order of the list entries...
0x49
0x69
0x131

Invariant culture...
0x69
0x49
0x131

Invariant culture, ignore case...
0x49
0x69
0x131

The current culture is "en-US".
Current culture...
0x69
0x49
0x131

Current culture, ignore case...
0x49
0x69
0x131

Ordinal...
0x49
0x69
0x131

Ordinal, ignore case...
0x69
0x49
0x131

Turkish culture, ignore case...
0x131
0x49
0x69

*/
//</snippet1>