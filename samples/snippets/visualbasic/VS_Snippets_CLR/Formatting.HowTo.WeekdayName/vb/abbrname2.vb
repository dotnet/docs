' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim dateValue As Date = #6/11/2008#
      Console.WriteLine(dateValue.ToString("ddd", 
                        New CultureInfo("fr-FR")))    
   End Sub
End Module
' The example displays the following output:
'       mer.
' </Snippet2>

