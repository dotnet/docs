' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module TrimEnd
   Public Sub Main()
      Dim sentence As String = "The dog had a bone, a ball, and other toys."
      Dim charsToTrim() As Char = {","c, "."c, " "c}
      Dim words() As String = sentence.Split()
      For Each word As String In words
         Console.WriteLine(word.TrimEnd(charsToTrim))
      Next
   End Sub
End Module
' The example displays the following output:
'       The
'       dog
'       had
'       a
'       bone
'       a
'       ball
'       and
'       other
'       toys
' </Snippet2>

