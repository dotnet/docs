
Public Module Example
   Public Sub Main()
      Console.WriteLine(ShowCode())
   End Sub

   Private Function ShowCode() As Boolean
      Dim value As String = Nothing
      ' <Snippet2>
      Return String.IsNullOrEmpty(value) OrElse value.Trim().Length = 0
      ' </Snippet2>
   End Function
End Module