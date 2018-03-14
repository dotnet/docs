' Visual Basic .NET Document
Option Strict On

' <Snippet8>
Imports System.Globalization
Imports System.Threading

Module Example
   Public Sub Main()
      ' Change current culture to fr-FR
      Dim originalCulture As CultureInfo = Thread.CurrentThread.CurrentCulture
      Thread.CurrentThread.CurrentCulture = New CultureInfo("fr-FR")

      Dim dateValue As Date = #6/11/2008#
      ' Display the DayOfWeek string representation
      Console.WriteLine(dateValue.DayOfWeek.ToString())     
      ' Restore original current culture
      Thread.CurrentThread.CurrentCulture = originalCulture
   End Sub
End Module
' The example displays the following output:
'       Wednesday
' </Snippet8>

Public Class Example2
   Private Sub ShowAbbreviatedWithDateTimeInfo()
     ' <Snippet3>
      Dim dateValue As Date = #6/11/2008#
      Dim dateFormats As DateTimeFormatInfo = _
                         New CultureInfo("es-ES").DateTimeFormat
      Console.WriteLine(dateValue.ToString("ddd", _
                        dateFormats))    ' Displays mer.
      ' </Snippet3>
   End Sub

End Class
