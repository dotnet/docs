' Visual Basic .NET Document
Option Strict On

' <Snippet10>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim input As String = "abacus -- alabaster - * - atrium -+- " +
                            "any -*- actual - + - armoir - - alarm"
      Dim pattern As String = "\s-\s?[+*]?\s?-\s"
      Dim elements() As String = Regex.Split(input, pattern)
      For Each element In elements
         Console.WriteLine(element)
      Next
   End Sub
End Module
' The example displays the following output:
'       abacus
'       alabaster
'       atrium
'       any
'       actual
'       armoir
'       alarm
' </Snippet10>
