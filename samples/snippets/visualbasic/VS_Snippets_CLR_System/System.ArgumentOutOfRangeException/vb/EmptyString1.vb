' Visual Basic .NET Document
Option Strict On

' <Snippet15>
Module Example
   Public Sub Main()
       Dim words() As String = { "the", "today", "tomorrow", " ", "" }
       For Each word In words
          Console.WriteLine("First character of '{0}': '{1}'", 
                            word, GetFirstCharacter(word))
       Next                     
   End Sub
   
   Private Function GetFirstCharacter(s As String) As Char
      Return s(0)
   End Function
End Module
' The example displays the following output:
'    First character of 'the': 't'
'    First character of 'today': 't'
'    First character of 'tomorrow': 't'
'    First character of ' ': ' '
'    
'    Unhandled Exception: System.IndexOutOfRangeException: Index was outside the bounds of the array.
'       at Example.Main()
' </Snippet15>

Public Module StringLib
   ' <Snippet16>
   Function GetFirstCharacter(s As String) As Char
      If String.IsNullOrEmpty(s) Then 
         Return ChrW(0)
      Else   
         Return s(0)
      End If   
   End Function
   ' </Snippet16>
End Module