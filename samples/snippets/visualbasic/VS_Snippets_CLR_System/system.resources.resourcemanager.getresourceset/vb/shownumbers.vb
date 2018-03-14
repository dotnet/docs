' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization
Imports System.Resources

Module Example
   Public Sub Main()
      Dim numbers() As String = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten" }
      Dim rm As New ResourceManager(GetType(NumberResources))
      Dim rs As ResourceSet = rm.GetResourceSet(CultureInfo.CreateSpecificCulture("fr-FR"), True, False)
      If rs Is Nothing Then Console.WriteLine("No resource set.") : Exit Sub
      For Each number In numbers
         Console.WriteLine("{0,-10} '{1}'", number + ":", rs.GetString(number))
      Next            
   End Sub
End Module

Public Class NumberResources
End Class
' The example displays the following output:
'       one:       'un'
'       two:       'deux'
'       three:     'trois'
'       four:      'quatre'
'       five:      ''
'       six:       ''
'       seven:     ''
'       eight:     ''
'       nine:      ''
'       ten:       ''
' </Snippet1>