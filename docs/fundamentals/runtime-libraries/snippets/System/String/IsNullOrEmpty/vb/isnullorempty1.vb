' Visual Basic .NET Document
Option Strict On

Module Example1
   Public Sub Main()
      Dim s1 As String = Nothing
      Dim s2 As String = ""
      Console.WriteLine(TestForNullOrEmpty(s1))
      Console.WriteLine(TestForNullOrEmpty(s2))
   End Sub

   Private Function TestForNullOrEmpty(s As String) As Boolean
      Dim result As Boolean
      ' <Snippet1>
      result = s Is Nothing OrElse s = String.Empty
      ' </Snippet1>
      Return result
   End Function
End Module

