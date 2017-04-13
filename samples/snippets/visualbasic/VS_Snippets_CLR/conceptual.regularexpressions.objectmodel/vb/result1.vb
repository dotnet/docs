' Visual Basic .NET Document
Option Strict On

' <Snippet9>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "\b\d+(,\d{3})*\.\d{2}\b"
      Dim input As String = "16.32" + vbCrLf + "194.03" + vbCrLf + "1,903,672.08" 

      For Each match As Match In Regex.Matches(input, pattern)
         Console.WriteLine(match.Result("$$ $&"))
      Next
   End Sub
End Module
' The example displays the following output:
'       $ 16.32
'       $ 194.03
'       $ 1,903,672.08
' </Snippet9>
