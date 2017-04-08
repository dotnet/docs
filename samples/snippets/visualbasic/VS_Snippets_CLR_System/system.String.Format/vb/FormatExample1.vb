' <Snippet1>
' This code example demonstrates the String.Format() method.
' This example uses the provider parameter to supply formatting 
' information using the invariant culture.

Imports System.Globalization

Class Sample
   Public Enum Color
      Yellow = 1
      Blue = 2
      Green = 3
   End Enum 'Color

   Private Shared thisDate As DateTime = DateTime.Now
   
   Public Shared Sub Main()

      ' Store the output of the String.Format method in a string.
      Dim s As String = ""

      Console.Clear()

      ' Format a negative integer or floating-point number in various ways.
      Console.WriteLine("Standard Numeric Format Specifiers")
      s = String.Format(CultureInfo.InvariantCulture, _
                        "(C) Currency: . . . . . . . . {0:C}" & vbCrLf & _
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
      Console.WriteLine(s)

      ' Format the current date in various ways.
      Console.WriteLine("Standard DateTime Format Specifiers")
      s = String.Format(CultureInfo.InvariantCulture.DateTimeFormat, _
                        "(d) Short date: . . . . . . . {0:d}" & vbCrLf & _
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
                        "(U) Universal full: . . . . . {0:U}" & vbCrLf & _
                        "(Y) Year: . . . . . . . . . . {0:Y}" & vbCrLf, _
                        thisDate)
      Console.WriteLine(s)

      ' Format a Color enumeration value in various ways.
      Console.WriteLine("Standard Enumeration Format Specifiers")
      s = String.Format(CultureInfo.InvariantCulture, _
                        "(G) General:. . . . . . . . . {0:G}" & vbCrLf & _
                        "    (default):. . . . . . . . {0} (default = 'G')" & vbCrLf & _
                        "(F) Flags:. . . . . . . . . . {0:F} (flags or integer)" & vbCrLf & _
                        "(D) Decimal number: . . . . . {0:D}" & vbCrLf & _
                        "(X) Hexadecimal:. . . . . . . {0:X}" & vbCrLf, _
                        Color.Green)
      Console.WriteLine(s)
   End Sub 'Main
End Class 'Sample
'
' This example displays the following output to the console:
'
'    Standard Numeric Format Specifiers
'    (C) Currency: . . . . . . . . (¤123.00)
'    (D) Decimal:. . . . . . . . . -123
'    (E) Scientific: . . . . . . . -1.234500E+002
'    (F) Fixed point:. . . . . . . -123.45
'    (G) General:. . . . . . . . . -123
'        (default):. . . . . . . . -123 (default = 'G')
'    (N) Number: . . . . . . . . . -123.00
'    (P) Percent:. . . . . . . . . -12,345.00 %
'    (R) Round-trip: . . . . . . . -123.45
'    (X) Hexadecimal:. . . . . . . FFFFFF85
'    
'    Standard DateTime Format Specifiers
'    (d) Short date: . . . . . . . 07/09/2007
'    (D) Long date:. . . . . . . . Monday, 09 July 2007
'    (t) Short time: . . . . . . . 13:42
'    (T) Long time:. . . . . . . . 13:42:50
'    (f) Full date/short time: . . Monday, 09 July 2007 13:42
'    (F) Full date/long time:. . . Monday, 09 July 2007 13:42:50
'    (g) General date/short time:. 07/09/2007 13:42
'    (G) General date/long time: . 07/09/2007 13:42:50
'        (default):. . . . . . . . 07/09/2007 13:42:50 (default = 'G')
'    (M) Month:. . . . . . . . . . July 09
'    (R) RFC1123:. . . . . . . . . Mon, 09 Jul 2007 13:42:50 GMT
'    (s) Sortable: . . . . . . . . 2007-07-09T13:42:50
'    (u) Universal sortable: . . . 2007-07-09 13:42:50Z (invariant)
'    (U) Universal full: . . . . . Monday, 09 July 2007 20:42:50
'    (Y) Year: . . . . . . . . . . 2007 July
'    
'    Standard Enumeration Format Specifiers
'    (G) General:. . . . . . . . . Green
'        (default):. . . . . . . . Green (default = 'G')
'    (F) Flags:. . . . . . . . . . Green (flags or integer)
'    (D) Decimal number: . . . . . 3
'    (X) Hexadecimal:. . . . . . . 00000003
' </Snippet1>
