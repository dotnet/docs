' <Snippet3>
Public Enum Color
   Yellow = 1
   Blue = 2
   Green = 3
End Enum 

Public Module Example
   Private thisDate As DateTime = #06/30/2009 7:14PM#
   
   Public Sub Main()
      ' Store the output of the String.Format method in a string.
      Dim s As String = ""

      ' Format a negative integer or floating-point number in various ways.
      Console.WriteLine("Standard Numeric Format Strings")
      s = String.Format( _
                        "(C) Currency: . . . . . . . . {0:C}" & vbCrLf & _
                        "(D) Decimal:. . . . . . . . . {0:D}" & vbCrLf & _
                        "(E) Scientific: . . . . . . . {1:E}" & vbCrLf & _
                        "(F) Fixed point:. . . . . . . {1:F}" & vbCrLf & _
                        "(G) General:. . . . . . . . . {0:G}" & vbCrLf & _
                        "    (default):. . . . . . . . {0} (default = 'G')" & vbCrLf & _
                        "(N) Number: . . . . . . . . . {0:N}" & vbCrLf & _
                        "(P) Percent:. . . . . . . . . {1:P}" & vbCrLf & _
                        "(R) Round-trip: . . . . . . . {3:R}" & vbCrLf & _
                        "(X) Hexadecimal:. . . . . . . {0:X}" & vbCrLf, _
                        -123, -123.45, -.126, -1.5322980781265591)
      Console.WriteLine(s)

      ' Format a date in various ways.
      Console.WriteLine("Standard Date and Time Format Strings")
      s = String.Format( _
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

      ' Format an enumeration value in various ways.
      Console.WriteLine("Standard Enumeration Format Specifiers")
      s = String.Format( _
                        "(G) General:. . . . . . . . . {0:G}" & vbCrLf & _
                        "    (default):. . . . . . . . {0} (default = 'G')" & vbCrLf & _
                        "(F) Flags:. . . . . . . . . . {1:F}" & vbCrLf & _
                        "(D) Decimal number: . . . . . {0:D}" & vbCrLf & _
                        "(X) Hexadecimal:. . . . . . . {0:X}" & vbCrLf, _
                        Color.Green, AttributeTargets.Class Or AttributeTargets.Struct)
      Console.WriteLine(s)
   End Sub 
End Module 
' The example displays the following output:
'    Standard Numeric Format Specifiers
'    (C) Currency: . . . . . . . . ($123.00)
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
'    (d) Short date: . . . . . . . 6/30/2009
'    (D) Long date:. . . . . . . . Tuesday, June 30, 2009
'    (t) Short time: . . . . . . . 7:14 PM
'    (T) Long time:. . . . . . . . 7:14:00 PM
'    (f) Full date/short time: . . Tuesday, June 30, 2009 7:14 PM
'    (F) Full date/long time:. . . Tuesday, June 30, 2009 7:14:00 PM
'    (g) General date/short time:. 6/30/2009 7:14 PM
'    (G) General date/long time: . 6/30/2009 7:14:00 PM
'        (default):. . . . . . . . 6/30/2009 7:14:00 PM (default = 'G')
'    (M) Month:. . . . . . . . . . June 30
'    (R) RFC1123:. . . . . . . . . Tue, 30 Jun 2009 19:14:00 GMT
'    (s) Sortable: . . . . . . . . 2009-06-30T19:14:00
'    (u) Universal sortable: . . . 2009-06-30 19:14:00Z (invariant)
'    (U) Universal full: . . . . . Wednesday, July 01, 2009 2:14:00 AM
'    (Y) Year: . . . . . . . . . . June, 2009
'    
'    Standard Enumeration Format Specifiers
'    (G) General:. . . . . . . . . Green
'        (default):. . . . . . . . Green (default = 'G')
'    (F) Flags:. . . . . . . . . . Class, Struct
'    (D) Decimal number: . . . . . 3
'    (X) Hexadecimal:. . . . . . . 00000003
' </Snippet3>
