' Visual Basic .NET Document
Option Strict On

' <Snippet19>
Imports System.Collections.Generic

Module Example
   Public Sub Main()
      Dim sentence As String = "This is a simple, short sentence."
      Console.WriteLine("Words in '{0}':", sentence)
      For Each word In FindWords(sentence)
         Console.WriteLine("   '{0}'", word)
      Next
   End Sub
   
   Function FindWords(s As String) As String()
      Dim start, ending As Integer
      Dim delimiters() As Char = { " "c, "."c, ","c, ";"c, ":"c,
                                   "("c, ")"c }
      Dim words As New List(Of String)()

      Do While ending >= 0
         ending = s.IndexOfAny(delimiters, start)
         If ending >= 0
            If ending - start > 0 Then
               words.Add(s.Substring(start, ending - start)) 
            End If
            start = ending + 1
         Else
            If start < s.Length - 1 Then
               words.Add(s.Substring(start))
            End If      
         End If
      Loop    
      Return words.ToArray()                         
   End Function
End Module
' The example displays the following output:
'       Words in 'This is a simple, short sentence.':
'          'This'
'          'is'
'          'a'
'          'simple'
'          'short'
'          'sentence'
' </Snippet19>
