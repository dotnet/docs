// <Snippet1>
// This code example demonstrates the Console.WriteLine() method.
// Formatting for this example uses the "en-US" culture.

using namespace System;

public enum class Color {Yellow = 1, Blue, Green};

int main() 
{
    DateTime thisDate = DateTime::Now;
    Console::Clear();

    // Format a negative integer or floating-point number in various ways.
    Console::WriteLine("Standard Numeric Format Specifiers");
    Console::WriteLine(
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

    // Format the current date in various ways.
    Console::WriteLine("Standard DateTime Format Specifiers");
    Console::WriteLine(
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
        "(U) Universal full date/time: {0:U}\n" +
        "(Y) Year: . . . . . . . . . . {0:Y}\n", 
        thisDate);

    // Format a Color enumeration value in various ways.
    Console::WriteLine("Standard Enumeration Format Specifiers");
    Console::WriteLine(
        "(G) General:. . . . . . . . . {0:G}\n" +
        "    (default):. . . . . . . . {0} (default = 'G')\n" +
        "(F) Flags:. . . . . . . . . . {0:F} (flags or integer)\n" +
        "(D) Decimal number: . . . . . {0:D}\n" +
        "(X) Hexadecimal:. . . . . . . {0:X}\n", 
        Color::Green);       

};


/*
This code example produces the following results:

Standard Numeric Format Specifiers
(C) Currency: . . . . . . . . ($123.00)
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
(d) Short date: . . . . . . . 6/26/2004
(D) Long date:. . . . . . . . Saturday, June 26, 2004
(t) Short time: . . . . . . . 8:11 PM
(T) Long time:. . . . . . . . 8:11:04 PM
(f) Full date/short time: . . Saturday, June 26, 2004 8:11 PM
(F) Full date/long time:. . . Saturday, June 26, 2004 8:11:04 PM
(g) General date/short time:. 6/26/2004 8:11 PM
(G) General date/long time: . 6/26/2004 8:11:04 PM
(default):. . . . . . . . 6/26/2004 8:11:04 PM (default = 'G')
(M) Month:. . . . . . . . . . June 26
(R) RFC1123:. . . . . . . . . Sat, 26 Jun 2004 20:11:04 GMT
(s) Sortable: . . . . . . . . 2004-06-26T20:11:04
(u) Universal sortable: . . . 2004-06-26 20:11:04Z (invariant)
(U) Universal full date/time: Sunday, June 27, 2004 3:11:04 AM
(Y) Year: . . . . . . . . . . June, 2004

Standard Enumeration Format Specifiers
(G) General:. . . . . . . . . Green
(default):. . . . . . . . Green (default = 'G')
(F) Flags:. . . . . . . . . . Green (flags or integer)
(D) Decimal number: . . . . . 3
(X) Hexadecimal:. . . . . . . 00000003

*/
// </Snippet1>