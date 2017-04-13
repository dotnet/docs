' <Snippet1>
Public Module Example
   Public Sub Main
      Dim int1 As Integer = 3
      Console.WriteLine(Object.ReferenceEquals(int1, int1))
      Console.WriteLine(int1.GetType().IsValueType)
   End Sub
End Module
' The example displays the following output:
'       False
'       True
' </Snippet1>