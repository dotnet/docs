' Visual Basic .NET Document
Option Strict On

' Are String.Split(String[], StringSplitOptions) and 
' String.Split(Char[[], StringSplitOptions) ambiguous?
Module Example
   Public Sub Main()
      SplitWithCharAndInt()
      SplitWithStringAndInt()
      SplitWithChar()
      SplitWithString()
   End Sub
   
   Private Sub SplitWithCharAndInt()
      ' <Snippet3>
      Dim phrase As String = "The quick brown fox"
      Dim words() As String
      
      words = phrase.Split(TryCast(Nothing, Char()), 3, 
                             StringSplitOptions.RemoveEmptyEntries)
      
      words = phrase.Split(New Char() {}, 3,
                           StringSplitOptions.RemoveEmptyEntries)
      ' </Snippet3>
   End Sub
   
   Private Sub SplitWithStringAndInt()
      ' <Snippet4>
      Dim phrase As String = "The quick brown fox"
      Dim words() As String
      
      words = phrase.Split(TryCast(Nothing, String()), 3, 
                             StringSplitOptions.RemoveEmptyEntries)
      
      words = phrase.Split(New String() {}, 3,
                           StringSplitOptions.RemoveEmptyEntries)
      ' </Snippet4>
   End Sub
   
   Private Sub SplitWithChar()
      ' <Snippet5>
      Dim phrase As String = "The quick brown fox"
      Dim words() As String
      
      words = phrase.Split(TryCast(Nothing, Char()),  
                             StringSplitOptions.RemoveEmptyEntries)
      
      words = phrase.Split(New Char() {}, 
                           StringSplitOptions.RemoveEmptyEntries)
      ' </Snippet5>
   End Sub
   
   Private Sub SplitWithString()
      ' <Snippet6>
      Dim phrase As String = "The quick brown fox"
      Dim words() As String
      
      words = phrase.Split(TryCast(Nothing, String()),  
                             StringSplitOptions.RemoveEmptyEntries)
      
      words = phrase.Split(New String() {},
                           StringSplitOptions.RemoveEmptyEntries)
      ' </Snippet6>
   End Sub
End Module

