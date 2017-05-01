' Visual Basic .NET Document
Option Strict On

' <Snippet18>
Module Example
   Public Sub Main()
      Dim phrases() As String = { "ocean blue", "concerned citizen", 
                                  "runOnPhrase" }
      For Each phrase In phrases
         Dim word As String = GetSecondWord(phrase)
         If Not String.IsNullOrEmpty(word) Then _
            Console.WriteLine("Second word is {0}", word)
      Next                            
   End Sub
  
   Function GetSecondWord(s As String) As String
      Dim pos As Integer = s.IndexOf(" ")
      If pos >= 0
          Return s.Substring(pos).Trim()
      Else
         Return String.Empty
      End If
  End Function
End Module
' The example displays the following output:
'       Second word is blue
'       Second word is citizen
' </Snippet18>

