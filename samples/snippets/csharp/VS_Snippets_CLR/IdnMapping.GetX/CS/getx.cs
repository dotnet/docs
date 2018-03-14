//<snippet1>
// This example demonstrates the GetAscii and GetUnicode methods.
// For sake of illustration, this example uses the most complex
// form of those methods, not the most convenient.

using System;
using System.Globalization;

class Sample 
{
    public static void Main() 
    {
/* 
   Define a domain name consisting of the labels: GREEK SMALL LETTER 
   PI (U+03C0); IDEOGRAPHIC FULL STOP (U+3002); GREEK SMALL LETTER 
   THETA (U+03B8); FULLWIDTH FULL STOP (U+FF0E); and "com".
*/
    string name = "\u03C0\u3002\u03B8\uFF0Ecom";
    string international;
    string nonInternational;

    string msg1 = "the original non-internationalized \ndomain name:";
    string msg2 = "Allow unassigned characters?:     {0}";
    string msg3 = "Use non-internationalized rules?: {0}";
    string msg4 = "Convert the non-internationalized domain name to international format...";
    string msg5 = "Display the encoded domain name:\n\"{0}\"";
    string msg6 = "the encoded domain name:";
    string msg7 = "Convert the internationalized domain name to non-international format...";
    string msg8 = "the reconstituted non-internationalized \ndomain name:";
    string msg9 = "Visually compare the code points of the reconstituted string to the " +
                  "original.\n" +
                  "Note that the reconstituted string contains standard label " +
                  "separators (U+002e).";
// ----------------------------------------------------------------------------
    Console.Clear();
    CodePoints(name, msg1);
// ----------------------------------------------------------------------------

    IdnMapping idn = new IdnMapping();

    Console.WriteLine(msg2, idn.AllowUnassigned);
    Console.WriteLine(msg3, idn.UseStd3AsciiRules);
    Console.WriteLine();
// ----------------------------------------------------------------------------
    Console.WriteLine(msg4);
    international = idn.GetAscii(name, 0, name.Length);
    Console.WriteLine(msg5, international);
    Console.WriteLine();
    CodePoints(international, msg6);
// ----------------------------------------------------------------------------
    Console.WriteLine(msg7);
    nonInternational = idn.GetUnicode(international, 0, international.Length);
    CodePoints(nonInternational, msg8);
    Console.WriteLine(msg9);
    }
// ----------------------------------------------------------------------------
    static void CodePoints(string value, string title)
    {
    Console.WriteLine("Display the Unicode code points of {0}", title);
    foreach (char c in value) 
        {
        Console.Write("{0:x4} ", Convert.ToInt32(c));
        }
        Console.WriteLine();
        Console.WriteLine();
    }
}
/*
This code example produces the following results:

Display the Unicode code points of the original non-internationalized
domain name:
03c0 3002 03b8 ff0e 0063 006f 006d

Allow unassigned characters?:     False
Use non-internationalized rules?: False

Convert the non-internationalized domain name to international format...
Display the encoded domain name:
"xn--1xa.xn--txa.com"

Display the Unicode code points of the encoded domain name:
0078 006e 002d 002d 0031 0078 0061 002e 0078 006e 002d 002d 0074 0078 0061 002e 0063 006f
006d

Convert the internationalized domain name to non-international format...
Display the Unicode code points of the reconstituted non-internationalized
domain name:
03c0 002e 03b8 002e 0063 006f 006d

Visually compare the code points of the reconstituted string to the original.
Note that the reconstituted string contains standard label separators (U+002e).

*/
//</snippet1>