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