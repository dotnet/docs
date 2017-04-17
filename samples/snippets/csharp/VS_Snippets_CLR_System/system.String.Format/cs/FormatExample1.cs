// <Snippet1>
// This code example demonstrates the String.Format() method.
// Formatting for this example uses the "en-US" culture.

using System;
using System.Globalization;

class Sample 
{
    enum Color {Yellow = 1, Blue, Green};
    static DateTime thisDate = DateTime.Now;

    public static void Main() 
    {
// Store the output of the String.Format method in a string.
    string s = "";

    Console.Clear();

// Format a negative integer or floating-point number in various ways.
    Console.WriteLine("Standard Numeric Format Specifiers");
    s = String.Format(CultureInfo.InvariantCulture, 
        "(C) Currency: . . . . . . . . {0:C}\n" +
        "(D) Decimal:. . . . . . . . . {0:D}\n" +
        "(E) Scientific: . . . . . . . {1:E}\n" +
        "(F) Fixed point:. . . . . . . {1:F}\n" +
        "(G) General:. . . . . . . . . {0:G}\n" +
        "    (default):. . . . . . . . {0} (default = 'G')\n" +
        "(N) Number: . . . . . . . . . {0:N}\n" +
        "(P) Percent:. . . . . . . . . {1:P}\n" +
        "(R) Round-trip: . . . . . . . {1:R}\n" +
        "(X) Hexadecimal:. . . . . . . {0:X}\n",
        -123, -123.45f); 
    Console.WriteLine(s);

// Format the current date in various ways.
    Console.WriteLine("Standard DateTime Format Specifiers");
    s = String.Format(CultureInfo.InvariantCulture.DateTimeFormat, 
        "(d) Short date: . . . . . . . {0:d}\n" +
        "(D) Long date:. . . . . . . . {0:D}\n" +
        "(t) Short time: . . . . . . . {0:t}\n" +
        "(T) Long time:. . . . . . . . {0:T}\n" +
        "(f) Full date/short time: . . {0:f}\n" +
        "(F) Full date/long time:. . . {0:F}\n" +
        "(g) General date/short time:. {0:g}\n" +
        "(G) General date/long time: . {0:G}\n" +
        "    (default):. . . . . . . . {0} (default = 'G')\n" +
        "(M) Month:. . . . . . . . . . {0:M}\n" +
        "(R) RFC1123:. . . . . . . . . {0:R}\n" +
        "(s) Sortable: . . . . . . . . {0:s}\n" +
        "(u) Universal sortable: . . . {0:u} (invariant)\n" +
        "(U) Universal full: . . . . . {0:U}\n" +
        "(Y) Year: . . . . . . . . . . {0:Y}\n", 
        thisDate);
    Console.WriteLine(s);

// Format a Color enumeration value in various ways.
    Console.WriteLine("Standard Enumeration Format Specifiers");
    s = String.Format(CultureInfo.InvariantCulture, 
        "(G) General:. . . . . . . . . {0:G}\n" +
        "    (default):. . . . . . . . {0} (default = 'G')\n" +
        "(F) Flags:. . . . . . . . . . {0:F} (flags or integer)\n" +
        "(D) Decimal number: . . . . . {0:D}\n" +
        "(X) Hexadecimal:. . . . . . . {0:X}\n", 
        Color.Green);       
    Console.WriteLine(s);
    }
}
/*
This example displays the following output to the console:

Standard Numeric Format Specifiers
(C) Currency: . . . . . . . . (¤123.00)
(D) Decimal:. . . . . . . . . -123
(E) Scientific: . . . . . . . -1.234500E+002
(F) Fixed point:. . . . . . . -123.45
(G) General:. . . . . . . . . -123
    (default):. . . . . . . . -123 (default = 'G')
(N) Number: . . . . . . . . . -123.00
(P) Percent:. . . . . . . . . -12,345.00 %
(R) Round-trip: . . . . . . . -123.45
(X) Hexadecimal:. . . . . . . FFFFFF85

Standard DateTime Format Specifiers
(d) Short date: . . . . . . . 07/09/2007
(D) Long date:. . . . . . . . Monday, 09 July 2007
(t) Short time: . . . . . . . 13:48
(T) Long time:. . . . . . . . 13:48:05
(f) Full date/short time: . . Monday, 09 July 2007 13:48
(F) Full date/long time:. . . Monday, 09 July 2007 13:48:05
(g) General date/short time:. 07/09/2007 13:48
(G) General date/long time: . 07/09/2007 13:48:05
    (default):. . . . . . . . 07/09/2007 13:48:05 (default = 'G')
(M) Month:. . . . . . . . . . July 09
(R) RFC1123:. . . . . . . . . Mon, 09 Jul 2007 13:48:05 GMT
(s) Sortable: . . . . . . . . 2007-07-09T13:48:05
(u) Universal sortable: . . . 2007-07-09 13:48:05Z (invariant)
(U) Universal full: . . . . . Monday, 09 July 2007 20:48:05
(Y) Year: . . . . . . . . . . 2007 July

Standard Enumeration Format Specifiers
(G) General:. . . . . . . . . Green
    (default):. . . . . . . . Green (default = 'G')
(F) Flags:. . . . . . . . . . Green (flags or integer)
(D) Decimal number: . . . . . 3
(X) Hexadecimal:. . . . . . . 00000003
*/
// </Snippet1>
