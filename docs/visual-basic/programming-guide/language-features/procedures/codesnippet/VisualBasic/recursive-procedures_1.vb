  Function factorial(ByVal n As Integer) As Integer
      If n <= 1 Then
          Return 1
      Else
          Return factorial(n - 1) * n
      End If
  End Function