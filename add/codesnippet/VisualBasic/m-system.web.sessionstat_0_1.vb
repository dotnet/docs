    Public Function Validate(id As String) As Boolean _
      Implements ISessionIDManager.Validate
    
      Try
        Dim testGuid As Guid = New Guid(id)

        If id = testGuid.ToString() Then _
          Return True
      Catch
      
      End Try

      Return False
    End Function