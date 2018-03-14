' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Module LambdaExpression
   Public Sub Main()
      Dim convert As Func(Of String, String) = Function(s) s.ToUpper()
      
      Dim name As String = "Dakota"
      Console.WriteLine(convert(name))  
   End Sub
End Module
' </Snippet4>

