'<snippet1>
' This code example demonstrates the Console.WriteLine() method.
' Formatting for this example uses the "en-US" culture.

Imports System
Imports Microsoft.VisualBasic

Class Sample
   Public Enum Color
      Yellow = 1
      Blue = 2
      Green = 3
   End Enum 'Color
   Private Shared thisDate As DateTime = DateTime.Now
   
   Public Shared Sub Main()
      Console.Clear()

      ' Format a negative integer or floating-point number in various ways.
      Console.WriteLine("Standard Numeric Format Specifiers")
      Console.WriteLine("(C) Currency: . . . . . . . . {0:C}" & vbCrLf & _
                        "(D) Decimal:. . . . . . . . . {0:D}" & vbCrLf & _
                        "(E) Scientific: . . . . . . . {1:E}" & vbCrLf & _
                        "(F) Fixed point:. . . . . . . {1:F}" & vbCrLf & _
                        "(G) General:. . . . . . . . . {0:G}" & vbCrLf & _
                        "    (default):. . . . . . . . {0} (default = 'G')" & vbCrLf & _
                        "(N) Number: . . . . . . . . . {0:N}" & vbCrLf & _
                        "(P) Percent:. . . . . . . . . {1:P}" & vbCrLf & _
                        "(R) Round-trip: . . . . . . . {1:R}" & vbCrLf & _
                        "(X) Hexadecimal:. . . . . . . {0:X}" & vbCrLf, _
                        - 123, - 123.45F)

      ' Format the current date in various ways.
      Console.WriteLine("Standard DateTime Format Specifiers")
      Console.WriteLine("(d) Short date: . . . . . . . {0:d}" & vbCrLf & _
                        "(D) Long date:. . . . . . . . {0:D}" & vbCrLf & _
                        "(t) Short time: . . . . . . . {0:t}" & vbCrLf & _
                        "(T) Long time:. . . . . . . . {0:T}" & vbCrLf & _
                        "(f) Full date/short time: . . {0:f}" & vbCrLf & _
                        "(F) Full date/long time:. . . {0:F}" & vbCrLf & _
                        "(g) General date/short time:. {0:g}" & vbCrLf & _
                        "(G) General date/long time: . {0:G}" & vbCrLf & _
                        "    (default):. . . . . . . . {0} (default = 'G')" & vbCrLf & _
                        "(M) Month:. . . . . . . . . . {0:M}" & vbCrLf & _
                        "(R) RFC1123:. . . . . . . . . {0:R}" & vbCrLf & _
                        "(s) Sortable: . . . . . . . . {0:s}" & vbCrLf & _
                        "(u) Universal sortable: . . . {0:u} (invariant)" & vbCrLf & _
                        "(U) Universal full date/time: {0:U}" & vbCrLf & _
                        "(Y) Year: . . . . . . . . . . {0:Y}" & vbCrLf, _
                        thisDate)

      ' Format a Color enumeration value in various ways.
      Console.WriteLine("Standard Enumeration Format Specifiers")
      Console.WriteLine("(G) General:. . . . . . . . . {0:G}" & vbCrLf & _
                        "    (default):. . . . . . . . {0} (default = 'G')" & vbCrLf & _
                        "(F) Flags:. . . . . . . . . . {0:F} (flags or integer)" & vbCrLf & _
                        "(D) Decimal number: . . . . . {0:D}" & vbCrLf & _
                        "(X) Hexadecimal:. . . . . . . {0:X}" & vbCrLf, _
                        Color.Green)
   End Sub 'Main
End Class 'Sample
'
'This code example produces the following results:
'
'Standard Numeric Format Specifiers
'(C) Currency: . . . . . . . . ($123.00)
'(D) Decimal:. . . . . . . . . -123
'(E) Scientific: . . . . . . . -1.234500E+002
'(F) Fixed point:. . . . . . . -123.45
'(G) General:. . . . . . . . . -123
'    (default):. . . . . . . . -123 (default = 'G')
'(N) Number: . . . . . . . . . -123.00
'(P) Percent:. . . . . . . . . -12,345.00 %
'(R) Round-trip: . . . . . . . -123.45
'(X) Hexadecimal:. . . . . . . FFFFFF85
'
'Standard DateTime Format Specifiers
'(d) Short date: . . . . . . . 6/26/2004
'(D) Long date:. . . . . . . . Saturday, June 26, 2004
'(t) Short time: . . . . . . . 8:11 PM
'(T) Long time:. . . . . . . . 8:11:04 PM
'(f) Full date/short time: . . Saturday, June 26, 2004 8:11 PM
'(F) Full date/long time:. . . Saturday, June 26, 2004 8:11:04 PM
'(g) General date/short time:. 6/26/2004 8:11 PM
'(G) General date/long time: . 6/26/2004 8:11:04 PM
'    (default):. . . . . . . . 6/26/2004 8:11:04 PM (default = 'G')
'(M) Month:. . . . . . . . . . June 26
'(R) RFC1123:. . . . . . . . . Sat, 26 Jun 2004 20:11:04 GMT
'(s) Sortable: . . . . . . . . 2004-06-26T20:11:04
'(u) Universal sortable: . . . 2004-06-26 20:11:04Z (invariant)
'(U) Universal full date/time: Sunday, June 27, 2004 3:11:04 AM
'(Y) Year: . . . . . . . . . . June, 2004
'
'Standard Enumeration Format Specifiers
'(G) General:. . . . . . . . . Green
'    (default):. . . . . . . . Green (default = 'G')
'(F) Flags:. . . . . . . . . . Green (flags or integer)
'(D) Decimal number: . . . . . 3
'(X) Hexadecimal:. . . . . . . 00000003
'
'</snippet1>
