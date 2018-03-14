' Visual Basic .NET Document
Option Strict On

' <Snippet13>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim value As New Date(2013, 7, 9)
      Dim enUS As CultureInfo = CultureInfo.CreateSpecificCulture("en-US")
      Dim dtfi As DateTimeFormatInfo = enUS.DateTimeFormat
      Dim formats() As String = { "D", "F", "f" }

      ' Display date before modifying properties.
      For Each fmt In formats
         Console.WriteLine("{0}: {1}", fmt, value.ToString(fmt, dtfi))
      Next
      Console.WriteLine()
      
      ' We don't want to change the FullDateTimePattern, so we need to save it.
      Dim originalFullDateTimePattern As String = dtfi.FullDateTimePattern
      
      ' Modify day name abbreviations and long date pattern.
      dtfi.AbbreviatedDayNames = { "Su", "M", "Tu", "W", "Th", "F", "Sa" }
      dtfi.LongDatePattern = "ddd dd-MMM-yyyy"
      dtfi.FullDateTimePattern = originalFullDateTimePattern
      For Each fmt In formats
         Console.WriteLine("{0}: {1}", fmt, value.ToString(fmt, dtfi))
      Next
   End Sub
End Module
' The example displays the following output:
'       D: Tuesday, July 09, 2013
'       F: Tuesday, July 09, 2013 12:00:00 AM
'       f: Tuesday, July 09, 2013 12:00 AM
'       
'       D: Tu 09-Jul-2013
'       F: Tuesday, July 09, 2013 12:00:00 AM
'       f: Tu 09-Jul-2013 12:00 AM
' </Snippet13>
