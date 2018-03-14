' Visual Basic .NET Document
Option Strict On
' <Snippet12>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim dateValue As New Date(2013, 08, 28) 
      Dim frFR As CultureInfo = CultureInfo.CreateSpecificCulture("fr-FR")
      Dim dtfi As DateTimeFormatInfo = frFR.DateTimeFormat
      
      Console.WriteLine("Before modifying DateSeparator property: {0}",
                        dateValue.ToString("g", frFR))
      
      ' Modify the date separator.
      dtfi.DateSeparator = "-"
      Console.WriteLine("After modifying the DateSeparator property: {0}",
                        dateValue.ToString("g", frFR))
   End Sub
End Module
' The example displays the following output:
'       Before modifying DateSeparator property: 28/08/2013 00:00
'       After modifying the DateSeparator property: 28-08-2013 00:00
' </Snippet12>
