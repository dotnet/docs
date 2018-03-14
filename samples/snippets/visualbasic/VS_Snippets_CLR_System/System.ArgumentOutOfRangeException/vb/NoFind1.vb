' Visual Basic .NET Document
Option Strict On

' <Snippet17>
Module Example
   Public Sub Main()
      Dim phrases() As String = { "ocean blue", "concerned citizen", 
                                  "runOnPhrase" }
      For Each phrase In phrases
         Console.WriteLine("Second word is {0}", GetSecondWord(phrase))
      Next                            
  End Sub
  
  Function GetSecondWord(s As String) As String
     Dim pos As Integer = s.IndexOf(" ")
     Return s.Substring(pos).Trim()
  End Function
End Module
' The example displays the following output:
'       Second word is blue
'       Second word is citizen
'       
'       Unhandled Exception: System.ArgumentOutOfRangeException: StartIndex cannot be less than zero.
'       Parameter name: startIndex
'          at System.String.Substring(Int32 startIndex, Int32 length)
'          at Example.GetSecondWord(String s)
'          at Example.Main()
' </Snippet17>

