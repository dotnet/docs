' Visual Basic .NET Document
Option Strict On

' <Snippet7>
Module Example
   Public Sub Main()
      Dim separators() As String = {",", ".", "!", "?", ";", ":", " "}
      Dim value As String = "The handsome, energetic, young dog was playing with his smaller, more lethargic litter mate."
      Dim words() As String = value.Split(separators, StringSplitOptions.RemoveEmptyEntries)
      For Each word In words
         Console.WriteLine(word)
      Next   
   End Sub
End Module
' The example displays the following output:
'       The
'       handsome
'       energetic
'       young
'       dog
'       was
'       playing
'       with
'       his
'       smaller
'       more
'       lethargic
'       litter
'       mate
' </Snippet7>

