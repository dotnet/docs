    Public Function CreateResolveNameEventArgs(ByVal value As Object, ByVal name As String) As ResolveNameEventArgs
        Dim e As New ResolveNameEventArgs(name)
        ' The name to resolve                       e.Name       
        ' Stores an object matching the name        e.Value            
        Return e
    End Function
