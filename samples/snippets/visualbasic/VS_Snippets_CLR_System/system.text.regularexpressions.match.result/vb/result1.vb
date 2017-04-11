' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "--(.+?)--"
      Dim replacement As String = "($1)"
      Dim input As String = "He said--decisively--that the time--whatever time it was--had come."
      For Each match As Match In Regex.Matches(input, pattern)
         Dim result As String = match.Result(replacement)
         Console.WriteLine(result)
      Next
   End Sub
End Module
' The example displays the following output:
'       (decisively)
'       (whatever time it was)
' </Snippet1>
