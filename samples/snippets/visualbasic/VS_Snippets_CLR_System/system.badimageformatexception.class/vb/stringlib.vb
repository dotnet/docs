Option Strict On

Imports System

' <Snippet2>
Public Module StringLib
   Private exceptionList() As String = { "a", "an", "the", "in", "on", "of" }
   Private separators() As Char = { " "c }
   
   Public Function ToProperCase(title As String) As String
      Dim isException As Boolean = False	
      
      Dim words() As String = title.Split( separators, StringSplitOptions.RemoveEmptyEntries)
      Dim newWords(words.Length) As String
		
      For ctr As Integer = 0 To words.Length - 1
         isException = False

         For Each exception As String In exceptionList
            If words(ctr).Equals(exception) And ctr > 0 Then
               isException = True
               Exit For
            End If
         Next
         If Not isException Then
            newWords(ctr) = words(ctr).Substring(0, 1).ToUpper() + words(ctr).Substring(1)
         Else
            newWords(ctr) = words(ctr)	 
         End If	 
      Next	
      Return String.Join(" ", newWords) 			
   End Function
End Module
' </Snippet2>

