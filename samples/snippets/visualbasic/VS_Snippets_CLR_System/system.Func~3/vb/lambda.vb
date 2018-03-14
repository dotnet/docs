' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Module LambdaExpression
   Public Sub Main()
      Dim separators() As Char = {" "c}
      Dim extract As Func(Of String, Integer, String()) = Function(s, i) _
          CType(iif(i > 0, s.Split(separators, i), s.Split(separators)), String())  
      
      Dim title As String = "The Scarlet Letter"
      For Each word As String In extract(title, 5)
         Console.WriteLine(word)
      Next   
   End Sub
End Module
' </Snippet4>

