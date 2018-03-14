' Visual Basic .NET Document
Option Strict On

' <Snippet9>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim input As String = String.Format("[This is captured{0}text.]" +
                                          "{0}{0}[{0}[This is more " +
                                          "captured text.]{0}{0}" +
                                          "[Some more captured text:" +
                                          "{0}   Option1" +
                                          "{0}   Option2][Terse text.]",
                                          vbCrLf)
      Dim pattern As String = "\[([^\[\]]+)\]"
      Dim ctr As Integer = 0
      For Each m As Match In Regex.Matches(input, pattern)
         ctr += 1
         Console.WriteLine("{0}: {1}", ctr, m.Groups(1).Value)
      Next
   End Sub
End Module
' The example displays the following output:
'       1: This is captured
'       text.
'       2: This is more captured text.
'       3: Some more captured text:
'          Option1
'          Option2
'       4: Terse text.
' </Snippet9>
