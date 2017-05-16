' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim value As New Date(2013, 9, 8, 14, 30, 0)
      
      Dim formats() As String = { "t", "T", "f", "F", "G", "g" }
      Dim culture As CultureInfo = CultureInfo.CreateSpecificCulture("en-US")
      Dim dtfi As DateTimeFormatInfo = culture.DateTimeFormat
      dtfi.TimeSeparator = "."
      
      For Each fmt In formats
         Console.WriteLine("{0}: {1}", fmt, value.ToString(fmt, dtfi))
      Next      
   End Sub
End Module
' The example displays the following output:
'       t: 2.30 PM
'       T: 2.30.00 PM
'       f: Sunday, September 08, 2013 2.30 PM
'       F: Sunday, September 08, 2013 2.30.00 PM
'       G: 9/8/2013 2.30.00 PM
'       g: 9/8/2013 2.30 PM
' </Snippet1>