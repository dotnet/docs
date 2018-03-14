' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim value As New Date(2013, 9, 8)
      
      Dim formats() As String = { "d", "G", "g" }
      Dim culture As CultureInfo = CultureInfo.CreateSpecificCulture("en-US")
      Dim dtfi As DateTimeFormatInfo = culture.DateTimeFormat
      dtfi.DateSeparator = "-"
      
      For Each fmt In formats
         Console.WriteLine("{0}: {1}", fmt, value.ToString(fmt, dtfi))
      Next      
   End Sub
End Module

' The example displays the following output:
'       d: 9-8-2013
'       G: 9-8-2013 12:00:00 AM
'       g: 9-8-2013 12:00 AM
' </Snippet1>