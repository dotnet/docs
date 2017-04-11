' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As STring = "\b.*[.?!;:](\s|\z)"
      Dim input As String = "this. what: is? go, thing."
      For Each match As Match In Regex.Matches(input, pattern)
         Console.WriteLine(match.Value)
      Next   
   End Sub
End Module
' The example displays the following output:
'       this. what: is? go, thing.
' </Snippet4>
