' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim dateValue As Date = #6/11/2008#
      Console.WriteLine(dateValue.ToString("dddd", _
                        New CultureInfo("es-ES")))     
   End Sub
End Module
' The example displays the following output:
'       miércoles.
' </Snippet5>
