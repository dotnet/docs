' Visual Basic .NET Document
Option Strict On

' <Snippet11>
Imports System.Collections.Generic

Module Example
   Public Sub Main()
      Dim value As String = "This is the first sentence in a string. " +
                            "More sentences will follow. For example, " +
                            "this is the third sentence. This is the " +
                            "fourth. And this is the fifth and final " +
                            "sentence."
      Dim sentences As New List(Of String)
      Dim position As Integer = 0
      Dim start As Integer = 0
      ' Extract sentences from the string.
      Do
         position = value.IndexOf("."c, start)
         If position >= 0 Then
            sentences.Add(value.Substring(start, position - start + 1).Trim())
            start = position + 1
         End If
      Loop While position > 0
      
      ' Display the sentences.
      For Each sentence In sentences
         Console.WriteLine(sentence)
      Next
   End Sub
End Module
' The example displays the following output:
'       This is the first sentence in a string.
'       More sentences will follow.
'       For example, this is the third sentence.
'       This is the fourth.
'       And this is the fifth and final sentence.
' </Snippet11>
