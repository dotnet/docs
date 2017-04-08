' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Globalization

Module Example
   Public Sub Main()
      ' Instantiate a read-only NumberFormatInfo object.
      Dim enUS As CultureInfo = CultureInfo.CreateSpecificCulture("en-US")
      Dim nfi As NumberFormatInfo = enUS.NumberFormat

      ' Modify the relevant properties.
      nfi.NumberGroupSeparator = "-"
      nfi.NumberGroupSizes = { 3, 2, 4}
      nfi.NumberDecimalDigits = 0
      
      Dim ids() As Integer = { 111223333, 999776666 }
      
      ' Produce the result string by calling ToString.
      For Each id In ids
         Console.WriteLine(id.ToString("N", enUS))
      Next 
      Console.WriteLine()
      
      ' Produce the result string using composite formatting.
      For Each id In ids
         Console.WriteLine(String.Format(enUS, "{0:N}", id))
      Next
   End Sub
End Module
' The example displays the following output:
'       1112-23-333
'       9997-76-666
'       
'       1112-23-333
'       9997-76-666
' </Snippet2>

