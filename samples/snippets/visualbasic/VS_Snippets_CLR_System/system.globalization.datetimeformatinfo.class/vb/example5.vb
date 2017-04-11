' Visual Basic .NET Document
Option Strict On

' <Snippet14>
Imports System.Globalization
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim enUS As CultureInfo = CultureInfo.CreateSpecificCulture("en-US")
      Dim dtfi As DateTimeFormatInfo = enUS.DateTimeFormat

      Console.WriteLine("Original Property Values:")
      Console.WriteLine("ShortTimePattern: " + dtfi.ShortTimePattern)
      Console.WriteLine("LongTimePattern: " + dtfi.LongTimePattern)
      Console.WriteLine("FullDateTimePattern: " + dtfi.FullDateTimePattern)
      Console.WriteLine()
      
      dtfi.LongTimePattern = ReplaceWith24HourClock(dtfi.LongTimePattern)
      dtfi.ShortTimePattern = ReplaceWith24HourClock(dtfi.ShortTimePattern)
      
      Console.WriteLine("Modififed Property Values:")
      Console.WriteLine("ShortTimePattern: " + dtfi.ShortTimePattern)
      Console.WriteLine("LongTimePattern: " + dtfi.LongTimePattern)
      Console.WriteLine("FullDateTimePattern: " + dtfi.FullDateTimePattern)
   End Sub
   
   Private Function ReplaceWith24HourClock(fmt As String) As String
      Dim pattern As String = "^(?<openAMPM>\s*t+\s*)? " +
                              "(?(openAMPM) h+(?<nonHours>[^ht]+)$ " +
                              "| \s*h+(?<nonHours>[^ht]+)\s*t+)"
      Return Regex.Replace(fmt, pattern, "HH${nonHours}", RegexOptions.IgnorePatternWhitespace)   
   End Function
End Module
' The example displays the following output:
'       Original Property Values:
'       ShortTimePattern: h:mm tt
'       LongTimePattern: h:mm:ss tt
'       FullDateTimePattern: dddd, MMMM dd, yyyy h:mm:ss tt
'       
'       Modififed Property Values:
'       ShortTimePattern: HH:mm
'       LongTimePattern: HH:mm:ss
'       FullDateTimePattern: dddd, MMMM dd, yyyy HH:mm:ss
' </Snippet14>

