' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim keyEntered As ConsoleKeyInfo
      Dim beginComment, endComment As Char
      Console.Write("Enter begin comment symbol: ")
      keyEntered = Console.ReadKey()
      beginComment = keyEntered.KeyChar
      Console.WriteLine()
      
      Console.Write("Enter end comment symbol: ")
      keyEntered = Console.ReadKey()
      endComment = keyEntered.KeyChar
      Console.WriteLine()
      
      Dim input As String = "Text [comment comment comment] more text [comment]"
      Dim pattern As String = Regex.Escape(beginComment.ToString()) + "(.*?)"
      Dim endPattern As String = Regex.Escape(endComment.ToString())
      If endComment = "]"c OrElse endComment = "}"c Then endPattern = "\" + endPattern
      pattern += endPattern
      
      Dim matches As MatchCollection = Regex.Matches(input, pattern)
      Console.WriteLine(pattern)
      Dim commentNumber As Integer = 0
      For Each match As Match In matches
         commentNumber += 1
         Console.WriteLine("{0}: {1}", commentNumber, match.Groups(1).Value)
      Next         
   End Sub
End Module
' The example shows possible output from the example:
'       Enter begin comment symbol: [
'       Enter end comment symbol: ]
'       \[(.*?)\]
'       1: comment comment comment
'       2: comment
' </Snippet3>
