' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Text

Module Example
   Public Sub Main()
      Dim nAlphabeticChars As Integer = 0
      Dim nWhitespace As Integer = 0
      Dim nPunctuation As Integer = 0  
      Dim sb As New StringBuilder("This is a simple sentence.")
      
      For ctr As Integer = 0 To sb.Length - 1
         Dim ch As Char = sb(ctr)
         If Char.IsLetter(ch) Then nAlphabeticChars += 1 : Continue For
         If Char.IsWhiteSpace(ch) Then nWhitespace += 1 : Continue For
         If Char.IsPunctuation(ch) Then nPunctuation += 1
      Next    

      Console.WriteLine("The sentence '{0}' has:", sb)
      Console.WriteLine("   Alphabetic characters: {0}", nAlphabeticChars)
      Console.WriteLine("   Whitespace characters: {0}", nWhitespace)
      Console.WriteLine("   Punctuation characters: {0}", nPunctuation)
   End Sub
End Module
' The example displays the following output:
'       The sentence 'This is a simple sentence.' has:
'          Alphabetic characters: 21
'          Whitespace characters: 4
'          Punctuation characters: 1
' </Snippet1>
