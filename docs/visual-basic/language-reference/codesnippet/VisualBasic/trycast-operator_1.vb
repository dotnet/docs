  Function PrintTypeCode(ByVal obj As Object) As String
      Dim objAsConvertible As IConvertible = TryCast(obj, IConvertible)
      If objAsConvertible Is Nothing Then
          Return obj.ToString() & " does not implement IConvertible"
      Else
          Return "Type code is " & objAsConvertible.GetTypeCode()
      End If
  End Function