' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim cultureNames() As String = { "en-US", "fr-FR", "de-DE", "es-ES" }
      
      Dim dateToDisplay As Date = #9/1/2009 6:32PM#
      Dim value As Double = 9164.32

      Console.WriteLine("Culture     Date                                Value")
      Console.WriteLine()      
      For Each cultureName As String In cultureNames
         Dim culture As New CultureInfo(cultureName)
         Dim output As String = String.Format(culture, "{0,-11} {1,-35:D} {2:N}", _
                                              culture.Name, dateToDisplay, value)
         Console.WriteLine(output)
      Next    
   End Sub
End Module
' The example displays the following output:
'       Culture     Date                                Value
'       
'       en-US       Tuesday, September 01, 2009         9,164.32
'       fr-FR       mardi 1 septembre 2009              9 164,32
'       de-DE       Dienstag, 1. September 2009         9.164,32
'       es-ES       martes, 01 de septiembre de 2009    9.164,32
' </Snippet2>
